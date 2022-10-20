using AutoMapper;
using LightStudio.Core.Entities;
using LightStudio.Core;
using LightStudio.Helper.DTOs.SettingsDto;
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

namespace LightStudio.Helper.Implementations
{
    public class SettingService : ISettingsService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SettingService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _env = env;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<SettingsGetDto> CreateAsync(SettingsPostDto postDto)
        {
            string fileName = "";
            if (postDto.Photo != null)
            {
                fileName = postDto.Photo.FileName;


                if (fileName.Length > 100)
                {
                    fileName = fileName.Substring(postDto.Photo.FileName.Length - 64, 64);
                }

                //string name = DateTime.Now.Second.ToString() + (fileName);

                string path = Path.Combine(_env.WebRootPath, "images/settings", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    postDto.Photo.CopyTo(stream);
                }
            }

            Settings setting = _mapper.Map<Settings>(postDto);
            await _unitOfWork.SettingsRepository.AddAsync(setting);
            await _unitOfWork.SaveAsync();
            return new SettingsGetDto
            {
                Id = setting.Id,
                Key = setting.Key,
                Value = setting.Value,
            };
        }

        #endregion

        #region Get

        public async Task<SettingsGetDto> GetByIdAsync(int id)
        {
            Settings setting = await _unitOfWork.SettingsRepository.GetAsync(x => x.Id == id);
            if (setting is null) throw new NotFoundException("Item not found");
            SettingsGetDto settingGetDto = _mapper.Map<SettingsGetDto>(setting);
            return settingGetDto;
        }

        #endregion

        #region GetAll

        public async Task<PagenatedListDto<SettingsListItemDto>> GetAll(int page)
        {
            var query = _unitOfWork.SettingsRepository.GetAll(x => !x.IsDeleted);
            var pageSizeStr = await _unitOfWork.SettingsRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);
            List<SettingsListItemDto> items = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
                .Select(x => new SettingsListItemDto
                {
                    Id = x.Id,
                    Key = x.Key,
                    Value = x.Value,
                })
            .ToList();

            var listDto = new PagenatedListDto<SettingsListItemDto>(items, query.Count(), page, pageSize);
            return listDto;
        }

        #endregion

        #region Update

        public async Task UpdateAsync(int id, SettingsPostDto settingPostDto)
        {
            Settings setting = await _unitOfWork.SettingsRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (setting is null) throw new NotFoundException("Item not found");
            Settings old = await _unitOfWork.SettingsRepository.GetAsync(x => x.Id == id);
            if (old is null) throw new NotFoundException("item not found");

            if (old.Value != null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "images/settings", old.Value);

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
            }

            string fileName = "";
            if (settingPostDto.Photo != null)
            {
                fileName = settingPostDto.Photo.FileName;


                if (fileName.Length > 100)
                {
                    fileName = fileName.Substring(settingPostDto.Photo.FileName.Length - 64, 64);
                }

                //string name = DateTime.Now.Second.ToString() + (fileName);

                string path = Path.Combine(_env.WebRootPath, "images/settings", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    settingPostDto.Photo.CopyTo(stream);
                }
            }
            setting.Key = settingPostDto.Key;
            setting.Value = settingPostDto.Value;
            setting.Value = fileName;
            await _unitOfWork.SaveAsync();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            Settings setting = await _unitOfWork.SettingsRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (setting is null) throw new NotFoundException("Item not found");
            setting.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
