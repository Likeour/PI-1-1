using DAL.Entities.LotPostManagement;
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
<<<<<<< HEAD:WebAuction/DAL/Entities/LotCatigorie.cs
        public virtual List<LotPost> Lots { get; set; }

=======
        public virtual int LotId { get; set; }
        public ICollection<LotPost> lotPosts { get; set; }
>>>>>>> db5b878ddc2a6eb5688a1db47762347d0263db6d:WebAuction/DAL/Entities/Catigorie/LotCatigorie.cs
    }
}
