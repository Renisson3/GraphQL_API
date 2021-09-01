using GraphQL_Domain;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.ContextAcess
{
    public interface IContextAcess
    {
        DbSet<Clinica> Clinicas { get; set; }
        DbSet<Paciente> Pacientes { get; set; }
        DbSet<Medico> Medicos { get; set; }
    }
}
