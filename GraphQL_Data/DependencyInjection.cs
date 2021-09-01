using GraphQL_API.ContextAcess;
using GraphQL_Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fator.IRPF.Servicos.Infra
{
    public static class DependencyInjection
    {
        public static void AddEntityFramework(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IContextAcess, GraphQLContext>();

            services.AddPooledDbContextFactory<GraphQLContext>(
                options =>
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("GraphQL_Data")));
        }
    }
}