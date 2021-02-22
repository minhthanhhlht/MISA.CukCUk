using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface ICustomerService : IBaseService<Customer>
    {
        
        /// <summary>
        /// Lấy danh sách khách hàng theo nhóm khách hàng
        /// </summary>
        /// <param name="CustomerGroupId"></param>
        /// <returns>List Khách hàng</returns>
        /// CreatedBy : DMThanh (08-02-2021)
        IEnumerable<Customer> GetCustomerByCustomerGroup(Guid CustomerGroupId);
    }
}
