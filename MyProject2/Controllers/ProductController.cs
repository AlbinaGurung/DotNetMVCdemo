using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject2.Data;
using MyProject2.Models;
using MyProject2.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MyProject2.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        readonly List<Product> ProductList = new(){
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


        public async Task<IActionResult> Index(string? search = null)
        {
            var products = new ProductSearchVm();
          
            if (!String.IsNullOrEmpty(search))
            {
                products.data= await _context.Units.Where(x => x.Name.Contains(search)).ToListAsync();
            }
            else
            {
                products.data = await _context.Units.ToListAsync();
            }
            return View(products);
        }
        public  IActionResult Add()

        {
           

            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddVm vm)
        {

            /*  try
              {
                  if ((vm.Price!=null) && !String.IsNullOrEmpty(vm.Name))
                  {
                      Product2 item = new()
                      {
                          Id =vm.Id,
                          Price=vm.Price,
                          Name=vm.Name
                      };

                      _context.Units?.Add(item);
                      await _context.SaveChangesAsync();
                      return RedirectToAction("Index");
                  }
                  else
                  {

                      throw new Exception("NULL");
                  }
              }
              catch(Exception ex)
              {
                  return View("Error");
              }*/
            try
            {
             
                    Product2 item = new()
                    {
                        
                        Price=vm.Price,
                        Name=vm.Name
                    };

                    _context.Units?.Add(item);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
               
            }
            catch (Exception ex)
            {
                return View("Error");
            }



        }
        
        public IActionResult Edit(int id)
        {
            //searching for the item in databse whose id is equal to the id passed from the page
            var item=_context.Units.Where(x => x.Id == id).FirstOrDefault();
            try 
            {
                if (item==null)
                {
                    throw new Exception("Item Not Found");
                }
                //giving that found item to the view model to display it to the page
                var vm = new ProductEditVm() { Name=item.Name ,Price=item.Price};
                
                
                return View(vm);
            }
            catch (Exception )
            {
                RedirectToAction("Index");
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductEditVm vm)
        {
            var item= _context.Units.FirstOrDefault(x => x.Id==id);
           
            try
            {
                if (item==null)
                {
                    throw new Exception("Item Not Found");
                }


                item.Name=vm.Name;
                item.Price=vm.Price;

                _context.Units.Update(item);
                await _context.SaveChangesAsync();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
                
            }

            catch (Exception e)
            {
                RedirectToAction("Index"+e);
            }
                return View();
        }

         


    }
}
