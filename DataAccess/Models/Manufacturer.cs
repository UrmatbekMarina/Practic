using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Goods = new HashSet<Good>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Inn { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
