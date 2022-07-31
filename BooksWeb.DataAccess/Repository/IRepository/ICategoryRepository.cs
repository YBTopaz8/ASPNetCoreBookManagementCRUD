using BooksWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWeb.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category> //this is an infant class that will derive methods from IRepository, in the case of Category only
    {
        void Update(Category obj);
        
    }
}
