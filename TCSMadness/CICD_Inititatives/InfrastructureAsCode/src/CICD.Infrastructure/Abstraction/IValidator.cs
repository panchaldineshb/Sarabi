namespace CICD.Infrastructure.Abstraction
{
    public interface IValidator<T> where T : IEntity<int>
    {
        bool Validate();
    }
}