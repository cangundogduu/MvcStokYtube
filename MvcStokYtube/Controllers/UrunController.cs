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
            db.TBLURUNLER.Add(urn);
            db.SaveChanges();
            return View();
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
    }
}