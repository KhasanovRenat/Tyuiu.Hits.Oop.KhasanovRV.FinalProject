namespace FinalProject.Data
{
    // Характеристики проекта
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public IEnumerable<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }

    // Его возможные статусы
    public static class ProjectStatuses
    {
        public static readonly string[] Statuses = new[]
        {
        "Не начат",
        "В процессе",
        "Завершен"
        };
    }
}

