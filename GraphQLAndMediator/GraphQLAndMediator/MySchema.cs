using GraphQL;

namespace GraphQLAndMediator
{
    public class MySchema : GraphQL.Types.Schema
    {
        public MySchema(IDependencyResolver dependencyResolver)
            : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<MyQuery>();
        }
    }
}
