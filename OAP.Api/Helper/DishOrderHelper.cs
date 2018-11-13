using OAPoliselo.Domain.Entities;
using OAPoliselo.Domain.Model;
using OAPoliselo.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OAPoliselo.Api.Helper
{
    public class DishOrderHelper
    {
        private BaseService<Period> _periodService = new BaseService<Period>();
        private DishServices _dishCustomService = new DishServices();

        public List<DishModel> BuildDishModel(string[] array, int periodId)
        {
            var result = new List<DishModel>();

            for (int index = 1; index < array.Length; index++)
            {
                string pin = array[index].Trim();

                var dishReturn = _dishCustomService.GetDish(periodId, Convert.ToInt32(pin));

                if (result.Where(x => x.Description == dishReturn.Description).Any())
                    result.Where(x => x.Description == dishReturn.Description).FirstOrDefault().Quantity++;
                else
                    result.Add(dishReturn);
            }

            return result;
        }

        public string BuildStringReturn(List<DishModel> model)
        {
            var resultString = string.Empty;

            foreach (var item in model.OrderBy(x => x.Order))
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

            return resultString;

        }
    }
}
