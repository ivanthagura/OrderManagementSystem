using GraphQL.Types;

namespace Api.Types
{
    public class OrderInputType : InputObjectGraphType
    {
        public OrderInputType()
        {
            Field<IntGraphType>("id");
            Field<IntGraphType>("CustomerId");
            Field<DateTimeGraphType>("OrderDate");
            Field<StringGraphType>("Description");
            Field<DecimalGraphType>("TotalAmount");
            Field<DecimalGraphType>("DepositAmount");
            Field<DecimalGraphType>("AccountTransferAmount");
            Field<DecimalGraphType>("CashPaidAmount");
            Field<DecimalGraphType>("DueDate");
            Field<DateTimeGraphType>("DesignDueDate");
            Field<StringGraphType>("Background");
            Field<StringGraphType>("MainKeyColor");
            Field<StringGraphType>("DesignElement");
            Field<StringGraphType>("MainLetterColor");
            Field<StringGraphType>("PatternColor");
            Field<BooleanGraphType>("PhotoIncluded");
            Field<DateTimeGraphType>("BaseDesign");
            Field<StringGraphType>("NameOnKey");
            Field<DateTimeGraphType>("DateOfBirth");
            Field<DateTimeGraphType>("PickUpDate");
            Field<BooleanGraphType>("Delivery");
            Field<StringGraphType>("BibleVerse");
            Field<DateTimeGraphType>("EventDate");
            Field<StringGraphType>("OtherNotes");
            //Field<StringGraphType>("OrderStatus");
        }
    }
}