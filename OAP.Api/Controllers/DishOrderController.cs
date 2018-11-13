using Microsoft.AspNetCore.Mvc;
using OAPoliselo.Domain.Entities;
using OAPoliselo.Domain.Model;
using OAPoliselo.Service.Services;
using OAPoliselo.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OAP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishOrderController : ControllerBase
    {
        private BaseService<Dish> _dishService = new BaseService<Dish>();
        private DishServices _dishCustomService = new DishServices();
        private BaseService<Period> _periodService = new BaseService<Period>();
        private BaseService<SearchLog> _searchLogService = new BaseService<SearchLog>();


        // GET api/values/5
        [HttpGet("{search}")]
        public ActionResult Get(string search, bool insertLog = true)
        {
            try
            {
                var result = new List<DishModel>();
                var array = search.Split(',');

                //validation
                if (array.Count() < 2)
                    return BadRequest("please enter at least one option");


                //Search Period
                var resultadoPeriod = _periodService.Get().Where(x => x.Name.ToLower() == array[0].ToLower().Trim()).FirstOrDefault();

                if (resultadoPeriod == null)
                    return BadRequest("Period not found");

                for (int index = 1; index < array.Length; index++)
                {
                    string pin = array[index].Trim();

                    var dishReturn = _dishCustomService.GetDish(resultadoPeriod.Id, Convert.ToInt32(pin));

                    if (result.Where(x => x.Description == dishReturn.Description).Any())
                        result.Where(x => x.Description == dishReturn.Description).FirstOrDefault().Quantity++;
                    else
                        result.Add(dishReturn);
                }

                var resultString = string.Empty;

                foreach (var item in result.OrderBy(x => x.Order))
                {
                    if (resultString == string.Empty)
                    {
                        if (item.Quantity > 1 && (item.Description == "coffe" || item.Description == "potato"))
                            resultString += item.Description + "(x" + item.Quantity.ToString() + ")";
                        else
                            resultString += item.Description;
                    }
                    else
                    {
                        if (item.Quantity > 1 && (item.Description == "coffee" || item.Description == "potato"))
                            resultString += ", " + item.Description + "(x" + item.Quantity.ToString() + ")";
                        else
                            resultString += ", " + item.Description;
                    }
                }

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
