using System.Net.Security;
using FinalProject.Data.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;

namespace FinalProject.Data.Services
{
    public class MSSQLDataService(ApplicationDbContext context) : IDataServiceProject, IDataServiceTaskItem
    {
        // ПРОЕКТЫ
        
        // удалить
        public async Task DeleteProjectAsync(int id)
        {
            var project = await context.Projects.FirstAsync(p => p.Id == id);
            context.Projects.Remove(project);
            await context.SaveChangesAsync();
        }

        // получить полный список
        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await context.Projects.ToArrayAsync();
        }

        // получить элемент списка
        public async Task<Project> GetProjectAsync(int id)
        {
            return await context.Projects
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // сохранить новое/измененное
        public async Task SaveProjectAsync(Project project)
        {
            if (project.Id == 0)
            {
                await context.Projects.AddAsync(project);
            }
            else
            {
                var existingProject = await context.Projects
                    .Include(p => p.Tasks)
                    .FirstOrDefaultAsync(p => p.Id == project.Id);
                if (existingProject != null)
                {
                    existingProject.Name = project.Name;
                    existingProject.Status = project.Status;
                    existingProject.Tasks = project.Tasks;
                    context.Projects.Update(existingProject);
                }
            }
            await context.SaveChangesAsync();
        }

		// ЗАДАЧИ

        // удалить
		public async Task DeleteTaskAsync(int id)
        {
            var taskItem = await context.Tasks.FirstAsync(t => t.Id == id);
            context.Tasks.Remove(taskItem);
            await context.SaveChangesAsync();
        }

        // получить полный список
        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await context.Tasks.ToArrayAsync();
        }

        // получить элемент списка
        public Task<TaskItem> GetTaskAsync(int id)
        {
            return context.Tasks.FirstAsync(p => p.Id == id);
        }

        // получить список задач связанный с конкретным проектом
        public async Task<IEnumerable<TaskItem>> GetTasksByProjectIdAsync(int projectId)
        {
            return await context.Tasks
                .Where(t => t.ProjectId == projectId)
                .ToArrayAsync();
        }


        // сохранить новое/измененное
        public async Task SaveTaskAsync(TaskItem taskItem)
        {
            if (taskItem.Id == 0)
            {
                await context.Tasks.AddAsync(taskItem);
            }
            else
            {
                context.Tasks.Update(taskItem);
            }
            await context.SaveChangesAsync();
        }

	}
}
