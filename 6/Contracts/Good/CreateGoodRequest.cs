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
    public class CreateGoodRequest
    {

       
        public string? Name { get; set; }
        public int? CustomerId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? Value { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }

    }

}
