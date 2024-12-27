namespace FinalProject.Data
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public int EstimatedHours { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }

    public static class TaskStatuses
    {
        public static readonly string[] Statuses = new[]
        {
        "Предстоящие",
        "В процессе",
        "Выполненные"
        };
    }
}
