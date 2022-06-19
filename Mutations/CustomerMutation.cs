using Api.Types;
using Core.Entities;
using Core.Interfaces;
using GraphQL;
using GraphQL.Types;

namespace Api.Mutations
{
    public class CustomerMutation : ObjectGraphType
    {
        public CustomerMutation(ICustomer customerService)
        {
            Field<CustomerType>("createCustomer", 
                arguments: new QueryArguments(new QueryArgument<CustomerInputType>{ Name = "customer"}),
                resolve: context => {
                    return customerService.AddCustomer(context.GetArgument<Customer>("customer"));
                }
            );

            Field<CustomerType>("updateCustomer", 
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>{ Name = "id"},
                    new QueryArgument<CustomerInputType>{ Name = "customer"}
                ),
                resolve: context => {
                    var customerId = context.GetArgument<int>("id");
                    var customer = context.GetArgument<Customer>("customer");
                    return customerService.UpdateCustomer(customerId, customer);
                }
            );

            Field<CustomerType>("deleteCustomer", 
                arguments: new QueryArguments(new QueryArgument<IntGraphType>{ Name = "id"}),
                resolve: context => {
                    var customerId = context.GetArgument<int>("id");
                    customerService.DeleteCustomer(customerId);
                    return "Customer " + customerId + " has been deleted";
                }
            );
        }
    }
}