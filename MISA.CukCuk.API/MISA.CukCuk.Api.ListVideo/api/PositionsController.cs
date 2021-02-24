using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    /// <summary>
    /// Chức vụ nhân viên    
    /// </summary>
    /// Created BY: DMThanh (08-02-2021)s
    public class PositionsController : BaseEntityController<Position>
    {
        IPositionService _positionService;
        public PositionsController(IPositionService positionService) : base(positionService)
        {
            _positionService = positionService;
        }
    }
}
