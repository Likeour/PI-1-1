using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;
using DAL.Entities.Catigories;

namespace DAL.Entities.LotPostManagement
{
    public class LotPost
    {
        public int Id { get; set; }

        public virtual string Title { get; set; }
        public virtual double StartPrice { get; set; }
        public virtual double BuyPrice { get; set; }
        public virtual double CurrentPrice { get; set; }

        [ForeignKey("User")]
        public virtual string PostedByID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual string AnteCostId { get; set; }

        public virtual string Discription { get; set; }
        public virtual byte[] Image { get; set; }

        [Column(TypeName = "Date")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime SalesDate { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual LotCatigorie Categories { get; set; }

       // public virtual int LotCatigorieId { get; set; }
        //public ICollection<LotCatigorie> LotCatigories { get; set; }


    }
}
