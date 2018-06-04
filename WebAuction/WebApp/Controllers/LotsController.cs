using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections;
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

        public IEnumerable<CategoryViewModel> Get()
        {
            return LotsControllerMapper.Map<IEnumerable<CategorieDTO>, IEnumerable<CategoryViewModel>>(LotsService.GetAllCategories());
        }

        // GET api/<controller>/5
        public LotViewModel Get(int Id)
        {
            return LotsControllerMapper.Map<LotPostDTO, LotViewModel>(LotsService.GetLot(Id));
        }

        // POST api/<controller>

        public void Post([FromBody]CategoryViewModel Category)
        {
            LotsService.AddCategory(LotsControllerMapper.Map<CategoryViewModel, CategorieDTO>(Category));
        }

        // PUT api/<controller>/5
        public void Put(int CategoryId, [FromBody]LotViewModel Lot)
        {
            LotsService.AddLot(CategoryId, LotsControllerMapper.Map<LotViewModel, LotPostDTO>(Lot));
        }

        // DELETE api/<controller>/5
        public void Delete(int Id)
        {
            LotsService.DeleteLot(Id);
        }

    }
}