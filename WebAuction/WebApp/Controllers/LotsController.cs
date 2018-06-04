using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
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



       
        // GET api/<controller>
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        */
        // POST api/<controller>
        public void Post([FromBody]LotViewModel Lot)
        {
            int CategotyId = Lot.CategoryId;
            Lot.CategoryId = new int();
            LotsService.AddLot(CategotyId, LotsControllerMapper.Map<LotViewModel, LotPostDTO>(Lot));
        }
        public IEnumerable<LotViewModel> GetLots()
        {
            return LotsControllerMapper.Map<IEnumerable<LotPostDTO>, IEnumerable<LotViewModel>>(LotsService.GetAllLots());
        }
        public LotViewModel Get(int Id)
        {
            return LotsControllerMapper.Map<LotPostDTO, LotViewModel>(LotsService.GetLot(Id));
        }


    }
}