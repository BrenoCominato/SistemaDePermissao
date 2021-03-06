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
    public class TipoDeUsuariosController : Controller
    {
        private readonly SistemaDePermissaoContext _context;

        public TipoDeUsuariosController(SistemaDePermissaoContext context)
        {
            _context = context;
        }

        // GET: TipoDeUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDeUsuario.ToListAsync());
        }

        // GET: TipoDeUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeUsuario = await _context.TipoDeUsuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeUsuario == null)
            {
                return NotFound();
            }

            return View(tipoDeUsuario);
        }

        // GET: TipoDeUsuarios/Create
        public IActionResult Create()
        {
            int idTipo = (int)HttpContext.Session.GetInt32("tipoDeUsuarioId");

            if (idTipo != 2)
            {
                ViewData["tipoDeUsuarioId"] = new SelectList(_context.TipoDeUsuario, "Id", "Descriçao");
                return View();
            }
            else
            {
                return RedirectToAction("Privacy", "Home");
            }

        }

        // POST: TipoDeUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descriçao")] TipoDeUsuario tipoDeUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeUsuario);
        }

        // GET: TipoDeUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            int idTipo = (int)HttpContext.Session.GetInt32("tipoDeUsuarioId");
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeUsuario = await _context.TipoDeUsuario.FindAsync(id);
            if (tipoDeUsuario == null)
            {
                return NotFound();
            }
            if (idTipo != 2)
            {
                ViewData["tipoDeUsuarioId"] = new SelectList(_context.TipoDeUsuario, "Id", "Descriçao");
                return View(tipoDeUsuario);
            }
            else
            {
                return RedirectToAction("Privacy", "Home");
            }
            
        }

        // POST: TipoDeUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descriçao")] TipoDeUsuario tipoDeUsuario)
        {
            if (id != tipoDeUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeUsuarioExists(tipoDeUsuario.Id))
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
            return View(tipoDeUsuario);
        }

        // GET: TipoDeUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            int idTipo = (int)HttpContext.Session.GetInt32("tipoDeUsuarioId");
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeUsuario = await _context.TipoDeUsuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeUsuario == null)
            {
                return NotFound();
            }
            if (idTipo != 2)
            {
                return View(tipoDeUsuario);
            }
            else
            {
                return RedirectToAction("Privacy", "Home");
            }
        }

        // POST: TipoDeUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDeUsuario = await _context.TipoDeUsuario.FindAsync(id);
            _context.TipoDeUsuario.Remove(tipoDeUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeUsuarioExists(int id)
        {
            return _context.TipoDeUsuario.Any(e => e.Id == id);
        }
    }
}
