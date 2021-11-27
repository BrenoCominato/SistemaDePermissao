using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MySqlConnector;

namespace SistemaDePermissao.Models
{
    public class usuario
    {
        public int UsuarioID { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "E-mail")]
        public string  email { get; set; }
        [Display(Name = "Senha")]
        public string senha { get; set; }
        [Display(Name = "Cargo")]
        public string cargo { get; set; }
        [Display(Name = "Tipo de Usuário")]
        public TipoDeUsuario tipoDeUsuario { get; set; }
        [Display(Name = "Tipo de Usuário")]
        public int tipoDeUsuarioId { get; set; }

        public bool flag { get; set; }
        
    }
}
