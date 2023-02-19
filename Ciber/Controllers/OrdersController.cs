using Ciber.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Controllers
{
    public class OrdersController : Controller
    {
        // GET: OrdersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private MultiSelectList GetProducts(string[] selectedValues)
        {

            List<Product> Products = new List<Product>()
            {

                new Product() { ProductID = 1, ProductName = "United States 1" },

                new Product() { ProductID = 2, ProductName = "United States 2" },

                new Product() { ProductID = 3, ProductName = "United States 3" },

                new Product() { ProductID = 4, ProductName = "United States 4" },

                new Product() { ProductID = 5, ProductName = "United States 5" },

            };

            return new MultiSelectList(Products, "ProductID", "ProductName", selectedValues);

        }

        public ActionResult MultiSelectCountry()
        {

            ViewBag.ProductList = GetProducts(null);

            return View();

        }
    }
}
