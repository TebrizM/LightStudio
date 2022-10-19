using AutoMapper;
using LightStudio.Core;
using LightStudio.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

    }
}
