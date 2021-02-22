
using MISA.ApplicationCore.Emuns;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MISA.ApplicationCore.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        IBaseRepository<TEntity> _baseRepository;
        ServiceResult _serviceResult;
        #region Constructor
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult()
            {
                MISACode = MISACode.Success
            };
        }
        #endregion
        #region Method
        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="TEntityId">ID</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        public ServiceResult Delete(Guid TEntityId)
        {
            _serviceResult.Data = _baseRepository.Delete(TEntityId);
            return _serviceResult;
        }

        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <param name=""></param>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        public IEnumerable<TEntity> GetEntities()
        {
            var entities = _baseRepository.GetEntities();
            return entities;
        }
        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="TEntityId">ID</param>
        /// <returns>Thông tin đối tượng</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        public TEntity GetEntityById(Guid TEntityId)
        {
            var entities = _baseRepository.GetEntityById(TEntityId);
            return entities;
        }
        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="TEntityId">ID</param>
        /// <returns>Thông tin đối tượng</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        public virtual ServiceResult Insert(TEntity TEntity)
        {
            TEntity.EntityState = Emuns.EntityState.AddNew;
            var check = Validate(TEntity);
            if (check)
            {
                int rowEffects = _baseRepository.Insert(TEntity);
                _serviceResult.MISACode = MISACode.IsValid;
                _serviceResult.Messenger = "Thêm thành công";
                _serviceResult.Data = rowEffects;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }
        /// <summary>
        /// Cập nhật dự liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy : DMThanh (08-02-2021)
        public ServiceResult Update(TEntity TEntity)
        {
            TEntity.EntityState = Emuns.EntityState.Update;
            var check = Validate(TEntity);
            if (check)
            {
                int rowEffects = _baseRepository.Update(TEntity);
                _serviceResult.MISACode = MISACode.IsValid;
                _serviceResult.Messenger = "Sửa thành công";
                _serviceResult.Data = rowEffects;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }
        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy : DMThanh (08-02-2021)
        protected bool Validate(TEntity entity)
        {
            var listError = new List<string>();
            var check = true;
            //Đọc các property
            var properties = entity.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(entity);
                var displayName = string.Empty;
                var displayNameAttributes = prop.GetCustomAttributes(typeof(DisplayName), true);
                if (displayNameAttributes.Length > 0)
                {
                    displayName = (displayNameAttributes[0] as DisplayName).Name;
                }
                //Kiểm tra xem có attribute cấn phải validate 
                if (prop.IsDefined(typeof(Required), false))
                {
                    //Check bắt buộc nhập
                    if (propValue == null || propValue.ToString().Trim() == "")
                    {
                        check = false;
                        listError.Add($"Dữ liệu {displayName} không được phép trống");
                        _serviceResult.MISACode = MISACode.NotValid;
                        _serviceResult.Messenger = "Dữ liệu không hợp lệ";
                        _serviceResult.Data = listError;
                    }
                    if (check)
                    {
                        if (prop.IsDefined(typeof(MaxLength), false))
                        {
                            var attributeMaxLength = prop.GetCustomAttributes(typeof(MaxLength), true)[0];
                            var length = (attributeMaxLength as MaxLength).Value;
                            var msg = (attributeMaxLength as MaxLength).ErrorMesssage;
                            if (propValue.ToString().Trim().Length > length || propValue == null)
                            {
                                check = false;
                                listError.Add(msg ?? $"Thông tin này vượt quá {length} ký tự cho phép.");
                                _serviceResult.MISACode = Emuns.MISACode.NotValid;
                                _serviceResult.Messenger = "Dữ liệu không hợp lệ";
                                _serviceResult.Data = listError;
                            }
                        }
                    }
                }
                if (prop.IsDefined(typeof(CheckDuplicate), false))
                {
                    //Check trùng dữ liệu
                    var entityDuplicate = _baseRepository.EntityByProperty(entity, prop);
                    if (entityDuplicate != null)
                    {
                        check = false;
                        listError.Add($"Dữ liệu {displayName} đã có trên hệ thống");
                        _serviceResult.MISACode = MISACode.NotValid;
                        _serviceResult.Messenger = "Dữ liệu không hợp lệ";
                        _serviceResult.Data = listError;
                    }
                }

                if (prop.IsDefined(typeof(Email), false))
                {
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(propValue.ToString());
                    if (!match.Success)
                    {
                        check = false;
                        listError.Add($"Dữ liệu {displayName} không đúng định dạng");
                        _serviceResult.MISACode = MISACode.NotValid;
                        _serviceResult.Messenger = "Dữ liệu không hợp lệ";
                        _serviceResult.Data = listError;
                    }
                }
            }
            if (check == true)
            {
                check = ValidateCustom(entity);
            }
            return check;
        }
        /// <summary>
        /// Hàm thực hiện kiếm tra dữ liệu/ Nghiệp vụ
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy : DMThanh (08-02-2021)
        protected virtual bool ValidateCustom(TEntity entity)
        {
            return true;
        }
        #endregion Method
    }
}
