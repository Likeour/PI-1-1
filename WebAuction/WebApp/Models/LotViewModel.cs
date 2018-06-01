using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class LotViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public double StartPrice { get; set; }
        public double BuyPrice { get; set; }
        public double CurrentPrice { get; set; }

        public string PostedByID { get; set; }
        public string AnteCostId { get; set; }

        public string Discription { get; set; }
        public byte[] Image { get; set; }


        public DateTime? CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? SalesDate { get; set; }

        public int LotCatigorieId { get; set; }
        public ICollection<CategoryViewModel> LotCatigories { get; set; }
    }
}