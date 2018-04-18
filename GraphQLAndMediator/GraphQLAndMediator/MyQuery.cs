using GraphQL.Types;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLAndMediator
{
    public class MyQuery : ObjectGraphType
    {
        public MyQuery(IMediator mediator)
        {
            Description = "All queries start here.";

            FieldAsync<ListGraphType<UserType>>(
                "users",
                description: "A list of users.",
                resolve: async context =>
                {
                    // try use mediator here


                    return await Task.FromResult(new List<User>());
                }
            );
        }
    }
}
