using Microsoft.AspNetCore.Mvc;
using NewE_IsTicaret.Data.Repository.IRepository;
using NewE_IsTicaret.Models;
using System.Collections.Generic;

namespace NewE_IsTicaret.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork; //unıtwork aldık enjeksiyonla
       // private IUnitOfWork _IUnitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _unitOfWork.Category.GettAll();
            return View(CategoryList);
        }

        public IActionResult Create()    //KULLANIIC BOŞ SAYFA ALACAK
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();

            }

            var category = _unitOfWork.Category.GetFirstOrderDefault(x=>x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            return View(category);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();

            }

            var category = _unitOfWork.Category.GetFirstOrderDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            return RedirectToAction("Index");

           
        }




    }
}
