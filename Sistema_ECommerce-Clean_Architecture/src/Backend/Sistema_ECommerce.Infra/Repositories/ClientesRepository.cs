using Microsoft.EntityFrameworkCore;
using Sistema_ECommerce.Domain.Entities;
using Sistema_ECommerce.Infra.Context;
using Sistema_ECommerce.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_ECommerce.Infra.Repositories
{
    
    public class ClientesRepository : BaseRepository<Clientes>, IClientesRepository
    {

        private readonly AppDbContext _context;

        public ClientesRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Clientes> GetByEmail(string email)
        {
            var user = await _context.Clientes
                                    .Where
                                    (
                                        x =>
                                            x.Email.ToLower() == email.ToLower()

                                    )
                                    .AsNoTracking()
                                    .ToListAsync();
            return user.FirstOrDefault();
        }

        public async Task<List<Clientes>> SearchByEmail(string email)
        {
            var allUser = await _context.Clientes
                                    .Where
                                    (
                                        x =>
                                            x.Email.ToLower().Contains(email.ToLower())

                                    )
                                    .AsNoTracking()
                                    .ToListAsync();
            return allUser;
        }

        public async Task<List<Clientes>> SearchByName(string name)
        {
            var allUser = await _context.Clientes
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
