using LightStudio.Core.Entities;
using LightStudio.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Data.Repositories
{
    public class AccountRepository : Repository<AppUser>, IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
