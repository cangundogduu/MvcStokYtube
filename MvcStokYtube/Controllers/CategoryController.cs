using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokYtube.Models.Entity;

namespace MvcStokYtube.Controllers
{
    public class CategoryController : Controller
    {
        
        MvcDbStokEntities db=new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler=db.TBLKATEGORILER.ToList();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult NewCategory() 
        {
        return View();  
        }
        
        [HttpPost]
        public ActionResult NewCategory(TBLKATEGORILER ktgr) 
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");

            }
            db.TBLKATEGORILER.Add(ktgr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id) 
        {
            var deger= db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir",ktgr);
        }

        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var ktg= db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD=p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}