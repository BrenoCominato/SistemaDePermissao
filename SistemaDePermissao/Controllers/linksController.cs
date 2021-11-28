using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using SistemaDePermissao.Data;
using SistemaDePermissao.Models;
using System.Collections;

namespace SistemaDePermissao.Controllers
{
    public class linksController : Controller
    {
        private readonly SistemaDePermissaoContext _context;


        public linksController(SistemaDePermissaoContext context)
        {
            _context = context;
        }

        // GET: links
        public async Task<IActionResult> Index()
        {
            var sistemaDePermissaoContext = _context.links.Include(l => l.tipoDeUsuario);
            int idTipo = (int)HttpContext.Session.GetInt32("tipoDeUsuarioId");
            /*MySqlConnection mySqlConnection = new MySqlConnection("Server=localhost;userid=root;password=1234;database=db_permissao");
            await mySqlConnection.OpenAsync();

            int idTipo = (int)HttpContext.Session.GetInt32("tipoDeUsuarioId");
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT descricao FROM links INNER JOIN usuario ON links.tipoDeUsuarioId = usuario.tipoDeUsuarioId";
            MySqlDataReader reader = mySqlCommand.ExecuteReader();*/

            var links = _context.links.Where(l => l.tipoDeUsuarioId == idTipo).ToListAsync();



            /*if(idtipo == idtipo)
            {
                return View(links);
            }*/

            //int myidTipo = idTipo;
            //IEnumerable<Int32> myint = Enumerable.Repeat(myidTipo,1);
            //return View(myint);
            //return View(await sistemaDePermissaoContext.ToListAsync());
        
            return View( await links);

        }
        
        // GET: links/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var links = await _context.links
                .Include(l => l.tipoDeUsuario)
                .FirstOrDefaultAsync(m => m.LinksID == id);
            if (links == null)
            {
                return NotFound();
            }

            return View(links);
        }

        // GET: links/Create
        public IActionResult Create()
        {
            ViewData["tipoDeUsuarioId"] = new SelectList(_context.TipoDeUsuario, "Id", "Descriçao");
            return View();
        }

        // POST: links/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinksID,descricao,tipoDeUsuarioId")] links links)
        {
            if (ModelState.IsValid)
            {
                _context.Add(links);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tipoDeUsuarioId"] = new SelectList(_context.TipoDeUsuario, "Id", "Descriçao", links.tipoDeUsuarioId);
            return View(links);
        }

        // GET: links/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var links = await _context.links.FindAsync(id);
            if (links == null)
            {
                return NotFound();
            }
            ViewData["tipoDeUsuarioId"] = new SelectList(_context.TipoDeUsuario, "Id", "Descriçao", links.tipoDeUsuarioId);
            return View(links);
        }

        // POST: links/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LinksID,descricao,tipoDeUsuarioId")] links links)
        {
            if (id != links.LinksID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(links);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!linksExists(links.LinksID))
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
            ViewData["tipoDeUsuarioId"] = new SelectList(_context.TipoDeUsuario, "Id", "Descriçao", links.tipoDeUsuarioId);
            return View(links);
        }

        // GET: links/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var links = await _context.links
                .Include(l => l.tipoDeUsuario)
                .FirstOrDefaultAsync(m => m.LinksID == id);
            if (links == null)
            {
                return NotFound();
            }

            return View(links);
        }

        // POST: links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var links = await _context.links.FindAsync(id);
            _context.links.Remove(links);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool linksExists(int id)
        {
            return _context.links.Any(e => e.LinksID == id);
        }
    }
}
