using Core.Entities;
using GraphQL.Types;

namespace Api.Types
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(c => c.Id);
            Field(c => c.CustomerId);
            Field(c => c.OrderDate);
            Field(c => c.Description);
            Field(c => c.TotalAmount);
            Field(c => c.DepositAmount);
            Field(c => c.AccountTransferAmount);
            Field(c => c.CashPaidAmount);
            Field(c => c.DeliveryCost);
            Field(c => c.DueDate);
            Field(c => c.DesignDueDate);
            Field(c => c.Background);
            Field(c => c.MainKeyColor);
            Field(c => c.DesignElement);
            Field(c => c.MainLetterColor);
            Field(c => c.PatternColor);
            Field(c => c.PhotoIncluded);
            Field(c => c.BaseDesign);
            Field(c => c.NameOnKey);
            Field(c => c.DateOfBirth);
            Field(c => c.PickUpDate);
            Field(c => c.Delivery);
            Field(c => c.BibleVerse);
            Field(c => c.EventDate);
            Field(c => c.OtherNotes);
            //Field(c => c.OrderStatus);
        }
    }
}