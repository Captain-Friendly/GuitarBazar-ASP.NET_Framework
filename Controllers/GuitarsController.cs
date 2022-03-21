using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuitarBazar.Models;

namespace GuitarBazar.Controllers
{

    public class GuitarsController : Controller
    {
        private GuitarBazarDBEntities DB = new GuitarBazarDBEntities();
        public ActionResult Index()
        {
            return View(DB.Guitars);
        }
        //private void SetViewBag()
        //{
        //    ViewBag.GuitarConditionNameList = DB.GuitarConditionNameList();
        //    ViewBag.GuitarConditionIdList = DB.GuitarConditionIdList();

        //    ViewBag.GuitarTypeNameList = DB.GuitarTypeNameList();
        //    ViewBag.GuitarTypeIdList = DB.GuitarTypeIdList();

        //    ViewBag.SellerNameList = DB.SellerNameList();
        //    ViewBag.SellerIdList = DB.SellerIdList();

        //    ViewBag.TypeGuitarList = DB.TypeGuitarList();

        //}
        private void SetViewBag()
        {
            ViewBag.Conditions = SelectListItemConverter<Condition>.Convert(DB.Conditions.ToList());
            ViewBag.GuitarTypes = SelectListItemConverter<GuitarType>.Convert(DB.GuitarTypes.ToList());
            ViewBag.Sellers = SelectListItemConverter<Seller>.Convert(DB.Sellers.ToList());
        }


        public ActionResult Create()
        {
            SetViewBag();
            return View(new Guitar());
        }
        [HttpPost]
        public ActionResult Create(Guitar guitar)
        {
            if (ModelState.IsValid)
            {
                DB.AddGuitar(guitar);
            }
            SetViewBag();
            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {
            Guitar guitar = DB.Guitars.Find(id);
            if (guitar != null)
            {
                ViewBag.Conditions = SelectListItemConverter<Condition>.Convert(DB.Conditions.ToList());
                SetViewBag();
                return View(guitar);
            }
            return View(new Guitar());
        }
        [HttpPost]
        public ActionResult Edit(Guitar guitar)
        {
            if (ModelState.IsValid)
            {
                DB.UpdateGuitar(guitar);
            }
            SetViewBag();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Guitar guitar = DB.Guitars.Find(id);
            if (guitar != null)
            {
                return View(guitar);
            }
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            Guitar guitar = DB.Guitars.Find(id);
            if (guitar != null)
            {
                DB.RemoveGuitar(guitar);
            }
            return RedirectToAction("Index");
        }

    }
}