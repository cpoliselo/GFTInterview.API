using Microsoft.AspNetCore.Mvc;
using OAPoliselo.Api.Helper;
using OAPoliselo.Domain.Entities;
using OAPoliselo.Service.Services;
using OAPoliselo.Service.Validators;
using System;
using System.Linq;

namespace OAP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishOrderController : ControllerBase
    {
        private BaseService<Dish> _dishService = new BaseService<Dish>();
        //private DishServices _dishCustomService = new DishServices();
        private BaseService<Period> _periodService = new BaseService<Period>();
        private BaseService<SearchLog> _searchLogService = new BaseService<SearchLog>();


        // GET api/values/5
        [HttpGet("{search}")]
        public ActionResult Get(string search, bool insertLog = true)
        {
            try
            {
                var array = search.Split(',');

                //validation
                if (array.Count() < 2)
                    return BadRequest("please enter at least one option");

                //Search Period
                var resultadoPeriod = _periodService.Get().Where(x => x.Name.ToLower() == array[0].ToLower().Trim()).FirstOrDefault();

                if (resultadoPeriod == null)
                    return BadRequest("Period not found");

                var result = new DishOrderHelper().BuildDishModel(array, resultadoPeriod.Id);

                var resultString = new DishOrderHelper().BuildStringReturn(result);

                if (insertLog)
                {
                    var searchLog = new SearchLog() { SearchKey = search, Result = resultString, Active = true, CreatedDate = DateTime.Now };
                    _searchLogService.Post<SearchLogValidators>(searchLog);
                }

                //return new ObjectResult(resultString);
                return Ok(resultString);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
