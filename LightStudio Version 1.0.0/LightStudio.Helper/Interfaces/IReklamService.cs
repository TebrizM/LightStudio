using LightStudio.Helper.DTOs.BrandDto;
using LightStudio.Helper.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LightStudio.Helper.DTOs.ReklamDto;

namespace LightStudio.Helper.Interfaces
{
    public interface IReklamService
    {
        Task<ReklamGetDto> CreateAsync(ReklamPostDto postDto);
        Task UpdateAsync(int id, ReklamPutDto brandPutDto);
        Task<ReklamGetDto> GetByIdAsync(int id);
        Task Delete(int id);
    }
}
