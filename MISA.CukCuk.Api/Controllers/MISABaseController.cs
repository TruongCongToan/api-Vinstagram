using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL;
using MISA.BL.Exceptions;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class MISABaseController<MISAEntity> : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
          
            BaseBL<MISAEntity> baseBL = new BaseBL<MISAEntity>();
            var employees = baseBL.GetAll();
            // 4. Kiểm tra dữ liệu và trả về cho Client
            // - Nếu có dữ liệu thì trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (employees.Count() > 0)
            {
                return Ok(employees);
            }
            else
            {
                return NoContent();
            }

        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            BaseBL<MISAEntity> baseBL = new BaseBL<MISAEntity>();
            var customer = baseBL.GetById(id);
            // 4. Trả về cho Client:
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NoContent();
            }
        }


        //POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity entity)
        {
            try
            {

                BaseBL<MISAEntity> baseBL = new BaseBL<MISAEntity>();
                var rowAffects = baseBL.Insert(entity);
                // 4. Trả về cho Client:
                if (rowAffects > 0)
                {
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (GuardException<MISAEntity> ex)
            {
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Dữ liệu không hợp lệ, vui lòng kiểm tra lại!",
                    field = "CustomerCode",
                    data = ex.Data
                };
                return StatusCode(400, mes);
            }
            catch (Exception ex)
            {

                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                    field = "CustomerCode"
                };
                return StatusCode(500, mes);
            }

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] MISAEntity customer)
        {
            BaseBL<MISAEntity> baseBL = new BaseBL<MISAEntity>();
            var res = baseBL.Update(customer, id);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            BaseBL<MISAEntity> baseBL = new BaseBL<MISAEntity>();
            var res = baseBL.Delete(id);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
        }
    }
}

