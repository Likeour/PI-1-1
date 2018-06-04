using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
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
    public class CategoriesController : Controller
    {
        ILots LotsService;

        IMapper CategoryControllerMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CategorieDTO, CategoryViewModel>();
            cfg.CreateMap<LotPostDTO, LotViewModel>();
            cfg.CreateMap<CategoryViewModel, CategorieDTO>();
            cfg.CreateMap<LotViewModel, LotPostDTO>();
        }).CreateMapper();

        public CategoriesController()
        {
            LotsService = UIDependencyResolver<ILots>.ResolveDependency();
        }

        public CategoriesController(ILots LotsService)
        {
            this.LotsService = LotsService;
        }

       
      
        // GET api/<controller>
  

        // GET api/<controller>/5
        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            return CategoryControllerMapper.Map<IEnumerable<CategorieDTO>, IEnumerable<CategoryViewModel>>(LotsService.GetAllCategories());
        }

        // POST api/<controller>

        public void Post([FromBody]CategoryViewModel Category)
        {
            LotsService.AddCategory(CategoryControllerMapper.Map<CategoryViewModel, CategorieDTO>(Category));
        }

        // PUT api/<controller>/5
        public void Put(int Category, [FromBody]LotViewModel Lot)
        {
            LotsService.AddLot(Category, CategoryControllerMapper.Map<LotViewModel, LotPostDTO>(Lot));
        }

        // DELETE api/<controller>/5
        public void Delete(int Id)
        {
            LotsService.DeleteLot(Id);
        }
    }
}