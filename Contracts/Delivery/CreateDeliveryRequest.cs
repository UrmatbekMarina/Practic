using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Models;
using Domain.Interfaces;


namespace BackendAPI.Contracts
{
    public class CreatDeliveryRequest
    {

        
        public string DeliveryStatus { get; set; } = null!;
        public int? DeliveryPrice { get; set; }
        public int? UserId { get; set; }
        public int? GoodsId { get; set; }

    }

}
