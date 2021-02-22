using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Emuns
{
    /// <summary>
    /// Xác định trạng thái của việc validate
    /// </summary>
    /// CreatedBy : DMThanh (08-02-2021)
    public enum MISACode
    {
        /// <summary>
        /// Dữ liệu hợp lệ
        /// </summary>
        IsValid = 100,

        /// <summary>
        /// Dữ liệu không hợp lệ
        /// </summary>
        NotValid = 600,

        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,
    }

    /// <summary>
    /// Xác định trạng thái của object
    /// </summary>
    public enum EntityState
    {
        AddNew = 1,
        Update = 2,
        Delete = 3
    }
}
