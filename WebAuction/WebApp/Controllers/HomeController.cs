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
        ILots lotsService;

        public HomeController(ILots serv)
        {
            lotsService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<LotPostDTO> lotsDtos = lotsService.GetLots();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotPostDTO, LotViewModel>()).CreateMapper();
            var lots = mapper.Map<IEnumerable<LotPostDTO>, List<LotViewModel>>(lotsDtos);
            return View(lots);
        }

    }
}

