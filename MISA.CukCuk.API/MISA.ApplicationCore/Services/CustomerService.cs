using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;

        #region Constructor
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected override bool ValidateCustom(Customer entity)
        {
            return true;  
        }

      

        public IEnumerable<Customer> GetCustomerByCustomerGroup(Guid CustomerGroupId)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
