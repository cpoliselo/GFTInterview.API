using OAPoliselo.Domain.Entities;
using OAPoliselo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAPoliselo.Infra.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SqlContext context)
        {

            if (context.Dish.Any())
            {
                return;
            }

            var dishTypes = new DishType[]
           {
                new DishType {
                    Name = "entree",
                    CreatedDate = System.DateTime.Now,
                    Order = 1,
                    Active = true
                },

                new DishType {
                    Name = "side",
                    CreatedDate = System.DateTime.Now,
                    Order = 2,
                    Active = true
                },
                new DishType {
                    Name = "drink",
                    CreatedDate = System.DateTime.Now,                    
                    Order = 3,
                    Active = true
                },
                new DishType {
                    Name = "dessert",
                    CreatedDate = System.DateTime.Now,                    
                    Order = 4,
                    Active = true
                }
           };

            context.AddRange(dishTypes);

            var periods = new Period[]
           {
                new Period {
                    Name = "morning",
                    CreatedDate = System.DateTime.Now,
                    Active = true
                },
                new Period {
                    Name = "night",
                    CreatedDate = System.DateTime.Now,
                    Active = true
                }
           };

            context.AddRange(periods);

            var dishes = new Dish[]
           {
                new Dish {
                    Description = "eggs",
                    Period = periods.Where(x=>x.Name=="morning").FirstOrDefault(),
                    DishType = dishTypes.Where(x=>x.Name=="entree").FirstOrDefault(),
                    CreatedDate = System.DateTime.Now,
                    Active = true
                },
                new Dish {
                    Description = "Toast",
                    Period = periods.Where(x=>x.Name=="morning").FirstOrDefault(),
                    DishType = dishTypes.Where(x=>x.Name=="side").FirstOrDefault(),
                    CreatedDate = System.DateTime.Now,
                    Active = true
                },
                new Dish {
                    Description = "coffee",
                    Period = periods.Where(x=>x.Name=="morning").FirstOrDefault(),
                    DishType = dishTypes.Where(x=>x.Name=="drink").FirstOrDefault(),
                    CreatedDate = System.DateTime.Now,
                    Active = true
                },
                 new Dish {
                    Description = "steak",
                    Period = periods.Where(x=>x.Name=="night").FirstOrDefault(),
                    DishType = dishTypes.Where(x=>x.Name=="entree").FirstOrDefault(),
                    CreatedDate = System.DateTime.Now,
                    Active = true
                },
                  new Dish {
                    Description = "potato",
                    Period = periods.Where(x=>x.Name=="night").FirstOrDefault(),
                    DishType = dishTypes.Where(x=>x.Name=="side").FirstOrDefault(),
                    CreatedDate = System.DateTime.Now,
                    Active = true
                },
                   new Dish {
                    Description = "wine",
                    Period = periods.Where(x=>x.Name=="night").FirstOrDefault(),
                    DishType = dishTypes.Where(x=>x.Name=="drink").FirstOrDefault(),
                    CreatedDate = System.DateTime.Now,
                    Active = true
                },
                    new Dish {
                    Description = "cake",
                    Period = periods.Where(x=>x.Name=="night").FirstOrDefault(),
                    DishType = dishTypes.Where(x=>x.Name=="dessert").FirstOrDefault(),
                    CreatedDate = System.DateTime.Now,
                    Active = true
                }
           };


            context.AddRange(dishes);
            context.SaveChanges();
        }
    }
}
