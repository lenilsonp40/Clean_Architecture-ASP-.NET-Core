using Sistema_ECommerce.Domain.Enums;
using Sistema_ECommerce.Domain.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_ECommerce.Domain.Entities
{
    public class Clientes : Base
    {

        //Propriedades
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime DataCreate { get; private set; }
        public ClientesStatusEnum StatusCliente { get; private set; }

        //EF
        protected Clientes() { }

        public Clientes(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            DataCreate = DataCreate;
            StatusCliente = ClientesStatusEnum.Pendente;
            _errors = new List<string>();

            Validate();
            
        }
        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        //Comportamentos
        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        //Autovalida
        public override bool Validate()
        {
            var validator = new ClientesValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

              //  throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
            }

            return true;
        }
    }
}
