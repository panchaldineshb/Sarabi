namespace CICD.Infrastructure.Abstraction
{
    public interface IResponse<out TResponse>
    {
        bool IsSuccessful { get; set; }
    }

    public interface IResponse : IResponse<VoidResponse>
    {
    }
}