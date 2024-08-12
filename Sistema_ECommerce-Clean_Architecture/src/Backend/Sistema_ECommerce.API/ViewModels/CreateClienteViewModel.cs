using System.ComponentModel.DataAnnotations;

namespace Sistema_ECommerce.API.ViewModels
{
    public class CreateClienteViewModel
    {
        //Primeira Validação Nome
        [Required(ErrorMessage = "O nome não pode ser nulo")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mímino 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres")]
        public string Name { get; set; }

        //Primeira Validação email
        [Required(ErrorMessage = "O email não pode ser vazio")]
        [MinLength(10, ErrorMessage = "O email deve ter no mímino 10 caracteres")]
        [MaxLength(180, ErrorMessage = "O email deve ter no máximo 180 caracteres")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; }

        //Primeira Validação Password
        [Required(ErrorMessage = "A senha não pode ser vazia")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mímino 6 caracteres")]
        [MaxLength(180, ErrorMessage = "A senha deve ter no máximo 80 caracteres")]
        public string Password { get; set; }
    }
}
