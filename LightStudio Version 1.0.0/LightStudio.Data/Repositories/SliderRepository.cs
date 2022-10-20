using LightStudio.Core.Entities;
using LightStudio.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Data.Repositories
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly DataContext _context;

        public SliderRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
