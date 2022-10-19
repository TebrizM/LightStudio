using LightStudio.Helper.DTOs.AccountDto;
using LightStudio.Helper.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightStudio.Helper.Interfaces
{
    public interface IAccountService
    {
        Task<AppUserGetDto> GetByIdAsync(string id);
        Task<PagenatedListDto<AppUserListItemDto>> GetAll(int page);
    }
}
