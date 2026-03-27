using PaymentService.Domain.Entities;

namespace PaymentService.Application.Interfaces;

public interface IPaymentService
{
    Task<Invoice> CreateInvoiceAsync(Guid bookingId, decimal amount, CancellationToken cancellationToken = default);
    Task MarkAsPaidAsync(Guid invoiceId, CancellationToken cancellationToken = default);
    Task MarkAsFailedAsync(Guid invoiceId, CancellationToken cancellationToken = default);
}