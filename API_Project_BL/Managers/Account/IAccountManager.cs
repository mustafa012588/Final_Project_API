using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Project_BL.Dtos.Account;
using Microsoft.AspNetCore.Identity;

namespace API_Project_BL.Managers.Account
{
    public interface IAccountManager
    {
        Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
    }
}
