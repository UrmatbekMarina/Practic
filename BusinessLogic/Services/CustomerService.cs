//using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;
//using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

//using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public CustomerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Customer>> GetAll()
        {
            return await _repositoryWrapper.Customer.FindAll();
        }


        public async Task<Customer> GetById(int id)
        {
            var customer = await _repositoryWrapper.Customer
            .FindByCondition(x => x.Id == id);
            return customer.First();
        }
        public async Task Create(Customer model)
        {
            await _repositoryWrapper.Customer.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Customer model)
        {
            _repositoryWrapper.Customer.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var customer = await _repositoryWrapper.Customer
            .FindByCondition(x => x.Id == id);
            _repositoryWrapper.Customer.Delete(customer.First());
            _repositoryWrapper.Save();
        }
    }
}
