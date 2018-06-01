using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DTO;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public  interface ILots
    {
        IList<LotPostDTO> GetLotsByCategory(int categoryId);
        IEnumerable<LotPostDTO> GetLots();
        LotPostDTO GetLot(int? id);
      //  void Dispose();
    }
}
