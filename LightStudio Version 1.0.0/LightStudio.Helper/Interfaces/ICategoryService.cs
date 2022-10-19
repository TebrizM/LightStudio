using LightStudio.Helper.DTOs.CategoryDto;
using LightStudio.Helper.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightStudio.Helper.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryGetDto> CreateAsync(CategoryPostDto postDto);
        Task UpdateAsync(int id, CategoryPutDto categoryPutDto);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<CategoryListItemDto>> GetAll(int page);
        Task Delete(int id);
    }
}
