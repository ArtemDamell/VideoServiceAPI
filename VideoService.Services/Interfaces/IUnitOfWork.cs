namespace VideoService.Services.Interfaces
{
    public interface IUnitOfWork
    {
        ITaskRepository Tasks { get; }
    }
}
