using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Context;
using DAL.Entities.Catigories;
using DAL.Entities.LotPostManagement;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context.ManagementContext ManagementContext;
       

        public UnitOfWork()
        {
            ManagementContext = new ManagementContext();
        
        }

        public UnitOfWork(ManagementContext ManagementContext)
        {
            this.ManagementContext = ManagementContext;
          
        }


        private IRepository<LotCatigorie> _categories;
        private IRepository<LotPost> _lots;
       

        public IRepository<LotCatigorie> Categories { get { if (_categories == null) _categories = new GenericRepository<LotCatigorie>(ManagementContext); return _categories; } }
        public IRepository<LotPost> Lots { get { if (_lots == null) _lots = new GenericRepository<LotPost>(ManagementContext); return _lots; } }
       
        public void DeleteDB()
        {
            ManagementContext.Database.Delete();
            ManagementContext.Database.Create();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ManagementContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
