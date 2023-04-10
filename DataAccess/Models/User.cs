using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string UserAddress { get; set; } = null!;

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
