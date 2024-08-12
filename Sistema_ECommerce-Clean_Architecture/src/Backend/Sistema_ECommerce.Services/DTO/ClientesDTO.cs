using Sistema_ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_ECommerce.Services.DTO
{
    public class ClientesDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DataCreate { get; set; }
        public ClientesStatusEnum StatusCliente { get; set; }

        public ClientesDTO() { }

        public ClientesDTO(long id, string name, string email, string password, DateTime dataCreate, ClientesStatusEnum statusCliente)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            DataCreate = DateTime.UtcNow;
            StatusCliente = statusCliente;
        }
    }
}
