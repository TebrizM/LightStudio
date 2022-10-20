using LightStudio.Core.Repositories;
using LightStudio.Core;
using LightStudio.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LightStudio.Core.Entities;

namespace LightStudio.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private CategoryRepository _categoryRepository;
        private SettingsRepository _settingsRepository;
        private BrandRepository _brandRepository;
        private ProductRepository _productRepository;
        private SliderRepository _sliderRepository;
        private AccountRepository _accountRepository;
        private ReklamRepository _reklamRepository;
        private CountryRepository _countryRepository;
        private ColorRepository _colorRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_context);
        public IBrandRepository BrandRepository => _brandRepository ?? new BrandRepository(_context);
        public IProductRepository ProductRepository => _productRepository ?? new ProductRepository(_context);
        public ISliderRepository SliderRepository => _sliderRepository ?? new SliderRepository(_context);
        public IReklamRepository ReklamRepository => _reklamRepository ?? new ReklamRepository(_context);
        public IColorRepository ColorRepository => _colorRepository ?? new ColorRepository(_context);
        public ICountryRepository CountryRepository => _countryRepository ?? new CountryRepository(_context);
        public IAccountRepository AccountRepository => _accountRepository ?? new AccountRepository(_context);
        public ISettingsRepository SettingsRepository => _settingsRepository ?? new SettingsRepository(_context);


        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
