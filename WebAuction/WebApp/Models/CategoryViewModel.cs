using DAL.Entities.LotPostManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<LotPost> Lots { get; set; }
    }
}