using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDePermissao.Data;
using SistemaDePermissao.Models;

namespace SistemaDePermissao.Controllers
{
    public class usuariosController : Controller
    {
        private readonly SistemaDePermissaoContext _context;

        public usuariosController(SistemaDePermissaoContext context)
        {
            _context = context;
        }

        // GET: usuarios
        public async Task<IActionResult> Index()
        {
            var sistemaDePermissaoContext = _context.usuario.Include(u => u.tipoDeUsuario);
            return View(await sistemaDePermissaoContext.ToListAsync());
        }

        // GET: usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuario
                .Include(u => u.tipoDeUsuario)
                .FirstOrDefaultAsync(m => m.UsuarioID == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: usuarios/Create
        public IActionResult Create()
        {
            
            int idTipo = (int)HttpContext.Session.GetInt32("tipoDeUsuarioId");

            if(idTipo != 2)
            {
                ViewData["tipoDeUsuarioId"] = new SelectList(_context.TipoDeUsuario, "Id", "Descriçao");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioID,nome,email,senha,cargo,tipoDeUsuarioId")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Login");
            }
            ViewData["tipoDeUsuarioId"] = new SelectList(_context.TipoDeUsuario, "Id", "Descriçao", usuario.tipoDeUsuarioId);
            return View(usuario);
        }

        // GET: usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            int idTipo = (int)HttpContext.Session.GetInt32("tipoDeUsuarioId");
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            if (idTipo != 2)
            {
                ViewData["tipoDeUsuarioId"] = new SelectList(_context.TipoDeUsuario, "Id", "Descriçao", usuario.tipoDeUsuarioId);
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
            
        }

        // POST: usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioID,nome,email,senha,cargo,tipoDeUsuarioId")] usuario usuario)
        {
            if (id != usuario.UsuarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!usuarioExists(usuario.UsuarioID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["tipoDeUsuarioId"] = new SelectList(_context.TipoDeUsuario, "Id", "Descriçao", usuario.tipoDeUsuarioId);
            return View(usuario);
        }

        // GET: usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            int idTipo = (int)HttpContext.Session.GetInt32("tipoDeUsuarioId");
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuario
                .Include(u => u.tipoDeUsuario)
                .FirstOrDefaultAsync(m => m.UsuarioID == id);
            if (usuario == null)
            {
                return NotFound();
            }
            if (idTipo != 2)
            {
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            } 
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.usuario.FindAsync(id);
            _context.usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool usuarioExists(int id)
        {
            return _context.usuario.Any(e => e.UsuarioID == id);
        }
    }
}
