namespace ServerStatisticsCollectionService.Interfaces;

public interface IMessagePublisher
{
    public Task<bool> PublishMessageAsync();
}