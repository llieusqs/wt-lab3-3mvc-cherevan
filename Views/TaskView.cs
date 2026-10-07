using wt_lab3_3mvc_cherevan.Models;

namespace wt_lab3_3mvc_cherevan.Views;

public class TaskView
{
    public void ShowTasks(List<ProjectTask> tasks)
    {
        Console.WriteLine("=== СПИСОК ЗАДАЧ ===");
        if (tasks.Count == 0)
        {
            Console.WriteLine("(список пуст)");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine(
                $"{task.Id}. {task.Title} | " +
                $"Исполнитель: {task.Assignee} | " +
                $"Приоритет: {task.Priority} | " +
                $"SP: {task.StoryPoints} | " +
                $"Статус: {(task.IsCompleted ? "выполнена" : "в работе")}"
            );
        }
    }

    public void ShowTask(ProjectTask task)
    {
        Console.WriteLine("=== ЗАДАЧА ===");
        Console.WriteLine($"ID: {task.Id}");
        Console.WriteLine($"Название: {task.Title}");
        Console.WriteLine($"Исполнитель: {task.Assignee}");
        Console.WriteLine($"Приоритет: {task.Priority}");
        Console.WriteLine($"Story Points: {task.StoryPoints}");
        Console.WriteLine($"Статус: {(task.IsCompleted ? "выполнена" : "в работе")}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}