using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    internal class RepositoryWrapper:IRepositoryWrapper
    {
        private KITSUNEEContext _repoContext;

        public RepositoryWrapper(KITSUNEEContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
