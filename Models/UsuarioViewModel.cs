using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class UsuarioViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Informe a Descrição da Usuario!")]
        public string Descricao { get; set; }
    }
}
