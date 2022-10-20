using AutoMapper;
using LightStudio.Core.Entities;
using LightStudio.Core;
using LightStudio.Helper.DTOs.CountryDto;
using LightStudio.Helper.Exceptions;
using LightStudio.Helper.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LightStudio.Helper.DTOs.ReklamDto;
using System.IO;

namespace LightStudio.Helper.Implementations
{
    
    public class ReklamService : IReklamService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReklamService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _env = env;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<ReklamGetDto> CreateAsync(ReklamPostDto postDto)
        {
            if (await _unitOfWork.ReklamRepository.IsExist(x => x.Title.ToUpper().Trim() == postDto.Title.ToUpper().Trim())) throw new RecordDuplicatedException("Reklam already exist");
            string fileName = "";
            if (postDto.Image != null)
            {
                fileName = postDto.Image.FileName;


                if (fileName.Length > 100)
                {
                    fileName = fileName.Substring(postDto.Image.FileName.Length - 64, 64);
                }

                //string name = DateTime.Now.Second.ToString() + (fileName);

                string path = Path.Combine(_env.WebRootPath, "images/reklam", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    postDto.Image.CopyTo(stream);
                }
            }


            Reklam reklam = _mapper.Map<Reklam>(postDto);

            await _unitOfWork.ReklamRepository.AddAsync(reklam);
            await _unitOfWork.SaveAsync();
            return new ReklamGetDto
            {
                Id = reklam.Id,
                Title = reklam.Title,
                Title2 = reklam.Title2,
                Title3 = reklam.Title3,
                Contact = reklam.Contact,
                Image = reklam.Image,
                Info = reklam.Info,
                

            };
        }

        #endregion

        #region Get

        public async Task<ReklamGetDto> GetByIdAsync(int id)
        {
            Reklam reklam = await _unitOfWork.ReklamRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (reklam is null) throw new NotFoundException("Item not found");
            ReklamGetDto reklamGetDto = _mapper.Map<ReklamGetDto>(reklam);
            return reklamGetDto;
        }

        #endregion


        #region Update

        public async Task UpdateAsync(int id, ReklamPutDto reklamPutDto)
        {
            Reklam reklam = await _unitOfWork.ReklamRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (reklam is null) throw new NotFoundException("Item not found");

            Reklam old = await _unitOfWork.ReklamRepository.GetAsync(x => x.Id == id);
            if (old is null) throw new NotFoundException("item not found");


            if (await _unitOfWork.ReklamRepository.IsExist(x => x.Id != id && x.Title.ToUpper().Trim() == reklamPutDto.Title.ToUpper().Trim())) throw new RecordDuplicatedException("Reklam already exist");
            reklamPutDto.Title = reklamPutDto.Title;

            await _unitOfWork.SaveAsync();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            Reklam reklam = await _unitOfWork.ReklamRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (reklam is null) throw new NotFoundException("Item not found");
            reklam.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
