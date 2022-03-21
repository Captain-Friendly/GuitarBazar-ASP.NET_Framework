using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuitarBazar.Models;


namespace GuitarBazar.Controllers
{
    public class SellersController : Controller
    {
        private GuitarBazarDBEntities DB = new GuitarBazarDBEntities();
        // GET: Makers
        public ActionResult Index()
        {
            return View(DB.Sellers);
        }

        public ActionResult Create()
        {
            return View(new Seller());
        }

        [HttpPost]
        public ActionResult Create(Seller seller)
        {
            if (ModelState.IsValid)
            {
                DB.addSeller(seller);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Seller seller = DB.Sellers.Find(id);
            if (seller != null)
            {
                return View(seller);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Seller seller)
        {
            if (ModelState.IsValid)
            {
                DB.UpdateSeller(seller);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Seller seller = DB.Sellers.Find(id);
            if (seller != null)
            {
                return View(seller);
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult SellerForm(Seller seller)
        {
            if (seller != null)
            {
                return PartialView(seller);
            }
            return null;
        }
        public ActionResult Delete(int id)
        {
            Seller seller = DB.Sellers.Find(id);
            if (seller != null)
            {
                DB.RemoveSeller(seller);
            }
            return RedirectToAction("Index");
        }
    }
}