using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Ninject;
using DAL.Entities;
using DAL.Entities.Catigories;
using DAL.Entities.LotPostManagement;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class LotsService : ILots
    {
        IUnitOfWork UoW;
        IMapper CategoryLogicMapper;

        public LotsService(IUnitOfWork UoW)
        {
            CategoryLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategorieDTO, LotCatigorie>();
                cfg.CreateMap<LotPostDTO, LotPost>();
                cfg.CreateMap<LotCatigorie, CategorieDTO>();
                cfg.CreateMap<LotPost, LotPostDTO>();
            }).CreateMapper();
            this.UoW = UoW;
        }

        public LotsService()
        {
            CategoryLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategorieDTO, LotCatigorie>();
                cfg.CreateMap<LotPostDTO, LotPost>();
                cfg.CreateMap<LotCatigorie, CategorieDTO>();
                cfg.CreateMap<LotPost, LotPostDTO>();
            }).CreateMapper();
            this.UoW = LogicDependencyResolver.ResolveUoW();
        }

        public void AddLot(LotPostDTO lotPostDTO)
        {
            throw new NotImplementedException();
        }

        public void AddCategory(CategorieDTO NewCategory)
        {
            UoW.Categories.Add(CategoryLogicMapper.Map<CategorieDTO, LotCatigorie>(NewCategory));
        }


        public void DeleteLot(int Id)
        {

            UoW.Lots.Delete(Id);
        }

        public void DeleteCatigories(int Id)
        {

            UoW.Categories.Delete(Id);
        }

        public void AddLot(int CategoryID, LotPostDTO NewPost)
        {
            LotCatigorie category = UoW.Categories.GetAll(x => x.Id == CategoryID, x => x.Lots).FirstOrDefault();
            LotPost lot = CategoryLogicMapper.Map<LotPostDTO, LotPost>(NewPost);
            lot.Categories= category;
            category.Lots.Add(lot);
            UoW.Categories.Modify(category.Id, category);
        }

        public IEnumerable<CategorieDTO> GetAllCategories()
        {
            return CategoryLogicMapper.Map<IEnumerable<LotCatigorie>, List<CategorieDTO>>(UoW.Categories.GetAll(h => h.Lots));
        }

        public LotPostDTO GetLot(int Id)
        {
            return CategoryLogicMapper.Map<LotPost, LotPostDTO>(UoW.Lots.GetAll(x => x.Id == Id).FirstOrDefault());
        }

        public IEnumerable<LotPostDTO> GetLotsByCategory(int categoryId)
        {
            return CategoryLogicMapper.Map<IEnumerable<LotPost>, List<LotPostDTO>>(UoW.Lots.GetAll(x => x.CategoryId == categoryId, x=>x.Categories));
        }

        public IEnumerable<LotPostDTO> GetAllLots()
        {
            return CategoryLogicMapper.Map<IEnumerable<LotPost>, List<LotPostDTO>>(UoW.Lots.GetAll());
        }

        public void PayLot(int Id, double PayCost)
        { 
            LotPost lot = UoW.Lots.GetAll(u => u.Id == Id).FirstOrDefault();
            if (PayCost > lot.CurrentPrice)
                lot.CurrentPrice = PayCost;
            else lot.CurrentPrice += int.Parse(lot.AnteCostId);
            UoW.Lots.Modify(lot.Id, lot);
        }

        public IEnumerable<LotPostDTO> FindLotByPrice(int MinPrice, int MaxPrice)
        {
            return CategoryLogicMapper.Map<IEnumerable<LotPost>, List<LotPostDTO>>(UoW.Lots.GetAll(t => t.CurrentPrice >= MinPrice && t.CurrentPrice <= MaxPrice));
        }

    }
}
