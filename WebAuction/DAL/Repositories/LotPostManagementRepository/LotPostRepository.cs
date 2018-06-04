using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using DAL.Entities.LotPostManagement;
using System.Data.Entity;

namespace DAL.Repositories.LotPostManagementRepository
{
    public class LotPostRepository : IRepository<LotPost>
    {
        ApplicationDbContext db;


        public LotPostRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public void Create(LotPost item)
        {
            db.LotPosts.Add(item);
        }

        public void Delete(int Id)
        {
            LotPost lotPost = db.LotPosts.Find(Id);
            if (lotPost != null)
                db.LotPosts.Remove(lotPost);
        }

        public IEnumerable<LotPost> Find(Func<LotPost, bool> predicate)
        {
            return db.LotPosts.Where(predicate).ToList();
        }

        public LotPost Get(int Id)
        {
            return db.LotPosts.Find(Id);
        }

        public IEnumerable<LotPost> GetAll()
        {
            return db.LotPosts;
        }

        public void Update(LotPost item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }

}
