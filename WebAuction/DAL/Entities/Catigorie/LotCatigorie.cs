using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.LotPostManagement;

namespace DAL.Entities.Catigories
{
    public class LotCatigorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual int LotId { get; set; }
        public ICollection<LotPost> lotPosts { get; set; }
    }
}
