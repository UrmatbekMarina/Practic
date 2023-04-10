using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Good
    {
        public Good()
        {
            Categories = new HashSet<Category>();
            Deliveries = new HashSet<Delivery>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CustomerId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? Value { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Manufacturer? Manufacturer { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
