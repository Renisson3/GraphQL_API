using GraphQL_Data.Context;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace GraphQL_Domain.Types
{
    public class ClinicaType : ObjectType<Clinica>
    {
        protected override void Configure(IObjectTypeDescriptor<Clinica> descriptor)
        {
            descriptor.Description("Representa as clinicas cadastradas no sistema.");

            descriptor
                .Field(p => p.Id)
                .Description("Representa o identificador da clinica");

            descriptor
                .Field(p => p.Nome)
                .Description("Representa a razão social da clinica");

            descriptor
                .Field(p => p.Pacientes)
                .ResolveWith<Resolvers>(p => p.GetPacientes(default!, default!))
                .UseDbContext<GraphQLContext>()
                .Description("Representa a lista de pacientes cadastrados na clinica.");

            descriptor
                .Field(p => p.Medicos)
                .ResolveWith<Resolvers>(p => p.GetMedicos(default!, default!))
                .UseDbContext<GraphQLContext>()
                .Description("Representa a lista de medicos cadastrados na clinica.");
        }

        private class Resolvers
        {
            public IQueryable<Medico> GetMedicos(Clinica clinica, [ScopedService] GraphQLContext context)
            {
                return context.Medicos.Where(m => m.ClinicaId == clinica.Id);
            }

            public IQueryable<Paciente> GetPacientes(Clinica clinica, [ScopedService] GraphQLContext context)
            {
                return context.Pacientes.Where(p => p.ClinicaId == clinica.Id);
            }

        }
    }
}