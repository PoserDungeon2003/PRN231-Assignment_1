﻿using Microsoft.EntityFrameworkCore;
using SilverPE_BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverPE_DAO
{
    public class JewelryDAO
    {
        private SilverJewelry2023DbContext _context;
        private static JewelryDAO _instance;

        public static JewelryDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JewelryDAO();
                }
                return _instance;
            }

        }

        public JewelryDAO()
        {
            _context = new SilverJewelry2023DbContext();
        }

        public async Task<bool> AddJewelry(SilverJewelry silverJewelry)
        {
            bool result = false;
            SilverJewelry silver = await GetSilverJewerly(silverJewelry.SilverJewelryId);

            if (silver == null)
            {
                try
                {
                    _context.SilverJewelries.Add(silverJewelry);
                    await _context.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return result;
        }

        public async Task<bool> UpdateJewelry(SilverJewelry silverJewelry)
        {
            bool result = false;
            SilverJewelry silver = await GetSilverJewerly(silverJewelry.SilverJewelryId);

            if (silver != null)
            {
                try
                {
                    _context.Entry(silver).CurrentValues.SetValues(silverJewelry);
                    await _context.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return result;
        }

        public async Task<bool> DeleteJewelry(string jewelryId)
        {
            bool result = false;
            SilverJewelry silver = await GetSilverJewerly(jewelryId);

            if (silver != null)
            {
                try
                {
                    _context.SilverJewelries.Remove(silver);
                    await _context.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return result;
        }

        private async Task<SilverJewelry> GetSilverJewerly(string jewelryId)
            => await _context.SilverJewelries.FirstOrDefaultAsync(s => s.SilverJewelryId.Equals(jewelryId));
    }
}