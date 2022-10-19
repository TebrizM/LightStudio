using LightStudio.Helper.DTOs.CategoryDto;
using LightStudio.Helper.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LightStudio.Helper.DTOs.CountryDto;

namespace LightStudio.Helper.Interfaces
{
    public interface ICountryService
    {
        Task<CountryGetDto> CreateAsync(CountryPostDto postDto);
        Task UpdateAsync(int id, CountryPutDto categoryPutDto);
        Task<CountryGetDto> GetByIdAsync(int id);
      
        Task Delete(int id);
    }
}
