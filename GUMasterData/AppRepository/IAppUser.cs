using GUMasterData.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUMasterData.API.AppRepository
{
    public interface IAppUser
    {
        Task<DataUpdateResponseDTO> CreateUserAsync(AppUser appUser);

    }
}
