using System;
using System.Collections.Generic;
using System.Text;

namespace OAPoliselo.Domain.Entities
{
    public class Dish : BaseEntity
    {
        public string Description { get; set; }

        public int PeriodId { get; set; }

        public int DishTypeId { get; set; }

        public DishType DishType { get; set; }
        public Period Period { get; set; }
    }
}

