using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogWendel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace BlogWendel.Controllers
{
    [Authorize(Policy = "RequireEmail")]
    public class MensagemController : Controller
    {
        private readonly BlogWendelContext _context;
        private IHostingEnvironment _environment;

        public MensagemController(BlogWendelContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Mensagem
        public async Task<IActionResult> Index()
        {
            var blogWendelContext = _context.Mensagem
                .Include(m => m.Comentarios)
                .Include(m => m.Categoria);
            return View(await blogWendelContext.ToListAsync());
        }

        // GET: Mensagem/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem
                .Include(m => m.Categoria)
                .FirstOrDefaultAsync(m => m.MensagemId == id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return View(mensagem);
        }

        // GET: Mensagem/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Descricao");
            return View();
        }

        // POST: Mensagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MensagemId,Titulo,Descricao,DataMensagem,CategoriaId")] Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Descricao", mensagem.CategoriaId);
            return View(mensagem);
        }


        // GET: Mensagem/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem.FindAsync(id);
            if (mensagem == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Descricao", mensagem.CategoriaId);
            return View(mensagem);
        }

        // POST: Mensagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MensagemId,Titulo,Descricao,DataMensagem,CategoriaId")] Mensagem mensagem)
        {
            if (id != mensagem.MensagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensagemExists(mensagem.MensagemId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Descricao", mensagem.CategoriaId);
            return View(mensagem);
        }

        // GET: Mensagem/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem
                .Include(m => m.Categoria)
                .FirstOrDefaultAsync(m => m.MensagemId == id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return View(mensagem);
        }

        // POST: Mensagem/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensagem = await _context.Mensagem.FindAsync(id);
            _context.Mensagem.Remove(mensagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensagemExists(int id)
        {
            return _context.Mensagem.Any(e => e.MensagemId == id);
        }
        public async Task<Comentario> ComentariosMensagem(Mensagem mensagem)
        {
            var comentario = await _context.Comentario
              .Include(c => c.Mensagem)
              .FirstOrDefaultAsync(c => c.MensagemId == mensagem.MensagemId);
            ViewData["ComentarioId"] = new SelectList(_context.Comentario, "Id", "Descricao", mensagem.CategoriaId);
            return comentario;
        }
    }
}
