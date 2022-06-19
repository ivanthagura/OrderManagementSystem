using GraphQL.Types;

namespace Api.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<CustomerQuery>("customerQuery", resolve: context => new {});
            Field<OrderQuery>("orderQuery", resolve: context => new {});
        }
    }
}