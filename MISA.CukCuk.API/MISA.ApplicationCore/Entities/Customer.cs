using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    /// CreatedBy : DMThanh (08-02-2021)
    public class Customer:BaseEntity
    {
        #region constructor
        public Customer()
        {
            CustomerId = new Guid();
        }

        #endregion
        #region Declare

        #endregion

        #region Property
        [PrimaryKey]
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }
        [Required]
        [CheckDuplicate]
        [DisplayName("Mã khách hàng")]
        [MaxLength(20, "Mã khách hàng đã vượt quá 20 ký tự")]
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        ///  Số thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Ngày tháng năm sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
       /// <summary>
       /// Giới tính
       /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Địa chỉ Email
        /// </summary>
        public string Email { get; set; }
        [CheckDuplicate]
        [DisplayName("Số điện thoại")]
        /// <summary>
        ///  Số điện thoại
        /// </summary>
        /// 
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Tên công ty làm việc
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế của công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }

        #endregion

        
    }
}       