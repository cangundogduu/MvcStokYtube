﻿using System;
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
            db.TBLKATEGORILER.Add(ktgr);
            db.SaveChanges();
            return View();
        }
    }
}