using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokYtube.Models.Entity;

namespace MvcStokYtube.Controllers
{
    public class UrunController : Controller
    {
        MvcDbStokEntities db= new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler=db.TBLURUNLER.ToList();
            return View(degerler);
        }

        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER urn)
        {
            var ktgr= db.TBLKATEGORILER.Where(m=> m.KATEGORIID==urn.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urn.TBLKATEGORILER = ktgr;
            db.TBLURUNLER.Add(urn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text=i.KATEGORIAD,
                                                 Value=i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr=degerler;
            return View();
        }

        public ActionResult Sil(int id)
        {
            var deger = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}