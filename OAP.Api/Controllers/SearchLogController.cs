using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OAPoliselo.Domain.Entities;
using OAPoliselo.Service.Services;
using System;
using System.Collections.Generic;

namespace OAP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class SearchLogController : ControllerBase
    {
        private BaseService<SearchLog> _searchLogService = new BaseService<SearchLog>();

        public ActionResult Get()
        {
            try
            {
                var result = _searchLogService.Get();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("Log Empty");
            }
        }

    }
}
