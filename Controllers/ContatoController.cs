using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIS_EntityFramework_NET.Context;
using APIS_EntityFramework_NET.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIS_EntityFramework_NET.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            // construtor
            _context = context;
        } 
         
        [HttpPost] 
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = contato.Id }, contato);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            // Contatos representa nosso dbcontext
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return NotFound();
            }  

            return Ok(contato);
        }
        
        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
            {
                return NotFound();
            }

            contatoBanco.Nome = contato.Nome;                 
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}