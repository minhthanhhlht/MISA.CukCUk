
using MISA.ApplicationCore.Emuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// kiểm tra không bỏ trống
    /// </summary>
    /// CreatedBy : DMThanh (08-02-2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }
    /// <summary>
    /// kiểm tra nhập trùng
    /// </summary>
    /// CreatedBy : DMThanh (08-02-2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {

    }
    /// <summary>
    /// Xác nhận khóa chính
    /// </summary>
    /// CreatedBy : DMThanh (08-02-2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

    }

    /// <summary>
    /// Hiển thị tên
    /// </summary>
    /// CreatedBy : DMThanh (08-02-2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayName : Attribute
    {
        public string Name { get; set; }
        public DisplayName(string name)
        {
            this.Name = name;
        }
    }
    /// <summary>
    /// Độ dài tối đa
    /// </summary>
    /// CreatedBy : DMThanh (08-02-2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        public int Value { get; set; }
        public string ErrorMesssage { get; set; }
        public MaxLength(int length, string errorMes = "")
        {
            this.Value = length;
            this.ErrorMesssage = errorMes;
        }
    }
    /// <summary>
    /// Kiểm tra Email
    /// </summary>
    /// CreatedBy : DMThanh (08-02-2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Email : Attribute
    {

    }
    public class BaseEntity
    {
        /// <summary>
        /// Xác nhận phương thức 0-Thêm, 1-Sửa, 2-Xóa
        /// </summary>
        /// CreatedBy : DMThanh (08-02-2021)
        public EntityState EntityState { get; set; } = EntityState.AddNew;
        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// CreatedBy : DMThanh (08-02-2021)
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        /// CreatedBy : DMThanh (08-02-2021)
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        /// CreatedBy : DMThanh (08-02-2021)
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        /// CreatedBy : DMThanh (08-02-2021)
        public string ModifiedBy { get; set; }
    }
}
