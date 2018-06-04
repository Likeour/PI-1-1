using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Ninject;

namespace WebApp.Controllers
{
    public class LotsController : Controller
    {
        ILots LotsService;

        IMapper LotsControllerMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CategorieDTO, CategoryViewModel>();
            cfg.CreateMap<LotPostDTO, LotViewModel>();
            cfg.CreateMap<CategoryViewModel, CategorieDTO>();
            cfg.CreateMap<LotViewModel, LotPostDTO>();
        }).CreateMapper();

        public LotsController()
        {
            LotsService = UIDependencyResolver<ILots>.ResolveDependency();
        }

        public LotsController(ILots LotsService)
        {
            this.LotsService = LotsService;
        }
        
        public ActionResult Index()
        {

            IEnumerable<CategorieDTO> cat = LotsControllerMapper.Map<CategorieDTO, CategoryViewModel>(LotsService.GetAllCategories());
            return View(cat);
            
        }

        public IEnumerable<CategoryViewModel> Get()
        {
            return LotsControllerMapper.Map<IEnumerable<CategorieDTO>, IEnumerable<CategoryViewModel>>(LotsService.GetAllLots());
        }
    }
}