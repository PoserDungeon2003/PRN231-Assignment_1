using SilverPE_BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverPE_Repository.Interfaces
{
    public interface IJewelryRepository
    {
        public Task<bool> AddJewelry(SilverJewelry silverJewelry);
        public Task<bool> UpdateJewelry(SilverJewelry silverJewelry);
        public Task<bool> DeleteJewelry(string id);
    }
}
