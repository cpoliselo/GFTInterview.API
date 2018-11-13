using System;
using System.Collections.Generic;
using System.Text;

namespace OAPoliselo.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual bool Active { get; set; }
    }
}