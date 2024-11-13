using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokYtube.Models.Entity;

namespace MvcStokYtube.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db= new MvcDbStokEntities();
        public ActionResult Index(String p)
        {
            var degerler = from d in db.TBLMUSTERILER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler=degerler.Where(m=>m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLMUSTERILER.ToList();
            //return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }

            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();  
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var deger= db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id) 
        {
            var mstr = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir",mstr);
        
        }

        public ActionResult Guncelle(TBLMUSTERILER mstr)
        {
            var musteri = db.TBLMUSTERILER.Find(mstr.MUSTERIID);
            musteri.MUSTERIAD=mstr.MUSTERIAD;
            musteri.MUSTERISOYAD=mstr.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}