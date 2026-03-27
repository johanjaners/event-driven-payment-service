using PaymentService.Domain.Enums;
namespace PaymentService.Domain.Entities;

public class Invoice
{
    public Guid Id { get; set; }
    public Guid BookingId { get; set; }

    public InvoiceStatus Status { get; set; } = InvoiceStatus.Pending;

    public decimal TotalAmount { get; set; }

    public List<InvoiceLine> Lines { get; set; } = new();

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
