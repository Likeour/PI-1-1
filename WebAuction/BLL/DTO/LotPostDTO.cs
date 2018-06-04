using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO
{
   public class LotPostDTO
    {
        public LotPostDTO() { }
        public LotPostDTO(String Title, double StartPrice, double BuyPrice, string PostedByID, string AnteCostId, string Discription, DateTime CreatedDate, DateTime StartDate, DateTime SalesDate , double CurrentPrice )
        {
            this.Title = Title;
            this.StartDate = StartDate;
            this.BuyPrice = BuyPrice;
            this.PostedByID = PostedByID;
            this.AnteCostId = AnteCostId;
            this.Discription = Discription;
            this.CreatedDate = CreatedDate;
            this.StartDate = CreatedDate;
            this.SalesDate = SalesDate;

        }
        public int Id { get; set; }

        public string Title { get; set; }
        public double StartPrice { get; set; }
        public double BuyPrice { get; set; }
        public double CurrentPrice { get; set; }

        public string PostedByID { get; set; }
        //public ApplicationUser User { get; set; }
        public string AnteCostId { get; set; }

        public string Discription { get; set; }
        public byte[] Image { get; set; }

        
        public DateTime? CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? SalesDate { get; set; }

        public int CategoryId { get; set; }
        public virtual CategorieDTO Category { get; set; }
        
       // public ICollection<CategorieDTO> LotCatigories { get; set; }

    }
}
