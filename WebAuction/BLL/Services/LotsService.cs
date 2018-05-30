using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
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
        IUnitOfWork Database { get; set; }

        public LotsService(IUnitOfWork uow)
        {
            Database = uow;
        }
        
        public IEnumerable<LotPostDTO> GetLots()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotPost, LotPostDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<LotPost>, List<LotPostDTO>>(Database.LotPosts.GetAll());
        }

        public IList<LotPostDTO> GetLotsByCategory(int categoryid)
        {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotPost, LotPostDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<LotPost>, List<LotPostDTO>>(Database.LotPosts.Find(lot => lot.LotCatigorieId==categoryid));
        }

        public LotPostDTO GetPhone(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id лота", "");
            var Lot = Database.LotPosts.Get(id.Value);
            if (Lot == null)
                throw new ValidationException("Лот не найден", "");

            return new LotPostDTO { Id = Lot.Id, Title = Lot.Title, StartPrice = Lot.StartPrice, CurrentPrice = Lot.CurrentPrice, BuyPrice = Lot.BuyPrice, AnteCostId = Lot.AnteCostId, CreatedDate = Lot.CreatedDate, Discription = Lot.Discription, PostedByID =Lot.PostedByID, SalesDate= Lot.SalesDate, StartDate=Lot.StartDate, Image=Lot.Image, LotCatigorieId=Lot.LotCatigorieId};
        }
    }
}
