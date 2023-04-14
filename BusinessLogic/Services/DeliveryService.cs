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
    public class DeliveryService : IDeliveryService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public DeliveryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Delivery>> GetAll()
        {
            return await _repositoryWrapper.Delivery.FindAll();
        }


        public async Task<Delivery> GetById(int id)
        {
            var delivery = await _repositoryWrapper.Delivery
            .FindByCondition(x => x.Id == id);
            return delivery.First();
        }
        public async Task Create(Delivery model)
        {
            await _repositoryWrapper.Delivery.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Delivery model)
        {
            _repositoryWrapper.Delivery.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var delivery = await _repositoryWrapper.Delivery
            .FindByCondition(x => x.Id == id);
            _repositoryWrapper.Delivery.Delete(delivery.First());
            _repositoryWrapper.Save();
        }
    }
}
