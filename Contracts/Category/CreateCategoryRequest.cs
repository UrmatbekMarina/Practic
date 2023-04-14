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
    public class CreateCategoryRequest
    {


        public string CategoryName { get; set; } = null!;
        public int? GoodsId { get; set; }

    }

}
