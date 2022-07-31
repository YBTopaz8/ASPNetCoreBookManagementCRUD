using BooksWeb.DataAccess;
using BooksWeb.DataAccess.Repository.IRepository;
using BooksWeb.Models;
using BooksWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _unitOfWork.Product.GetAll(); //go to db, retrieve all Cat, convert to list and send to list. like in python
            return View(objProductList);

        }

        //GET
        public IActionResult Upsert(int? id) //this handles create and update pdt
        {
            ProductViewModel prod = new()
            {
                product = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(
                                u => new SelectListItem
                                {
                                    Text = u.CategoryName,
                                    Value = u.Id.ToString()
                                }),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
                                u => new SelectListItem
                                {
                                    Text = u.Name,
                                    Value = u.Id.ToString()
                                })
            };

            if (id == null || id == 0)
            {
                //create Product
                
                return View(prod); //this is a tightly binded view Ideal way
            }
            else
            {
                //Update Product
            }
            
            return View(prod);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //validate on ALL POST REQUESTS (recommended)
        public IActionResult Upsert(ProductViewModel obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
               // _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Edited Sucessfully";
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
            var ProductFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);//if more than one element is found, first or default will return the FIRST element and will not throw an exception
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id); // SINGLE OR DEFAULT() WILL THROUGH AN EXCEPTION

            if (ProductFromDb == null)
            {
                return NotFound();
            }

            return View(ProductFromDb);
        }


        //POST
        [HttpPost /*, ActionName("Delete") THIS IS WHEN YOU WANT TO SPECIFY THE ACTION YOU WANT TO USE*/]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product Deleted Sucessfully";
            return RedirectToAction("Index");


        }
    }
}
