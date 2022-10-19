using LightStudio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightStudio.Core.Repositories
{
    public interface ISettingsRepository : IRepository<Settings>
    {
        Task<string> GetValueAsync(string key);
    }
}
