using SonicBoomDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonicBoomService.Interfaces
{
    public interface IAccountService
    {
        Task Register(AccountDto newAccount);
        Task<AccountDto> GetAccount(string Address);
    }
}
