﻿using AutoMapper;
using LightStudio.Core.Entities;
using LightStudio.Core;
using LightStudio.Helper.DTOs.BrandDto;
using LightStudio.Helper.DTOs;
using LightStudio.Helper.Exceptions;
using LightStudio.Helper.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using LightStudio.Helper.DTOs.ProductDto;

namespace LightStudio.Helper.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _env = env;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<BrandGetDto> CreateAsync(BrandPostDto postDto)
        {
            if (await _unitOfWork.BrandRepository.IsExist(x => x.Name.ToUpper().Trim() == postDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Brand already exist");
            string fileName = "";
            if (postDto.Photo != null)
            {
                fileName = postDto.Photo.FileName;


                if (fileName.Length > 100)
                {
                    fileName = fileName.Substring(postDto.Photo.FileName.Length - 64, 64);
                }

                //string name = DateTime.Now.Second.ToString() + (fileName);

                string path = Path.Combine(_env.WebRootPath, "images/brands", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    postDto.Photo.CopyTo(stream);
                }
            }
            Brand brand = _mapper.Map<Brand>(postDto);
            await _unitOfWork.BrandRepository.AddAsync(brand);
            await _unitOfWork.SaveAsync();
            return new BrandGetDto
            {
                Id = brand.Id,
                Name = brand.Name,
                Image = brand.Image,
               
            };
        }

        #endregion

        #region Get

        public async Task<BrandGetDto> GetByIdAsync(int id)
        {
            Brand brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id && !x.IsDeleted, "Products");
            if (brand is null) throw new NotFoundException("Item not found");
            BrandGetDto brandGetDto = _mapper.Map<BrandGetDto>(brand);
            return brandGetDto;
        }

        #endregion

        #region GetAll

        public async Task<PagenatedListDto<BrandListItemDto>> GetAll(int page)
        {
            var query = _unitOfWork.BrandRepository.GetAll(x => !x.IsDeleted, "Products");
            var pageSizeStr = await _unitOfWork.SettingsRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);

            List<BrandListItemDto> items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new BrandListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                
                    Products = _mapper.Map<List<ProductGetDto>>(x.Products)
                })
                .ToList();

            var listDto = new PagenatedListDto<BrandListItemDto>(items, query.Count(), page, pageSize);
            return listDto;
        }

        #endregion

        #region Update

        public async Task UpdateAsync(int id, BrandPutDto brandPutDto)
        {
            Brand brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (brand is null) throw new NotFoundException("Item not found");

            Brand old = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id);
            if (old is null) throw new NotFoundException("item not found");

            if (old.Image != null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "images/brands", old.Image);

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
            }

            string fileName = "";
            if (brandPutDto.Photo != null)
            {
                fileName = brandPutDto.Photo.FileName;


                if (fileName.Length > 100)
                {
                    fileName = fileName.Substring(brandPutDto.Photo.FileName.Length - 64, 64);
                }

                //string name = DateTime.Now.Second.ToString() + (fileName);

                string path = Path.Combine(_env.WebRootPath, "images/brands", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    brandPutDto.Photo.CopyTo(stream);
                }
            }

            if (await _unitOfWork.BrandRepository.IsExist(x => x.Id != id && x.Name.ToUpper().Trim() == brandPutDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Brand already exist");
            brand.Name = brandPutDto.Name;
   
            brand.Image = fileName;
            await _unitOfWork.SaveAsync();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            Brand brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (brand is null) throw new NotFoundException("Item not found");
            brand.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
