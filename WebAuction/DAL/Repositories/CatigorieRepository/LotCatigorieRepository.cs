using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities.Catigories;
using DAL.Entities;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DAL.Repositories.Catigorie
{
    public class LotCatigorieRepository: IRepository<LotCatigorie>
    {
        ApplicationDbContext db;

        public LotCatigorieRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public void Create(LotCatigorie item)
        {
            db.LotCatigories.Add(item);
        }

        public void Delete(int Id)
        {
            LotCatigorie lotCatigorie = db.LotCatigories.Find(Id);
            if (lotCatigorie != null)
                db.LotCatigories.Remove(lotCatigorie);
        }

        public IEnumerable<LotCatigorie> Find(Func<LotCatigorie, bool> predicate)
        {
            return db.LotCatigories.Where(predicate).ToList();
        }

        public LotCatigorie Get(int Id)
        {
            return db.LotCatigories.Find(Id);
        }

        public IEnumerable<LotCatigorie> GetAll()
        {
            return db.LotCatigories;
        }

        public void Update(LotCatigorie item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
