using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class LoginViewModel
    {
        //[Required(ErrorMessage = "Informe o E-mail!")]
        //public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a Senha!")]
        public string Senha { get; set; }
    }
}
