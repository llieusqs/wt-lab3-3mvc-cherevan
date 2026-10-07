using wt_lab3_3mvc_cherevan.Models;
using wt_lab3_3mvc_cherevan.Views;

namespace wt_lab3_3mvc_cherevan.Controllers;

public class TaskController
{
    private readonly List<ProjectTask> tasks;
    private readonly TaskView view;

    public TaskController()
    {
        tasks = new List<ProjectTask>
        {
            new ProjectTask { Id = 1, Title = "Настроить CI/CD", Assignee = "Иванов", Priority = "High", StoryPoints = 8, IsCompleted = false },
            new ProjectTask { Id = 2, Title = "Спроектировать БД", Assignee = "Петров", Priority = "High", StoryPoints = 5, IsCompleted = true },
            new ProjectTask { Id = 3, Title = "Написать API авторизации", Assignee = "Сидоров", Priority = "Medium", StoryPoints = 3, IsCompleted = false },
            new ProjectTask { Id = 4, Title = "Обновить документацию", Assignee = "Иванов", Priority = "Low", StoryPoints = 2, IsCompleted = true }
        };
        view = new TaskView();
    }

    public void Index() => view.ShowTasks(tasks);

    public void Show(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) { view.ShowMessage("Задача не найдена."); return; }
        view.ShowTask(task);
    }

    public void Add(ProjectTask task)
    {
        tasks.Add(task);
        view.ShowMessage("Задача успешно добавлена.");
    }

    public void Delete(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) { view.ShowMessage("Задача не найдена."); return; }
        tasks.Remove(task);
        view.ShowMessage("Задача успешно удалена.");
    }

    // === Дополнительная операция: подсчёт общего количества Story Points ===
    public void TotalStoryPoints()
    {
        int total = tasks.Sum(t => t.StoryPoints);
        view.ShowMessage($"Общее количество Story Points: {total}");
    }

    // === Дополнительная операция: поиск по исполнителю ===
    public void SearchByAssignee(string name)
    {
        var result = tasks
            .Where(t => t.Assignee.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (result.Count == 0) { view.ShowMessage("Задачи не найдены."); return; }
        view.ShowTasks(result);
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("1. Показать все задачи");
            Console.WriteLine("2. Найти задачу по ID");
            Console.WriteLine("3. Добавить задачу");
            Console.WriteLine("4. Удалить задачу");
            Console.WriteLine("5. Найти задачи по исполнителю");
            Console.WriteLine("6. Суммарные Story Points");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1": Index(); break;
                case "2": ShowTaskByUserInput(); break;
                case "3": AddTaskByUserInput(); break;
                case "4": DeleteTaskByUserInput(); break;
                case "5": SearchByUserInput(); break;
                case "6": TotalStoryPoints(); break;
                case "0": return;
                default: view.ShowMessage("Неизвестная команда."); break;
            }
        }
    }

    private void ShowTaskByUserInput()
    {
        Console.Write("Введите ID задачи: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Show(id);
    }

    private void AddTaskByUserInput()
    {
        Console.Write("Введите ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Console.Write("Введите название задачи: ");
        string title = Console.ReadLine() ?? "";

        Console.Write("Введите исполнителя: ");
        string assignee = Console.ReadLine() ?? "";

        Console.Write("Введите приоритет (Low/Medium/High): ");
        string priority = Console.ReadLine() ?? "Medium";

        Console.Write("Введите Story Points: ");
        if (!int.TryParse(Console.ReadLine(), out int sp))
        {
            view.ShowMessage("Некорректное значение Story Points.");
            return;
        }

        Console.Write("Задача выполнена? (y/n): ");
        bool isCompleted = (Console.ReadLine() ?? "").Trim().ToLower() == "y";

        Add(new ProjectTask
        {
            Id = id,
            Title = title,
            Assignee = assignee,
            Priority = priority,
            StoryPoints = sp,
            IsCompleted = isCompleted
        });
    }

    private void DeleteTaskByUserInput()
    {
        Console.Write("Введите ID задачи: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Delete(id);
    }

    private void SearchByUserInput()
    {
        Console.Write("Введите имя исполнителя: ");
        string text = Console.ReadLine() ?? "";
        SearchByAssignee(text);
    }
}