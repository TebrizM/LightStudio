using LightStudio.Helper.DTOs.ProductDto;
using LightStudio.Helper.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LightStudio.Helper.DTOs.ColorDto;

namespace LightStudio.Helper.Interfaces
{
    public interface IColorService
    {
        Task<ColorGetDto> CreateAsync(ColorPostDto postDto);
        Task UpdateAsync(int id, ColorPutDto productPutDto);
        Task<ColorGetDto> GetByIdAsync(int id);
        Task Delete(int id);
    }
}
