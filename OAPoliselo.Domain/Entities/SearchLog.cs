using System;
using System.Collections.Generic;
using System.Text;

namespace OAPoliselo.Domain.Entities
{
    public class SearchLog : BaseEntity
    {
        public string SearchKey { get; set; }
        public string Result { get; set; }

    }
}

