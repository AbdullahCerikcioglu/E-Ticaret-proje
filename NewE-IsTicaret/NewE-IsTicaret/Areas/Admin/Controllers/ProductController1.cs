using Microsoft.AspNetCore.Mvc;
using NewE_IsTicaret.Data.Repository.IRepository;
using NewE_IsTicaret.Models;
using NewE_IsTicaret.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NewE_IsTicaret.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController1 : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _HostEnvironment;

        public ProductController1(IUnitOfWork unitOfWork,IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _HostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            var productList = _unitOfWork.Product.GettAll();     
            // _unitOfWork.Category.GettAll();
            return View(productList);

           
        }

        //public IActionResult Create()
       // {
       //     return View();
      //  }

      //  [HttpPost]
      //  public IActionResult Create(Product product)
      //  {
       //     _unitOfWork.Product.Add(product);
      //      _unitOfWork.Save();
       //     return RedirectToAction("Index");
       // }

        public IActionResult Crup(int? id)
        {
            ProductVM productVM = new()
            {

                Product = new(),
                CategoryList = _unitOfWork.Category.GettAll().Select(a => new SelectListItem
                {
                    Text  = a.Name,
                    Value = a.Id.ToString(),

                })

            };
            


            if (id == null || id <= 0)
            {
                return View(productVM);
            }

               productVM.Product = _unitOfWork.Product.GetFirstOrderDefault(x => x.Id == id);

            if (productVM.Product == null)
            {
                return View(productVM);
            }

           return View(productVM);
        }

        [HttpPost]
        public IActionResult Crup(ProductVM productVM, IFormFile file)
        {
            string wwwRootPath = _HostEnvironment.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot  = Path.Combine(wwwRootPath,@"img\products"); 
                var extension   = Path.GetExtension(fileName);

                if (productVM.Product.Picture != null)
                {
                    var oldPicPath = Path.Combine(wwwRootPath,productVM.Product.Picture);
                    if (System.IO.File.Exists(oldPicPath))
                    {
                        System.IO.File.Delete(oldPicPath);

                    }

                }

                using (var Filestream = new FileStream(Path.Combine(uploadRoot, fileName + extension),
                      FileMode.Create))
                {
                    file.CopyTo(Filestream);
                }

                productVM.Product.Picture = @"\img/products\" + fileName + extension;


            }

            if (productVM.Product.Id <= 0)
            {
                _unitOfWork.Product.Add(productVM.Product);


            }
            else
            {
                _unitOfWork.Product.Update(productVM.Product);
            }
             
                _unitOfWork.Save();
                return RedirectToAction("Index");

            
          //  return View(productVM);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();

            }

            var Product = _unitOfWork.Product.GetFirstOrderDefault(x=>x.Id == id);

            _unitOfWork.Product.Remove(Product);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

    }
}
