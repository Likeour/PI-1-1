﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace WebAuction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult Login()
       {
            return View();
       }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult PageAuction()
        {
            return View();
        }
    }
}