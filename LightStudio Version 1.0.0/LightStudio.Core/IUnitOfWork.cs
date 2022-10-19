using LightStudio.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightStudio.Core
{
    public interface IUnitOfWork
    {
        IBrandRepository BrandRepository { get; }
        ISettingsRepository SettingsRepository { get; }
        IAccountRepository AccountRepository { get; }
        IProductRepository ProductRepository { get; }
        ISliderRepository SliderRepository { get; }
        IReklamRepository ReklamRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICategoryRepository CategoryRepository { get; }


        int Save();
        Task<int> SaveAsync();
    }
}
