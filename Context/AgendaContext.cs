using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIS_EntityFramework_NET.Entities;
using Microsoft.EntityFrameworkCore; // Pacote instalado, dele vem a classe DbContext

namespace APIS_EntityFramework_NET.Context
{
    public class AgendaContext : DbContext
    {
        // Criar construtor para dar um apontamento para o database
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
            // vai receber a conexão do banco e passar para o DbContext
        }

        public DbSet<Contato> Contatos{get; set;} // classe contato está dentro de um DbSet pq está sendo reprsentado por uma classe, e será uma tabela no banco de dados.
    }
}