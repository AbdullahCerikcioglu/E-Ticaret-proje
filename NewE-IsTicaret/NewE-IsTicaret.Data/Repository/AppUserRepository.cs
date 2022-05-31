using NewE_IsTicaret.Data.Repository.IRepository;
using NewE_IsTicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewE_IsTicaret.Data.Repository
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {

        private ApplicationDbContext _context;
        public AppUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
