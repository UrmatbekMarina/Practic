using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Delivery
    {
        public int Id { get; set; }
        public string DeliveryStatus { get; set; } = null!;
        public int? DeliveryPrice { get; set; }
        public int? UserId { get; set; }
        public int? GoodsId { get; set; }

        public virtual Good? Goods { get; set; }
        public virtual User? User { get; set; }
    }
}
