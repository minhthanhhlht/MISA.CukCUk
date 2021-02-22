using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructure
{
    public class CustomerRepository :BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {

        }
        /// <summary>
        /// Lấy thông tin khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="CustomerCode"></param>
        /// <returns>Khách hàng</returns>
        /// Createby: DMThanh (08-02-2021)
        public Customer getCustomerByCode(string customerCode)
        {
            var cus = _dbConnection.Query<Customer>("Proc_GetCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return cus;
        }
        /// <summary>
        /// Lấy thông tin khách hàng theo số điện thoại
        /// </summary>
        /// <param name="CustomerCode"></param>
        /// <returns>Khách hàng</returns>
        /// Createby: DMThanh (08-02-2021)
        public Customer getCustomerByPhoneNumber(string phoneNumber)
        {
            var cus = _dbConnection.Query<Customer>("Proc_GetCustomerByPhoneNumber", new { PhoneNumber = phoneNumber }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return cus;
        }
    }

}
