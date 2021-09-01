using GraphQL_Data.Context;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace GraphQL_Domain.Types
{
    public class PacienteType : ObjectType<Paciente>
    {
        protected override void Configure(IObjectTypeDescriptor<Paciente> descriptor)
        {
            descriptor.Description("Representa os pacientes que são clitens das clinicas.");

            descriptor
                .Field(p => p.Id)
                .Description("Representa o identificador do paciente.");

            descriptor
                .Field(p => p.Nome)
                .Description("Representa o nome do paciente.");

            descriptor
                .Field(p => p.Idade)
                .Description("Representa o nome do paciente.");

            descriptor
                .Field(p => p.Peso)
                .Description("Representa o nome do paciente.");

            descriptor
                .Field(p => p.Altura)
                .Description("Representa o nome do paciente.");

            descriptor
                .Field(p => p.Imc)
                .Description("Representa o nome do paciente.")
                .Ignore();

            descriptor
                .Field(c => c.ClinicaId)
                .Description("Representa o indentificado da clínica que o paciente está cadastrado.");

            descriptor
                .Field(p => p.Clinica)
                .ResolveWith<Resolvers>(p => p.GetClinica(default!, default!))
                .UseDbContext<GraphQLContext>()
                .Description("Representa a clinica que o paciente está cadastrado.");
        }

        private class Resolvers
        {
            public Clinica GetClinica(Paciente paciente, [ScopedService] GraphQLContext context)
            {
                return context.Clinicas.FirstOrDefault(c => c.Id == paciente.ClinicaId);
            }
        }
    }
}