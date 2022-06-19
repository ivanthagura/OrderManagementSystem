using GraphQL.Types;

namespace Api.Mutations
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<CustomerMutation>("customerMutation", resolve: context => new {});
            Field<OrderMutation>("orderMutation", resolve: context => new {});
        }
    }
}