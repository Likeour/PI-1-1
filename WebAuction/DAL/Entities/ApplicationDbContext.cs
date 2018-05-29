using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Catigories;
using DAL.Entities.LotPostManagement;
using WebApp.Models;
using System.Data.Entity;

namespace DAL.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public ApplicationDbContext(string connectionString)
            : base(connectionString, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
        public virtual IDbSet<LotCatigorie> LotCatigories { get; set; }

        public virtual IDbSet<LotPost> LotPosts { get; set; }
    }
}
