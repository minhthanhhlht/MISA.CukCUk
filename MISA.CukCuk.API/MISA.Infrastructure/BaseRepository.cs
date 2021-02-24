using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Emuns;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : BaseEntity
    {
        #region DECLARE
        //Khởi tạo kết nối 
        IConfiguration _configuration;
        string _connectionString;
        //Khởi tạo kết nối
        protected IDbConnection _dbConnection;
        //Tên bảng được truyển bởi TEntity
        protected string _tableName;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectString");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(TEntity).Name;
        }
        #endregion

        #region Method
        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <param name="customerId">ID đối tượng</param>
        /// <returns>Số bản ghi được xóa</returns>
        /// Created BY: DMThanh (08-02-2021)
        public int Delete(Guid customerId)
        {
            _dbConnection.Open();
            var rowAffects = 0;
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    rowAffects = _dbConnection.Execute($"DELETE FROM {_tableName} WHERE {_tableName}Id = '{customerId.ToString()}'", commandType: CommandType.Text);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
            return rowAffects;
        }
        /// <summary>
        /// Lấy tất cả dữ liệu bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created BY: DMThanh (08-02-2021)
        public IEnumerable<TEntity> GetEntities()
        {
            //Khởi tạo các command Text
            var entities = _dbConnection.Query<TEntity>($"Proc_GetAll{_tableName}s", commandType: CommandType.StoredProcedure);
            //Trả về dữ liệu
            return entities;
        }
        /// <summary>
        /// Lấy dữ liệu theo ID
        /// </summary>
        /// <returns>Bản ghi</returns>
        /// Created BY: DMThanh (08-02-2021)
        public TEntity GetEntityById(Guid customerId)
        {
            string id = customerId.ToString();
            var entities = _dbConnection.Query<TEntity>($"SELECT * FROM {_tableName} c WHERE c.{_tableName}Id = '{id}'", commandType: CommandType.Text).FirstOrDefault();
            return entities;
        }
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <returns>Đối tượng được lấy theo ID</returns>
        /// Created BY: DMThanh (08-02-2021)
        public int Insert(TEntity entity)
        {
            _dbConnection.Open();
            var rowAffects = 0;
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    //format dữ liệu
                    var paremeters = MappingDbType(entity);
                    //Thực thi command Text
                    rowAffects = _dbConnection.Execute($"Proc_Insert{_tableName}", paremeters, commandType: CommandType.StoredProcedure);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                //Trả về kết quả
                return rowAffects;
            }

        }
        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="entity">Bản ghi</param>
        /// <returns>Số lượng bản ghi được cập nhật</returns>
        /// Created BY: DMThanh (08-02-2021)
        public int Update(TEntity entity)
        {
            _dbConnection.Open();
            var rowAffects = 0;
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    //format dữ liệu
                    var paremeters = MappingDbType(entity);
                    //Thực thi command
                    rowAffects = _dbConnection.Execute($"Proc_Update{_tableName}", paremeters, commandType: CommandType.StoredProcedure);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
            //Trả về kết quả
            return rowAffects;
        }
        /// <summary>
        /// Format lại dữ liệu nhận
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Created BY: DMThanh (08-02-2021)
        private DynamicParameters MappingDbType(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var paremeters = new DynamicParameters();
            foreach (var prop in properties)
            {
                var propertyName = prop.Name;
                var propertyVal = prop.GetValue(entity);
                var propertyType = prop.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    paremeters.Add($"@{propertyName}", propertyVal, DbType.String);
                }
                else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
                {
                    var dbValue = ((bool)propertyVal == true ? 1 : 0);
                    paremeters.Add($"@{propertyName}", dbValue, DbType.Int32);
                }
                else
                {
                    paremeters.Add($"@{propertyName}", propertyVal);
                }
            }
            return paremeters;
        }
        /// <summary>
        /// Kiểm tra status thêm hay sửa
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public  TEntity EntityByProperty(TEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = string.Empty;
            if (entity.EntityState == EntityState.AddNew)
            {
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";
            }
            else if (entity.EntityState == EntityState.Update)
            {
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}' AND {_tableName}Id <> '{keyValue}'";
            }
            else
            {
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";
            }
            var entityReturn = _dbConnection.Query<TEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return entityReturn;
        }

        /// <summary>
        /// Đóng Database
        /// </summary>
        public void Dispose()
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }
        #endregion
    }
}
