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
    public class CreateManufacturerRequest
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Inn { get; set; }
        public string? Location { get; set; }


    }

}
