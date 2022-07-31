using BooksWeb.DataAccess;
using BooksWeb.DataAccess.Repository.IRepository;
using BooksWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork) //this will have implementation of connection strings
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll(); //go to db, retrieve all Cat, convert to list and send to list. like in python
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();

                TempData["success"] = "Category Created Sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);//if more than one element is found, first or default will return the FIRST element and will not throw an exception
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id); // SINGLE OR DEFAULT() WILL THROUGH AN EXCEPTION

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFromDbFirst);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //validate on ALL POST REQUESTS (recommended)
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Edited Sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
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
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Sucessfully";
            return RedirectToAction("Index");


        }
    }
}
