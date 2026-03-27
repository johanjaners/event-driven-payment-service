namespace PaymentService.Domain.Entities;

public class Invoice
{
    int Id;
    int BookingId;
    InvoiceStatus Status { get; set; } = InvoiceStatus.Pending;
    decimal TotalAmount;
    List<InvoiceLine> Lines;
    DateTime CreatedAt;
    DateTime UpdatedAt;
}
