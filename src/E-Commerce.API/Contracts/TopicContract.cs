namespace E_Commerce.API.Contracts
{
    public record TopicContract(string Topic, string Message, string BootstrapServer = "http://kafka:9092")
    {
    }
}
