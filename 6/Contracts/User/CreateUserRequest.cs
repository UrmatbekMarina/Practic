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


namespace BackendAPI.Contracts.User
{
    public class CreateUserRequest
    {
        
        public string UserName { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string UserAddress { get; set; } = null!;

    }

}
