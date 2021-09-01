using GraphQL_Data.Context;
using GraphQL_Domain;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace GraphQL_Data.Types
{
    [GraphQLDescription("Representa querys das entidades.")]
    public class Query
    {
        [UseDbContext(typeof(GraphQLContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Resgata uma lista de pacientes.")]
        public IQueryable<Paciente> GetPaciente([ScopedService] GraphQLContext context)
        {
            return context.Pacientes;
        }

        [UseDbContext(typeof(GraphQLContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Resgata uma lista de clínicas.")]
        public IQueryable<Clinica> GetClinica([ScopedService] GraphQLContext context)
        {
            return context.Clinicas;
        }
    }
}
