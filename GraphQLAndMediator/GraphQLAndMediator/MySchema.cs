namespace GraphQLAndMediator
{
    public class MySchema : GraphQL.Types.Schema
    {
        public MySchema(MyQuery myQuery)
        {
            Query = myQuery;
        }
    }
}
