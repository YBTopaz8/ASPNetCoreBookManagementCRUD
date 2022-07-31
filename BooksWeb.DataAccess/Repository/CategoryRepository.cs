using BooksWeb.DataAccess.Repository.IRepository;
using BooksWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWeb.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDBContext _db;

        public CategoryRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;   
        }


        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
