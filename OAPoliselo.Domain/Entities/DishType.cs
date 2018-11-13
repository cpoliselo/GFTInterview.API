using System;
using System.Collections.Generic;
using System.Text;

namespace OAPoliselo.Domain.Entities
{
    public class DishType : BaseEntity
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public ICollection<Dish> Dishes { get; set; }

    }
}

