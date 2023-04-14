//using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using DataAccess.Models;
//using Domain.Interfaces;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private KIContext _repoContext;
        private IUserRepository _user;
        private IDeliveryRepository _delivery;
        private ICategoryRepository _category;
        private ICustomerRepository _customer;
        private IGoodRepository _good;
        private IManufacturerRepository _manufacturer;
        public IManufacturerRepository Manufacturer
        {
            get
            {
                if (_manufacturer == null)
                {
                    _manufacturer = new ManufacturerRepository(_repoContext);
                }
                return _manufacturer;
            }
        }
        public IGoodRepository Good
        {
            get
            {
                if (_good == null)
                {
                    _good = new GoodRepository(_repoContext);
                }
                return _good;
            }
        }
        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_repoContext);
                }
                return _customer;
            }
        }
        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }
                return _category;
            }
        }
        public IDeliveryRepository Delivery
        {
            get
            {
                if (_delivery == null)
                {
                    _delivery = new DeliveryRepository(_repoContext);

                }
                return _delivery;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
        public RepositoryWrapper(KIContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
