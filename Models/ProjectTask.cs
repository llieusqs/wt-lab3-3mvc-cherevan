namespace wt_lab3_3mvc_cherevan.Models;

public class ProjectTask
{
    public int Id { get; set; }
    public string Title { get; set; } = "";          // название задачи
    public string Assignee { get; set; } = "";       // исполнитель
    public string Priority { get; set; } = "";       // приоритет: Low / Medium / High
    public int StoryPoints { get; set; }             // оценка сложности (SP)
    public bool IsCompleted { get; set; }            // выполнена ли задача
}