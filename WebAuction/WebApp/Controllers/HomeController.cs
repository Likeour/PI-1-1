using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.DTO;
using WebApp.Models;
using AutoMapper;
using BLL.Infrastructure;


namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

    //    protected override void AutoComponentSetup(ILots lot)
       // {
         //   //Remove this if you want to skip all other previous registrations
           // base.AutoComponentSetup(lot);

            //AutoRegistration<ILots>((loc, type) => loc.Register<ILots>());
        //}

    }
}

