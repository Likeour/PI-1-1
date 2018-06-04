using DAL.Entities.LotPostManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Catigories
{
    public class LotCatigorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<LotPost> Lots { get; set; }

    }
}
