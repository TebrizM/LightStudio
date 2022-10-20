using LightStudio.Helper.DTOs.SliderDto;
using LightStudio.Helper.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightStudio.Helper.Interfaces
{
    public interface ISliderService
    {
        Task<SliderGetDto> CreateAsync(SliderPostDto postDto);
        Task UpdateAsync(int id, SliderPostDto sliderPostDto);
        Task<SliderGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<SliderListItemDto>> GetAll(int page);
        Task Delete(int id);
    }
}
