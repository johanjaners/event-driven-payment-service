namespace PaymentService.Application.Events;

public class BookingCreatedEvent
{
    public Guid EventId { get; set; }
    public Guid BookingId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
}