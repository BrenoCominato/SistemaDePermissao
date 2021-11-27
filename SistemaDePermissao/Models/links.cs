using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace SistemaDePermissao.Models
{
    public class links
    {
        public int LinksID { get; set; }
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
        [Display(Name = "Tipo de Usuário")]
        public TipoDeUsuario tipoDeUsuario { get; set; }
        [Display(Name = "Tipo de Usuário")]
        public int tipoDeUsuarioId { get; set; }
    }
}
