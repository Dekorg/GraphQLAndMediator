using GraphQL.Types;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLAndMediator
{
    public class MyQuery : ObjectGraphType
    {
        public MyQuery(IServiceProvider serviceProvider)
        {
            Description = "All queries start here.";

            FieldAsync<ListGraphType<UserType>>(
                "users",
                description: "A list of users.",
                resolve: async context =>
                {
                    // try use mediator here
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        return await Task.FromResult(new List<User>());
                    }
                }
            );
        }
    }
}
