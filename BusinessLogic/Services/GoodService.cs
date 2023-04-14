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
    public class GoodService : IGoodService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public GoodService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Good>> GetAll()
        {
            return await _repositoryWrapper.Good.FindAll();
        }


        public async Task<Good> GetById(int id)
        {
            var good = await _repositoryWrapper.Good
            .FindByCondition(x => x.Id == id);
            return good.First();
        }
        public async Task Create(Good model)
        {
            await _repositoryWrapper.Good.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Good model)
        {
            _repositoryWrapper.Good.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var good = await _repositoryWrapper.Good
            .FindByCondition(x => x.Id == id);
            _repositoryWrapper.Good.Delete(good.First());
            _repositoryWrapper.Save();
        }
    }
}
