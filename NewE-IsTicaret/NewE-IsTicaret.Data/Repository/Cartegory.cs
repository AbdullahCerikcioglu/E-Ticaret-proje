using NewE_IsTicaret.Data.Repository.IRepository;
using NewE_IsTicaret.Models;

namespace NewE_IsTicaret.Data.Repository
{
    public class Cartegory : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _context;
        public Cartegory(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}