using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositories.LotPostManagementRepository;
using DAL.Entities;
using DAL.Entities.Catigories;
using DAL.Entities.LotPostManagement;
using DAL.Repositories.Catigorie;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext db;

        private LotCatigorieRepository LotCatigorieRepository;

        private LotPostRepository LotPostRepository;

        public EFUnitOfWork() { }

        public EFUnitOfWork(string connectionString)
        {
            db = new ApplicationDbContext(connectionString);
        }

        public IRepository<LotCatigorie> LotCatigories
        {
            get
            {
                if (LotCatigorieRepository == null)
                    LotCatigorieRepository = new LotCatigorieRepository(db);
                return LotCatigorieRepository;
            }
        }

        public IRepository<LotPost> LotPosts
        {
            get
            {
                if (LotPostRepository == null)
                    LotPostRepository = new LotPostRepository(db);
                return LotPostRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
