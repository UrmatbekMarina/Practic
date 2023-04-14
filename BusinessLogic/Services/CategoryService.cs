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
    public class CategoryService : ICategoryService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public CategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Category>> GetAll()
        {
            return await _repositoryWrapper.Category.FindAll();
        }


        public async Task<Category> GetById(int id)
        {
            var category = await _repositoryWrapper.Category
            .FindByCondition(x => x.Id == id);
            return category.First();
        }
        public async Task Create(Category model)
        {
            await _repositoryWrapper.Category.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Category model)
        {
            _repositoryWrapper.Category.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var category = await _repositoryWrapper.Category
            .FindByCondition(x => x.Id == id);
            _repositoryWrapper.Category.Delete(category.First());
            _repositoryWrapper.Save();
        }
    }
}
