using LightStudio.Helper.DTOs.ProductDto;
using LightStudio.Helper.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightStudio.Helper.Interfaces
{
    internal interface IProductService
    {
        Task<ProductGetDto> CreateAsync(ProductPostDto postDto);
        Task UpdateAsync(int id, ProductPutDto productPutDto);
        Task<ProductGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<ProductListItemDto>> GetAll(int page);
        Task Delete(int id);
    }
}
