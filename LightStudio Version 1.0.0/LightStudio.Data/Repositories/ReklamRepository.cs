using LightStudio.Core.Entities;
using LightStudio.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Data.Repositories
{
    public class ReklamRepository : Repository<Reklam>, IReklamRepository
    {
        private readonly DataContext _context;

        public ReklamRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
