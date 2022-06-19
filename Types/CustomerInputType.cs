using Core.Entities;
using GraphQL.Types;

namespace Api.Types
{
    public class CustomerInputType : InputObjectGraphType
    {
        public CustomerInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("firstName");
            Field<StringGraphType>("lastName");
            Field<StringGraphType>("contactNumber");
            Field<StringGraphType>("address");
            Field<StringGraphType>("email");
            Field<StringGraphType>("firstContactMethod");
        }
    }
}