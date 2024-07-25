using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ManagerContext _context;

        public UserRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users
                                    .Where
                                    (
                                        x =>
                                            x.Email.ToLower() == email.ToLower()

                                    )
                                    .AsNoTracking()
                                    .ToListAsync();
            return user.FirstOrDefault();
        }

        public async Task<List<User>> SearchByEmail(string email)
        {
            var allUser = await _context.Users
                                    .Where
                                    (
                                        x =>
                                            x.Email.ToLower().Contains(email.ToLower())

                                    )
                                    .AsNoTracking()
                                    .ToListAsync();
            return allUser;
        }

        public async Task<List<User>> SearchByName(string name)
        {
            var allUser = await _context.Users
                                    .Where
                                    (
                                        x =>
                                            x.Name.ToLower().Contains(name.ToLower())

                                    )
                                    .AsNoTracking()
                                    .ToListAsync();
            return allUser;
        }
    }
}
