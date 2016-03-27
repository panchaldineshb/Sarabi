namespace CICD.Infrastructure.Abstraction
{
    public interface IRequest<out TResponse>
    {
    }

    public interface IRequest : IRequest<VoidResponse>
    {
    }
}