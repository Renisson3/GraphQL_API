using GraphQL_API.ContextAcess;
using GraphQL_Data.Mappings;
using GraphQL_Domain;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_Data.Context
{
    public class GraphQLContext : DbContext, IContextAcess
    {
        public GraphQLContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Clinica>().Map();
            modelBuilder.Entity<Paciente>().Map();
            modelBuilder.Entity<Medico>().Map();
        }
    }
}