using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaDePermissao.Models
{
    public class TipoDeUsuario
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        public string Descriçao { get; set; }

    }
}
