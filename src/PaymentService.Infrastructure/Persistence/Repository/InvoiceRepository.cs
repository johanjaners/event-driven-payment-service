using Microsoft.EntityFrameworkCore;
using PaymentService.Domain.Entities;

namespace PaymentService.Infrastructure.Persistence;

public class InvoiceRepository(PaymentDbContext db)
{
    public async Task<Invoice?> GetByBookingIdAsync(
        Guid bookingId,
        CancellationToken ct = default)
    {
        return await db.Invoices
            .Include(x => x.Lines)
            .FirstOrDefaultAsync(x => x.BookingId == bookingId, ct);

    }
    public async Task<Invoice?> GetByIdAsync(
        Guid invoiceId,
        CancellationToken ct = default)
    {
        return await db.Invoices
            .FirstOrDefaultAsync(x => x.Id == invoiceId, ct);
    }
    // Task AddAsync(Invoice invoice, CancellationToken cancellationToken = default);
    // Task UpdateAsync(Invoice invoice, CancellationToken cancellationToken = default);
}