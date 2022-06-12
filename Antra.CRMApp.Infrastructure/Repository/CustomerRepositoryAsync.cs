using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Repository
{
    public class CustomerRepositoryAsync : BaseRepository<Customer>, ICustomerRepositoryAsync
    {
        private readonly CrmDbContext _context;
        public CustomerRepositoryAsync(CrmDbContext _dbContext) : base(_dbContext)
        {
            _context = _dbContext;
        }
    

    }
}
