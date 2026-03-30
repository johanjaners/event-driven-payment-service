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
    public async Task<Invoice> AddAsync(Invoice invoice, CancellationToken ct = default)
    {
        await db.Invoices.AddAsync(invoice, ct);
        await db.SaveChangesAsync(ct);

        return invoice;
    }
    // Task UpdateAsync(Invoice invoice, CancellationToken cancellationToken = default);
}