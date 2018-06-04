using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;
using DAL.Entities.Catigories;
using DAL.Entities.LotPostManagement;

namespace DAL.Context
{
    public class ManagementContext : DbContext
    {

        public ManagementContext() : base("DefaultConnection") { }
        public DbSet<LotCatigorie> Categories { get; set; }
        public DbSet<LotPost> Lots { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LotCatigorie>()
            .HasMany(r => r.Lots)
            .WithRequired(h => h.Categories)
            .HasForeignKey(h => h.CategoryId)
            .WillCascadeOnDelete();

            base.OnModelCreating(modelBuilder);
        }
    }
}
