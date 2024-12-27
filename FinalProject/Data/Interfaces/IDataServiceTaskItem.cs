namespace FinalProject.Data.Interfaces
{
    // Интерфейс методов для задач
    public interface IDataServiceTaskItem
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task SaveTaskAsync(TaskItem task);
        Task<TaskItem> GetTaskAsync(int id);
        Task DeleteTaskAsync(int id);
        Task<IEnumerable<TaskItem>> GetTasksByProjectIdAsync(int projectId);
	}
}
