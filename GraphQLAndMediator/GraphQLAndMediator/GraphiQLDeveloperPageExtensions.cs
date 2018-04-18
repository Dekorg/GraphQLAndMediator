using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods for registering the GraphiQL interface middleware.
    /// </summary>
    public static class GraphiQLDeveloperPageExtensions
    {
        /// <summary>
        /// Maps the GraphiQL interface to /graphiql.
        /// </summary>
        /// <param name="app">App builder instance.</param>
        /// <returns>App builder instance.</returns>
        public static IApplicationBuilder UseDeveloperGraphiQLPage(this IApplicationBuilder app)
        {
            return app.Map("/graphiql", HandleGraphiQL);
        }

        /// <summary>
        /// Handles the mapping, using someone's GitHub GraphiQL compiled page for us ;)
        /// </summary>
        /// <param name="app"></param>
        private static void HandleGraphiQL(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                // TODO: Use HttpClientFactory when released
                var httpClient = new HttpClient();

                var uri = "https://raw.githubusercontent.com/JuergenGutsch/graphql-aspnetcore/master/GraphQL.AspNetCore.Graphiql/graphiql.html";
                var content = (await httpClient.GetStringAsync(uri))
                    .Replace("'/graph'", "'/graphql'");

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(content);
            });
        }
    }
}
