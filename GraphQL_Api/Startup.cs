using Fator.IRPF.Servicos.Infra;
using GraphQL_Data.Types;
using GraphQL_Domain.Types;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GraphQL_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework(Configuration.GetConnectionString("BD_TESTE"));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQL_Api", Version = "v1" });
            });
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<PacienteType>()
                .AddType<ClinicaType>()
                .AddFiltering()
                .AddSorting()

                .AddInMemorySubscriptions();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL_Api v1"));
            }

            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });

            app.UseVoyager(new VoyagerOptions
            {
                Path = "/graphql-voyager",
                QueryPath = "/graphql"
            });
        }
    }
}
