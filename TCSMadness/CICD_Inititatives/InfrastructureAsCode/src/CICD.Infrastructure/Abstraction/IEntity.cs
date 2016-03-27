namespace CICD.Infrastructure.Abstraction
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}