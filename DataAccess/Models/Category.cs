using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public int? GoodsId { get; set; }

        public virtual Good? Goods { get; set; }
    }
}
