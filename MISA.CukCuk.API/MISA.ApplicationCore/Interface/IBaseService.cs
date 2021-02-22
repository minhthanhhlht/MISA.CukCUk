using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        IEnumerable<TEntity> GetEntities();
        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        ServiceResult Update(TEntity TEntity);
        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        ServiceResult Delete(Guid TEntityId);
        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        ServiceResult Insert(TEntity TEntity);
        /// <summary>
        /// Lấy đối tượng theo ID
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        TEntity GetEntityById(Guid TEntityId);
    }
}
