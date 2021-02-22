using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Vị trí
    /// CreatedBy : DMThanh (08-02-2021)
    /// </summary>
    public class Position : BaseEntity
    {
        /// <summary>
        /// Mã vị trí
        /// </summary>
        public Guid PositionId { get; set; }
        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// Mô tả chi tiết
        /// </summary>
        public string Description { get; set; }
    }
}
