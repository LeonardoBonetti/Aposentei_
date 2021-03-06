using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Domain.Entities;
using Hackaton.Domain.Interfaces;
using Hackaton.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        protected readonly MyContext _context;
        private DbSet<User> _dataset;

        public UserRepository(MyContext context) : base(context)
        {
            _context = context;
            _dataset = _context.Set<User>();
        }

        public async Task<User> LoginAsync(User user)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Email.Equals(user.Email) && p.Password.Equals(user.Password));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UserExists(string email)
        {
            return await _dataset.AnyAsync(p => p.Email.Equals(email));
        }
    }
}