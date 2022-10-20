using AutoMapper;
using LightStudio.Core.Entities;
using LightStudio.Core;

using LightStudio.Helper.DTOs;
using LightStudio.Helper.Exceptions;
using LightStudio.Helper.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LightStudio.Helper.DTOs.CountryDto;
using System.Linq;

namespace LightStudio.Helper.Implementations
{
   
    public class CountryService : ICountryService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _env = env;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<CountryGetDto> CreateAsync(CountryPostDto postDto)
        {
            if (await _unitOfWork.CategoryRepository.IsExist(x => x.Name.ToUpper().Trim() == postDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Country already exist");


            Country country = _mapper.Map<Country>(postDto);
            await _unitOfWork.CountryRepository.AddAsync(country);
            await _unitOfWork.SaveAsync();
            return new CountryGetDto
            {
                Id = country.Id,
                Name = country.Name,

            };
        }

        #endregion

        #region Get

        public async Task<CountryGetDto> GetByIdAsync(int id)
        {
            Country country = await _unitOfWork.CountryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (country is null) throw new NotFoundException("Item not found");
            CountryGetDto countryGetDto = _mapper.Map<CountryGetDto>(country);
            return countryGetDto;
        }

        #endregion


        #region Update

        public async Task UpdateAsync(int id, CountryPutDto countryPutDto)
        {
            Country country = await _unitOfWork.CountryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (country is null) throw new NotFoundException("Item not found");

            Country old = await _unitOfWork.CountryRepository.GetAsync(x => x.Id == id);
            if (old is null) throw new NotFoundException("item not found");


            if (await _unitOfWork.CountryRepository.IsExist(x => x.Id != id && x.Name.ToUpper().Trim() == countryPutDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Country already exist");
            countryPutDto.Name = countryPutDto.Name;

            await _unitOfWork.SaveAsync();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (category is null) throw new NotFoundException("Item not found");
            category.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
