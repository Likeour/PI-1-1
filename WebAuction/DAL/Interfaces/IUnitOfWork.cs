using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Catigories;
using DAL.Entities.LotPostManagement;


namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<LotCatigorie> Categories { get; }

        IRepository<LotPost> Lots { get; }

        //void Save();
        void DeleteDB();
    }
}
