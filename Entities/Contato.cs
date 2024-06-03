using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIS_EntityFramework_NET.Entities
{
    // Esta classe é basicamente um espelho para ser transformado em uma tabela no banco de dados.
    public class Contato
    {
        public int Id { get; set; }     // Como vai virar uma tabela, precisa de um Id
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }


    }
}