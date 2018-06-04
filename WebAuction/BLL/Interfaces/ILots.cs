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
        void AddCategory(CategorieDTO NewCategory);
        void AddLot(int CategoryId, LotPostDTO NewLot);

        IEnumerable<CategorieDTO> GetAllCategories();
        IEnumerable<LotPostDTO> GetAllLots();
        IEnumerable<LotPostDTO> GetLotsByCategory(int categoryId);
        LotPostDTO GetLot(int  id);

        void DeleteLot(int Id);

        void PayLot(int Id, double PayCost);
        //  void Dispose();
    }
}
