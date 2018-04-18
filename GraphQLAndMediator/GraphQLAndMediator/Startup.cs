using GraphQL;
using GraphQL.Server.Transports.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLAndMediator
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(
                s => new FuncDependencyResolver(type => s.GetRequiredService(type))
            );

            services.AddGraphQLHttp();

            services.AddSingleton<MySchema>();
            services.AddSingleton<MyQuery>();
            services.AddSingleton<UserType>();

            services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseDeveloperGraphiQLPage();
            }

            app.UseGraphQLHttp<MySchema>(new GraphQLHttpOptions());
        }
    }
}
