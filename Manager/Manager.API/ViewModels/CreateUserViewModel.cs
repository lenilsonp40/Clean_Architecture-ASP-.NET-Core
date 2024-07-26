﻿using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class CreateUserViewModel
    {

        [Required(ErrorMessage = "O nome não pode ser nulo")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mímino 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email não pode ser vazio")]
        [MinLength(10, ErrorMessage = "O email deve ter no mímino 10 caracteres")]
        [MaxLength(180, ErrorMessage = "O email deve ter no máximo 180 caracteres")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        ErrorMessage = "O email informado não é válido.")]

        public string Email { get; set; }

        [Required(ErrorMessage = "A senha não pode ser vazia")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mímino 6 caracteres")]
        [MaxLength(180, ErrorMessage = "A senha deve ter no máximo 80 caracteres")]

        public string Password { get; set; }

    }
}
