using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaDePermissao.Models;

namespace SistemaDePermissao.Data
{
    public class SistemaDePermissaoContext : DbContext
    {
        public SistemaDePermissaoContext (DbContextOptions<SistemaDePermissaoContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaDePermissao.Models.usuario> usuario { get; set; }

        public DbSet<SistemaDePermissao.Models.links> links { get; set; }

        public DbSet<SistemaDePermissao.Models.TipoDeUsuario> TipoDeUsuario { get; set; }
    }
}
