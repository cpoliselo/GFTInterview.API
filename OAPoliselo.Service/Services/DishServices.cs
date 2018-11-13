using OAPoliselo.Domain.Entities;
using OAPoliselo.Domain.Model;
using System.Linq;

namespace OAPoliselo.Service.Services
{
    public class DishServices
    {
        private BaseService<Dish> _dishService = new BaseService<Dish>();
        private BaseService<DishType> _dishTypeService = new BaseService<DishType>();

        public DishModel GetDish(int idPeriod, int idDishType)
        {
            var modelReturn = new DishModel();
            var resultDish = _dishService.Get().Where(x => x.PeriodId == idPeriod && x.DishTypeId == idDishType && x.Active).FirstOrDefault();
            var resultDishType = _dishTypeService.Get(idDishType);

            if (resultDishType == null )
                throw new System.Exception("Dish Type Invalid");

            if (resultDish != null)
            {
                modelReturn.Description = resultDish.Description;
                modelReturn.Order = resultDishType.Order;
                modelReturn.Quantity = 1;
            }
            else
            {
                modelReturn.Description = "error";
                modelReturn.Order = resultDishType.Order;
            }

            return modelReturn;
        }
    }
}
