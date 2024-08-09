﻿using BookShop.DataAccess.Data;
using BookShop.DataAccess.Repository;
using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookShop.Models.ViewModels;


namespace MyBookShop.Areas.Admin.Controllers
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
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();

            return View(objProductList);
        }

        public IActionResult Create()
        {
             
           
            ProductVM productVM = new ProductVM()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name, //press F12 on the SelectListItem to see the properties and we see that
                                   //we continue with name and text properties
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };


            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductVM   obj)
        {
     

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj.Product );
                _unitOfWork.Save();
                TempData["success"] = "Product Added Successfully"; //this is a key value pair, key is Success and value is Product Added Successfully
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product productFromDb = _unitOfWork.Product.Get(u => u.Id == id); //find the Product by id, it finds it with primary key	
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {


            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id); //find the Product by id, it finds it with primary key	
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            Product obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product Deleted Successfully";
            return RedirectToAction("Index");


        }

    }
}
