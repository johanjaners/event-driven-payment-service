namespace PaymentService.Application.Dispatchers;

public interface IEventDispatcher
{
    Task Dispatch(string topic, string json);
}