using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BooksWeb.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class //it is a generic repository. In which T is the class to be used (category etc..)
    {
        //T : Category
        IEnumerable<T> GetAll();
        T GetFirstOrDefault(Expression<Func<T, bool>> filter); //this is used to get the details of an article (for edit or details)

        void Add(T entity);
        void Remove(T entity);  
        void RemoveRange(IEnumerable<T> entity);  //to remove more than one entity

    }
}
