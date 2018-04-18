using GraphQL.Types;

namespace GraphQLAndMediator
{
    public class UserType : ObjectGraphType<User>
    {
        public static class FieldNames
        {
            public const string Id = "id";
        }

        public UserType()
        {
            Name = "User";
            Description = "A user.";

            Field<IntGraphType>(
                FieldNames.Id,
                description: "A unique identifier for the user.",
                resolve: context => context.Source?.Id
            );
        }
    }
}
