using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGoodService
    {
        Task<List<Good>> GetAll();
        Task<Good> GetById(int id);
        Task Create(Good model);
        Task Update(Good model);
        Task Delete(int id);


    }
}
