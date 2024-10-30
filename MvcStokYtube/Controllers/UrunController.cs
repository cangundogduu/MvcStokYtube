﻿using System;
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
    }
}