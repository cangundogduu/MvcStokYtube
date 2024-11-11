using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokYtube.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStokYtube.Controllers
{
    public class UrunController : Controller
    {
        MvcDbStokEntities db= new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            var degerler=db.TBLURUNLER.ToList().ToPagedList(sayfa,4);
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

        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("UrunGetir",urun);
        }

        public ActionResult Guncelle(TBLURUNLER urn)
        {
            var urun = db.TBLURUNLER.Find(urn.URUNID);
            urun.URUNAD = urn.URUNAD;
            urun.MARKA = urn.MARKA;
            //urun.UNURKATEGORI = urn.UNURKATEGORI;
            var ktgr = db.TBLKATEGORILER.Where(m => m.KATEGORIID == urn.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.UNURKATEGORI = ktgr.KATEGORIID;
            urn.TBLKATEGORILER = ktgr;
            urun.FIYAT=urn.FIYAT;
            urun.STOK = urn.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}