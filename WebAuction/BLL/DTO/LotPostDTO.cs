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

        public  int LotCatigorieId { get; set; }
        public ICollection<LotCategorie> LotCatigories { get; set; }

    }
}
