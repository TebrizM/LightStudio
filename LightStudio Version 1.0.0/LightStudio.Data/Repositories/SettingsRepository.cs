using LightStudio.Core.Entities;
using LightStudio.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightStudio.Data.Repositories
{
    public class SettingsRepository : Repository<Settings>, ISettingsRepository
    {
        private readonly DataContext _context;

        public SettingsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> GetValueAsync(string key)
        {
            Settings setting = await _context.Settings.FirstOrDefaultAsync(x => x.Key == key);
            return setting.Value;
        }
    }
}
