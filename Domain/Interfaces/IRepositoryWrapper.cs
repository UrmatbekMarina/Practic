using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ICategoryRepository Category { get; }

        ICustomerRepository Customer { get; }
        IDeliveryRepository Delivery { get; }
        IGoodRepository Good { get; }
        IManufacturerRepository Manufacturer { get; }

        Task Save();
    }
}
