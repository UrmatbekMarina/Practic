using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Goods = new HashSet<Good>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
