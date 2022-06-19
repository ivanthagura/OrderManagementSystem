using Core.Entities;
using Core.Interfaces;
using GraphQL.Types;

namespace Api.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType(IOrder orderService)
        {
            Field(c => c.Id);
            Field(c => c.FirstName);
            Field(c => c.LastName);
            Field(c => c.ContactNumber);
            Field(c => c.Address);
            Field(c => c.Email);
            Field(c => c.FirstContactMethod);
            Field<ListGraphType<OrderType>>("orders", resolve: context => {
                return orderService.GetCustomerOrders(context.Source.Id);
            });
        }
    }
}