using Microsoft.AspNetCore.Mvc;
using SenhaDeAtendimento.Application.Conexao;
using SenhaDeAtendimento.Application.Models;
using System;
using System.Linq;

namespace SenhaDeAtendimento.Application.Controllers
{
    public class PainelController : Controller
    {
        private readonly Contexto _contexto;

        public PainelController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpPost("/api/ListarSenhas")]
        public JsonResult ListarSenhas()
        {
            var senhas = _contexto.Painel.Take(5)
                .OrderByDescending(s => s.Id).ToList();

            return Json(new { senhas = senhas, senha = senhas.FirstOrDefault() });
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Painel painel)
        {
            try
            {
                _contexto.Painel.Add(painel);
                _contexto.SaveChanges();

                return RedirectToAction(nameof(Cadastrar));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
