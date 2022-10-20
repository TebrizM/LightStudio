using LightStudio.Core.Entities;
using LightStudio.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Data.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly DataContext _context;

        public BrandRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
