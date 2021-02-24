using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Entities;


namespace MISA.CukCuk.Web.Controllers
{
    /// <summary>
    /// Khách hàng    
    /// </summary>
    /// Created BY: DMThanh (08-02-2021)
    public class CustomersController : BaseEntityController<Customer>
    {
        ICustomerService _baseService;
        public CustomersController(ICustomerService baseService):base(baseService)
        {
            _baseService = baseService;
        }
    }
}