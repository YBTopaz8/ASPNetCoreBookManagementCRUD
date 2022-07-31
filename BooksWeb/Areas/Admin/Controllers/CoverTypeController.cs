using BooksWeb.DataAccess;
using BooksWeb.DataAccess.Repository.IRepository;
using BooksWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll(); //go to db, retrieve all Cat, convert to list and send to list. like in python
            return View(objCoverTypeList);

        }


        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //validate on ALL POST REQUESTS (recommended)
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();

                TempData["success"] = "Cover Created Sucessfully";
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
            var CovertypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);//if more than one element is found, first or default will return the FIRST element and will not throw an exception
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id); // SINGLE OR DEFAULT() WILL THROUGH AN EXCEPTION

            if (CovertypeFromDbFirst == null)
            {
                return NotFound();
            }

            return View(CovertypeFromDbFirst);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //validate on ALL POST REQUESTS (recommended)
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "CoverType Edited Sucessfully";
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
            var CoverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);//if more than one element is found, first or default will return the FIRST element and will not throw an exception
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id); // SINGLE OR DEFAULT() WILL THROUGH AN EXCEPTION

            if (CoverTypeFromDb == null)
            {
                return NotFound();
            }

            return View(CoverTypeFromDb);
        }


        //POST
        [HttpPost /*, ActionName("Delete") THIS IS WHEN YOU WANT TO SPECIFY THE ACTION YOU WANT TO USE*/]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType Deleted Sucessfully";
            return RedirectToAction("Index");


        }
    }
}
