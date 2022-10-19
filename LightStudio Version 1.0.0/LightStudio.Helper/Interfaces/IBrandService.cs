using LightStudio.Helper.DTOs.BrandDto;
using LightStudio.Helper.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightStudio.Helper.Interfaces
{
    public interface IBrandService
    {
        Task<BrandGetDto> CreateAsync(BrandPostDto postDto);
        Task UpdateAsync(int id, BrandPutDto brandPutDto);
        Task<BrandGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<BrandListItemDto>> GetAll(int page);

        Task Delete(int id);
    }
}
