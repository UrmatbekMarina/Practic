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
    public class ManufacturerService : IManufacturerService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public ManufacturerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Manufacturer>> GetAll()
        {
            return await _repositoryWrapper.Manufacturer.FindAll();
        }


        public async Task<Manufacturer> GetById(int id)
        {
            var manufacturer = await _repositoryWrapper.Manufacturer
            .FindByCondition(x => x.Id == id);
            return manufacturer.First();
        }
        public async Task Create(Manufacturer model)
        {
            await _repositoryWrapper.Manufacturer.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Manufacturer model)
        {
            _repositoryWrapper.Manufacturer.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var manufacturer = await _repositoryWrapper.Manufacturer
            .FindByCondition(x => x.Id == id);
            _repositoryWrapper.Manufacturer.Delete(manufacturer.First());
            _repositoryWrapper.Save();
        }
    }
}
