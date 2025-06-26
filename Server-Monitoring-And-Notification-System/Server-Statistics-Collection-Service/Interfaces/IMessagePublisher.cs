namespace Server_Statistics_Collection_Service.Interfaces;

public interface IMessagePublisher
{
    public Task<bool> PublishMessage();
}