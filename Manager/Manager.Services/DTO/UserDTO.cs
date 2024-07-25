using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services.DTO
{
    public class UserDTO
    {

        //Propriedades
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserDTO()
        { }

        public UserDTO(long id, string name, string email, string password)
        {
            Id = Id;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
