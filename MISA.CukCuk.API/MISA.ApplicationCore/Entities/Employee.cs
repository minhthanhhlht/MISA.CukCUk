using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Thông tin nhân viên
    /// CreatedBy : DMThanh (08-02-2021)
    /// </summary>
    public class Employee : BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        [Required]
        [CheckDuplicate]
        [DisplayName("ID nhân viên")]
        public Guid EmployeeId { get; set; }
        [Required]
        [CheckDuplicate]
        [DisplayName("Mã nhân viên")]
        [MaxLength(20, "Mã nhân viên tối đa chỉ 20 kí tự")]
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Họ tên
        /// </summary>
        [Required]
        [DisplayName("Họ tên")]
        public string FullName { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [DisplayName("Email")]
        [Email]
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        [Required]
        [DisplayName("Số điện thoại")]
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// Mã vị trí
        /// </summary>
        [Required]
        [DisplayName("Vị trí")]
        public Guid? PositionId { get; set; }
      
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [Required]
        [DisplayName("Phòng ban")]
        public Guid? DepartmentId { get; set; }
 
        /// <summary>
        /// Lương
        /// </summary>
        public double? Salary { get; set; }
        /// <summary>
        /// Số chứng minh thư
        /// </summary>
        [Required]
        [CheckDuplicate]
        [DisplayName("Số chứng minh thư")]
        public string IdentityNumber { get; set; }
        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string IdentityPlace { get; set; }
        /// <summary>
        /// Ngày gia nhập
        /// </summary>
        public DateTime? JoinDate { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string PersonalTaxCode { get; set; }
        /// <summary>
        /// Trạng thái làm việc
        /// </summary>
        public string WorkStatus { get; set; }
       
        #endregion
    }
}
