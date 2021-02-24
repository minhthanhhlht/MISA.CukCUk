using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Emuns;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        IBaseService<TEntity> _baseService;
        public BaseEntityController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        // GET: api/<BaseEntityController>
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        /// Created BY: DMThanh (08-02-2021)
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetEntities();
            return Ok(entities);
        }

        // GET api/<BaseEntityController>/5
        /// <summary>
        /// Lấy danh sách theo id
        /// </summary>
        /// <param name="id">ID TEntity</param>
        /// <returns>Danh sách </returns>
        /// Created BY: DMThanh (08-02-2021)
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var entity = _baseService.GetEntityById(Guid.Parse(id));
            return Ok(entity);
        }

        // POST api/<BaseEntityController>
        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi thêm được</returns>
        /// Created BY: DMThanh (08-02-2021)
        [HttpPost]
        public IActionResult Post(TEntity entity)
        {
            var serviceResult = _baseService.Insert(entity);

            try
            {
                if (serviceResult.MISACode == MISACode.NotValid)
                {
                    return BadRequest(serviceResult);
                }
                if (serviceResult.MISACode == MISACode.IsValid)
                {
                    return Created("Thêm thành công", entity);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(serviceResult.Messenger = ex.Message);
            }
            
        }

        // PUT api/<BaseEntityController>/5
        /// <summary>
        /// Sửa theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Created BY: DMThanh (08-02-2021)
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]string id,[FromBody] TEntity entity)
        {
            var keyProperty = entity.GetType().GetProperty($"{typeof(TEntity).Name}Id");
            if (keyProperty.PropertyType == typeof(Guid))
            {
                keyProperty.SetValue(entity, Guid.Parse(id));
            }
            else if (keyProperty.PropertyType == typeof(int))
            {
                keyProperty.SetValue(entity, int.Parse(id));
            }
            else
            {
                keyProperty.SetValue(entity, id);
            }

            var serviceResult = _baseService.Update(entity);
            if (serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult);
            }
            else 
            {
                return Created("Sửa thành công", entity);
            }
        }

        // DELETE api/<BaseEntityController>/5
        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Số bản ghi xóa</returns>
        /// Created BY: DMThanh (08-02-2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var res = _baseService.Delete(id);
            return Ok(res);
        }
    }
}
