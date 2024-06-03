using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APIS_EntityFramework_NET.Controllers
{
    [ApiController]
    [Route("[controller]")]    // -> rota da qual ele virá
    public class UsuarioController : ControllerBase
    {
        // criacao de um metodo que retorna data e hora atual

        [HttpGet("ObterDataHoraAtual")] 
          // Nome que será usado, não precisam ter o mesmo nome do método correspondente
        public IActionResult ObterDataHora()
        {
            var obj = new 
            {
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortDateString()
            };
            return Ok(obj); // retornar uma requisiçao http, um objeto, que é nesse caso o metodo OK()
        }

        [HttpGet("Apresentar/{nome}")] 
        // mostra que é um campo obrigatório ao campo correspondente, ou seja poderia ter informacoes diferentes relacionadas a nomes diferentes. Basicamente seria tambem para documentar, o que precisa para retonar o que se deseja.
        public IActionResult Apresentar(string nome)
        {
            var mensagem = $"Olá {nome}, seja bem vindo!";
            return Ok(new { mensagem});
        }
    }
}