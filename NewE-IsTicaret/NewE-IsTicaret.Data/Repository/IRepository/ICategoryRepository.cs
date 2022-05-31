using NewE_IsTicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewE_IsTicaret.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
       // IEnumerable<Category> GetAll();
    }
}
