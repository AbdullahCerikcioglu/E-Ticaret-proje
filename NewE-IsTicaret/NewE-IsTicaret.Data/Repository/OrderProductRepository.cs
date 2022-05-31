using NewE_IsTicaret.Data.Repository.IRepository;
using NewE_IsTicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewE_IsTicaret.Data.Repository
{
    public class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
    {
        private ApplicationDbContext _context;
        public OrderProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context; 
        }
    }
}
