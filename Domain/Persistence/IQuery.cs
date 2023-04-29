namespace Domain.Persistence
{
    public interface IQuery<T>
    {
        IQueryable<T> Query();
    }
}
