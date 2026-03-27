namespace PaymentService.Domain.Entities;

public class InvoiceLine
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Amount { get; set; }
    public string ServiceType { get; set; }
};