using Microsoft.EntityFrameworkCore;
using NewE_IsTicaret.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NewE_IsTicaret.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class  // bu satırda Irepositoryden kalıtım alıyoruz
    {

        // DBcontext bağlamamız gerekiyor add set get gibi işlemler yapabilelim 

        private readonly ApplicationDbContext _context;   // sadece bu sınıf içerisinde kullanmak için context yapısını oluşturduk
        internal DbSet<T> _dbSet;
        private object query;

        public Repository(ApplicationDbContext context)   // dependency injection gercekleşmesi ve appiıcation db context alabilmek için ctor(contsractor) oluşturduk 
        {
            _context = context;
            _dbSet =_context.Set<T>(); 

        }
        public void Add(T entity)
        {
            _dbSet.Add (entity);
        }

        public T GetFirstOrderDefault(Expression<Func<T, bool>> filter, string? Includeproperties = null)
        {
            IQueryable<T> Query = _dbSet;
            if (filter != null)
            {
                Query = Query.Where(filter);
            }
            if (Includeproperties != null)
            {
                foreach (var item in Includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(item);
                }


            }
            return Query.FirstOrDefault();  // tek kayıt sorgusu olduğu için FirstOrDefault dedik
        }

        public IEnumerable<T> GettAll(Expression<Func<T, bool>> filter, string? Includeproperties = null)
        {
            IQueryable<T> Query = _dbSet;
            if (filter != null )
            {
                Query = Query.Where (filter);
            }
            if (Includeproperties != null )
            {
                foreach (var item in Includeproperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)) 
                {
                   Query= Query.Include(item);
                }
               

            }
            return Query.ToList(); // coklu  kayıt sorgusu olduğu için list dedik
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet. RemoveRange(entities);
        }

        public void Update(T entiy)
        {
            _dbSet.Update(entiy);
        }
    }
}
