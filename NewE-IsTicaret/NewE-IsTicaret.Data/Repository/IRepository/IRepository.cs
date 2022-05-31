using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewE_IsTicaret.Data.Repository.IRepository
{ // buradaki T  buraya gelecek olan modeldekileri temsil ederek kullanabilmemizi sağlar
    
    public interface IRepository<T> where T : class
    {
        // link sorgusunu alabilmemiz için Expression kullandık gelen modeli bool olarak döndür ismini standart olarakta filter verdik
        T GetFirstOrderDefault(Expression<Func<T,bool>>? filter=null,
           string? Includeproperties = null);  // burada tek bir kayıt almamızı sağlar
        IEnumerable<T> GettAll(Expression<Func<T, bool>>? filter=null,
           string? Includeproperties = null);  // 
        void Update(T entity);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
