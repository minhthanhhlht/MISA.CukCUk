using MISA.ApplicationCore.Emuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Kết quả trả về
    /// </summary>
    /// CreatedBy : DMThanh (08-02-2021)
    public class ServiceResult
    {
        /// <summary>
        /// Dữ liệu
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Thông báo
        /// </summary>
        public string Messenger { get; set; }
        /// <summary>
        /// Mã thông báo
        /// </summary>
        public MISACode MISACode { get; set; }
    }
}
