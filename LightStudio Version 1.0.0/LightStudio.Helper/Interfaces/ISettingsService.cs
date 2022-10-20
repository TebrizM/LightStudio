using LightStudio.Helper.DTOs.SettingsDto;
using LightStudio.Helper.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightStudio.Helper.Interfaces
{
    public interface ISettingsService
    {
       
            Task UpdateAsync(int id, SettingsPostDto settingPostDto);
            Task<SettingsGetDto> GetByIdAsync(int id);
            Task<PagenatedListDto<SettingsListItemDto>> GetAll(int page);
        
    }
}
