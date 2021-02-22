using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface danh mục khách hàng
    /// </summary>
    /// CreatedBy : DMThanh (08-02-2021)
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        /// Lấy thông tin khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns>Khách hàng</returns>
        Customer getCustomerByCode(string customerCode);
        /// <summary>
        /// Lấy thông tin khách hàng theo số điện thoại
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns>Khách hàng</returns>
        Customer getCustomerByPhoneNumber(string phoneNumber);
    }
}
