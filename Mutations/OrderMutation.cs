using Api.Types;
using Core.Entities;
using Core.Interfaces;
using GraphQL;
using GraphQL.Types;

namespace Api.Mutations
{
    public class OrderMutation : ObjectGraphType
    {
        public OrderMutation(IOrder orderService)
        {
            Field<OrderType>("createOrder", 
                arguments: new QueryArguments(new QueryArgument<OrderInputType>{ Name = "order"}),
                resolve: context => {
                    return orderService.AddOrder(context.GetArgument<Order>("order"));
                }
            );

            Field<OrderType>("updateOrder", 
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>{ Name = "id"},
                    new QueryArgument<OrderInputType>{ Name = "order"}
                ),
                resolve: context => {
                    var orderId = context.GetArgument<int>("id");
                    var customer = context.GetArgument<Order>("customer");
                    return orderService.UpdateOrder(orderId, customer);
                }
            );

            Field<OrderType>("deleteOrder", 
                arguments: new QueryArguments(new QueryArgument<IntGraphType>{ Name = "id"}),
                resolve: context => {
                    var orderId = context.GetArgument<int>("id");
                    orderService.DeleteOrder(orderId);
                    return "Order " + orderId + " has been deleted";
                }
            );
        }
    }
}