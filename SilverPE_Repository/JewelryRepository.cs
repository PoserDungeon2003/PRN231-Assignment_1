using SilverPE_BOs.Models;
using SilverPE_DAO;
using SilverPE_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverPE_Repository
{
    public class JewelryRepository : IJewelryRepository
    {
        public async Task<bool> AddJewelry(SilverJewelry silverJewelry)
            => await JewelryDAO.Instance.AddJewelry(silverJewelry);

        public async Task<bool> DeleteJewelry(string id)
            => await JewelryDAO.Instance.DeleteJewelry(id);

        public async Task<bool> UpdateJewelry(SilverJewelry silverJewelry)
            => await JewelryDAO.Instance.UpdateJewelry(silverJewelry);
    }
}
