using SonicBoomDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonicBoomService.Interfaces
{
    public interface IContractService
    {
        Task Add(string addressUser, int idProject, AccountDto newAccount);
        Task<List<AccountDto>> GetContracts(string addressUser, int idProject);
    }
}
