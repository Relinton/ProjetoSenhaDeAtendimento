using Microsoft.EntityFrameworkCore;
using SenhaDeAtendimento.Application.Models;

namespace SenhaDeAtendimento.Application.Conexao
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Painel> Painel { get; set; }
    }
}
