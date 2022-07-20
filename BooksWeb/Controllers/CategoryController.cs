using BooksWeb.Data;
using BooksWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db) //this will have implementation of connection strings
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories; //go to db, retrieve all Cat, convert to list and send to list. like in python
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //validate on ALL POST REQUESTS (recommended)
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);//if more than one element is found, first or default will return the FIRST element and will not throw an exception
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id); // SINGLE OR DEFAULT() WILL THROUGH AN EXCEPTION

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
       

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //validate on ALL POST REQUESTS (recommended)
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Edited Sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        //GET
        public IActionResult Delete(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);//if more than one element is found, first or default will return the FIRST element and will not throw an exception
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id); // SINGLE OR DEFAULT() WILL THROUGH AN EXCEPTION

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
       

        //POST
        [HttpPost /*, ActionName("Delete") THIS IS WHEN YOU WANT TO SPECIFY THE ACTION YOU WANT TO USE*/]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Sucessfully";
            return RedirectToAction("Index");
            
            return View(obj);
        }
    }
}
