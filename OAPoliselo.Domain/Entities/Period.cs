using System;
using System.Collections.Generic;
using System.Text;

namespace OAPoliselo.Domain.Entities
{
    public class Period : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Dish> Dishes { get; set; }

    }
}

