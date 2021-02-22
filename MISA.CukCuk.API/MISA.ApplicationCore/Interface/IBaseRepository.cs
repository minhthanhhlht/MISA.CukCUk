using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        IEnumerable<TEntity> GetEntities();
        /// <summary>
        /// Lấy dữ liệu theo ID
        /// </summary>
        /// <returns>Chi tiết dữ liệu theo ID</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        TEntity GetEntityById(Guid customerId);
        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <returns>Số bản ghi dữ liệu được cập nhập</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        int Update(TEntity customer);
        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>Trả về số lượng bản ghi được xóa</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        int Delete(Guid customerId);
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Số lượng bản ghi được thêm mới</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        int Insert(TEntity customer);
        /// <summary>
        /// Lấy thông tin theo từng thuộc tính
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// CreatedBy : DMThanh (08-02-2021)
        TEntity EntityByProperty(TEntity entity, PropertyInfo property);
    }
}
