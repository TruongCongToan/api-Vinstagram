
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using MySqlConnector;
using MISA.BL;
using MISA.Common.Entities;
using MISA.BL.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]

    public class searchController : ControllerBase
    {
        [HttpGet("search")]
        public IActionResult Getsearch(string m_input)
        {
            UserBL userBL = new UserBL();
            var employees = userBL.Search<User>(m_input);

            if (employees.Count() > 0)
            {
                return Ok(employees);
            }
            else
            {
                return NoContent();
            }
        }
    }
}

