namespace FinalProject.Data.Interfaces
{
    // Интерфейс методов для проектов
    public interface IDataServiceProject
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task SaveProjectAsync(Project project);
        Task<Project> GetProjectAsync(int id);
        Task DeleteProjectAsync(int id);
	}
}
