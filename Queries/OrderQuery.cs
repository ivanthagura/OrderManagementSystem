using Api.Types;
using Core.Interfaces;
using GraphQL;
using GraphQL.Types;

namespace Api.Queries
{
    public class OrderQuery : ObjectGraphType
    {
        public OrderQuery(IOrder orderService)
        {
            Field<ListGraphType<OrderType>>("orders", resolve: context => {
                return orderService.GetAllOrders();
            });

            Field<ListGraphType<OrderType>>("customerOrders", 
                arguments: new QueryArguments(new QueryArgument<IntGraphType>{ Name = "customerId"}),
                resolve: context => {
                return orderService.GetCustomerOrders(context.GetArgument<int>("customerId"));
            });

            Field<OrderType>("order", 
                arguments: new QueryArguments(new QueryArgument<IntGraphType>{ Name = "id"}),
                resolve: context => {
                    return orderService.GetOrderById(context.GetArgument<int>("id"));
                }
            );
        }
    }
}