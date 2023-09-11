using Microsoft.AspNetCore.Mvc;
using MyProject2.Models;
using MyProject2.ViewModels;

namespace MyProject2.Controllers
{
    public class ProductController : Controller
    {



        List<Product> ProductList = new List<Product>(){
            new Product()
            {
                ProductName = "Sprite",
                ProductId = 1,
                ProductDescription = "drinks",
                Price = 500
            },
            new Product()
            {
                ProductName = "Coke",
                ProductId = 2,
                ProductDescription = "drinks",
                Price = 200
            },
            new Product()
            {
                ProductName = "Fanta",
                ProductId = 3,
                ProductDescription = "drinks",
                Price = 300
            },
          };


        public IActionResult Index(string? search = null)
        {
            var products = new List<Product>();
            if (!String.IsNullOrEmpty(search))
            {
                products = ProductList.Where(x => x.ProductName.Contains(search)).ToList();
            }
            else
            {
                products = ProductList.ToList();
            }
            return View(products);
        }
        public  IActionResult add()
        {

            return View();
        }
        
        public IActionResult Edit(int id)
        {
            //searching for the item in databse whose id is equal to the id passed from the page
            var item=ProductList.Where(x => x.ProductId == id).FirstOrDefault();
            try 
            {
                if (item==null)
                {
                    throw new Exception("Item Not Found");
                }
                //giving that found item to the view model to display it to the page
                var vm = new ProductEditVm();
                vm.ProductName=item.ProductName;
                vm.Price=item.Price;
                vm.ProductDescription=item.ProductDescription;
                return View(vm);
            }
            catch (Exception )
            {
                RedirectToAction("Index");
            }
            return View();

        }
        [HttpPost]
        public IActionResult Edit(int id, ProductEditVm vm)
        {
            var item = ProductList.Where(x => x.ProductId==id).FirstOrDefault();
            try
            {
                if (item==null)
                {
                    throw new Exception("Item Not Found");
                }


                item.ProductName=vm.ProductName;

                return RedirectToAction("Index");
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }
            }

            catch (Exception e)
            {
                RedirectToAction("Index");
            }
                return View();
        }

         


    }
}
