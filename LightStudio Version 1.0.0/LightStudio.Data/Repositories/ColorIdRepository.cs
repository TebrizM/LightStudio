using LightStudio.Core.Entities;
using LightStudio.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Data.Repositories
{
  
    public class ColorIdRepository : Repository<ColorIds>, IColorIds
    {
        private readonly DataContext _context;

        public ColorIdRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
