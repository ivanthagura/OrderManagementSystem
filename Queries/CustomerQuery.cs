using Api.Types;
using Core.Interfaces;
using GraphQL;
using GraphQL.Types;

namespace Api.Queries
{
    public class CustomerQuery : ObjectGraphType
    {
        public CustomerQuery(ICustomer customerService)
        {
            Field<ListGraphType<CustomerType>>("customers", resolve: context => {
                return customerService.GetAllCustomers();
            });

            Field<CustomerType>("customer", 
                arguments: new QueryArguments(new QueryArgument<IntGraphType>{ Name = "id"}),
                resolve: context => {
                    return customerService.GetCustomerById(context.GetArgument<int>("id"));
                }
            );
        }
    }
}