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
    public class AccountRepository : IAccountRepository
    {
        public async Task<BranchAccount> GetBranchAccount(AccountLoginRequest loginRequest)
            => await AccountDAO.Instance.GetBranchAccount(loginRequest.Email, loginRequest.Password);
    }
}
