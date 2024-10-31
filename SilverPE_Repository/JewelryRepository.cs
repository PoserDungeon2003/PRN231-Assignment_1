using SilverPE_BOs.Models;
using SilverPE_DAO;
using SilverPE_Repository.Interfaces;
using SilverPE_Repository.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverPE_Repository
{
    public class JewelryRepository : IJewelryRepository
    {
        public async Task<bool> AddJewelry(CreateSilverJewerlryRequest silverJewelry)
            => await JewelryDAO.Instance.AddJewelry(new SilverJewelry
            {
                CategoryId = silverJewelry.CategoryId,
                CreatedDate = DateTime.Now,
                MetalWeight = silverJewelry.MetalWeight,
                Price = silverJewelry.Price,
                ProductionYear = silverJewelry.ProductionYear,
                SilverJewelryDescription = silverJewelry.SilverJewelryDescription,
                SilverJewelryId = silverJewelry.SilverJewelryId,
                SilverJewelryName = silverJewelry.SilverJewelryName,
            });

        public async Task<bool> DeleteJewelry(string id)
            => await JewelryDAO.Instance.DeleteJewelry(id);

        public async Task<List<SilverJewelryDTO>> GetJewelries()
            => await JewelryDAO.Instance.GetAllJewerlryAsync();

        public async Task<bool> UpdateJewelry(SilverJewelry silverJewelry)
            => await JewelryDAO.Instance.UpdateJewelry(silverJewelry);
    }
}
