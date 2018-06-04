using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Services;
using Moq;
using DAL;
using NUnit.Framework;
using Ninject;
using Ninject.Modules;
using System.Linq;

namespace WebAuctionTest
{
    [TestFixture]
    public class WebAuctionTest
    {
        [Test]
        public void AdditingCatigories()
        {
            var UoW = new Mock<UnitOfWork>();

            var LotsService = new LotsService(UoW.Object);


            LotsService.AddCategory(new BLL.DTO.CategorieDTO("Telephone"));

            var categorie = LotsService.GetAllCategories().ToList()[0];

            NUnit.Framework.Assert.That(LotsService.GetAllCategories().Count() == 1);
            NUnit.Framework.Assert.That(categorie.Name == "Telephone");
           
        }

        [Test]
        public void AdditingLot()
        {
            var UoW = new Mock<UnitOfWork>();

            var LotsService = new LotsService(UoW.Object);

            DateTime date = new DateTime(2018, 05, 20);
            DateTime date1 = new DateTime(2018, 05, 25);
            LotsService.AddLot(new BLL.DTO.LotPostDTO("Title",  10.5,  100.5, "id post",  "namecost", " Discription", DateTime.Now,  date,  date1,  50.5));

            var lot = LotsService.GetAllLots().ToList()[0];

            NUnit.Framework.Assert.That(LotsService.GetAllCategories().Count() == 1);
            NUnit.Framework.Assert.That(lot.Title == "Title");
            NUnit.Framework.Assert.That(lot.StartPrice == 10.5);
            NUnit.Framework.Assert.That(lot.BuyPrice == 100.5);
            NUnit.Framework.Assert.That(lot.PostedByID == "id post");
            NUnit.Framework.Assert.That(lot.AnteCostId == "namecost");
            NUnit.Framework.Assert.That(lot.Discription == "Discription");
            NUnit.Framework.Assert.That(lot.CreatedDate == DateTime.Now);
            NUnit.Framework.Assert.That(lot.StartDate == date);
            NUnit.Framework.Assert.That(lot.SalesDate == date1);
            NUnit.Framework.Assert.That(lot.CurrentPrice == 50.5);


        }

        [Test]
        public void DeletingCatigorie()
        {
            var UoW = new Mock<UnitOfWork>();

            UoW.Object.DeleteDB();
            var LotsService = new LotsService(UoW.Object);


            LotsService.AddCategory(new BLL.DTO.CategorieDTO("Telephone"));

            var categorie = LotsService.GetAllCategories().ToList()[0];

            NUnit.Framework.Assert.That(LotsService.GetAllCategories().Count() == 1);

            LotsService.DeleteCatigories(1);

            NUnit.Framework.Assert.That(LotsService.GetAllCategories().Count() == 0);
        }


        [Test]
        public void DeletingLot()
        {
            var UoW = new Mock<UnitOfWork>();

            var LotsService = new LotsService(UoW.Object);

            DateTime date = new DateTime(2018, 05, 20);
            DateTime date1 = new DateTime(2018, 05, 25);
            LotsService.AddLot(new BLL.DTO.LotPostDTO("Title", 10.5, 100.5, "id post", "namecost", " Discription", DateTime.Now, date, date1, 50.5));

            var lot = LotsService.GetAllLots().ToList()[0];

            LotsService.DeleteLot(1);

            NUnit.Framework.Assert.That(LotsService.GetAllCategories().Count() == 0);


        }
    }
}
