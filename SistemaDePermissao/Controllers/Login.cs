using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Xceed.Wpf.Toolkit;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.AspNetCore.Session;
using SistemaDePermissao.Data;
using Microsoft.AspNetCore.Http;

namespace SistemaDePermissao.Controllers
{
    public class Login : Controller
    {
        private SistemaDePermissaoContext _context;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logar(string email, string senha)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("Server=localhost;userid=root;password=1234;database=db_permissao");
            await mySqlConnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT tipoDeUsuarioId FROM usuario WHERE email = '{email}' AND senha = '{senha}'";
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            /*----------------------------Instrução lambda-----------------------------------*/

            /*var usuario = _context.usuario.Where(X => X.senha == senha && X.email == email);
            if(usuario != null)
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
            }*/
            /*--------------------------------------------------------------------------------*/
            if (await reader.ReadAsync())
            {
                int tipoId = reader.GetInt32(0);
                HttpContext.Session.SetInt32("tipoDeUsuarioId", tipoId);
                return RedirectToAction("Index", "Home");
            }
            return Json(new { Msg = "Usuario nao encontrado!" });
        }
    }
}
