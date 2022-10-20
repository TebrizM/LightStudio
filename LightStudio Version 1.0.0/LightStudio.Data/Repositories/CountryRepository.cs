using LightStudio.Core.Entities;
using LightStudio.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Data.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
