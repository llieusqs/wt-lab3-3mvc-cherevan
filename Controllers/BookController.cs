using wt_lab3_3mvc_cherevan.Models;
using wt_lab3_3mvc_cherevan.Views;

namespace wt_lab3_3mvc_cherevan.Controllers;

public class BookController
{
    private readonly List<Book> books;
    private readonly BookView view;

    public BookController()
    {
        books = new List<Book>
        {
            new Book { Id = 1, Title = "Война и мир", Author = "Л. Толстой", Year = 1869, IsAvailable = true },
            new Book { Id = 2, Title = "Преступление и наказание", Author = "Ф. Достоевский", Year = 1866, IsAvailable = true },
            new Book { Id = 3, Title = "Мастер и Маргарита", Author = "М. Булгаков", Year = 1967, IsAvailable = false }
        };
        view = new BookView();
    }

    public void Index() => view.ShowBooks(books);

    public void Show(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null) { view.ShowMessage("Книга не найдена."); return; }
        view.ShowBook(book);
    }

    public void Add(Book book)
    {
        books.Add(book);
        view.ShowMessage("Книга успешно добавлена.");
    }

    public void Delete(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null) { view.ShowMessage("Книга не найдена."); return; }
        books.Remove(book);
        view.ShowMessage("Книга успешно удалена.");
    }

    public void Search(string text)
    {
        var result = books
            .Where(b => b.Title.Contains(text, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (result.Count == 0) { view.ShowMessage("Ничего не найдено."); return; }
        view.ShowBooks(result);
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("1. Показать все книги");
            Console.WriteLine("2. Найти книгу по ID");
            Console.WriteLine("3. Добавить книгу");
            Console.WriteLine("4. Удалить книгу");
            Console.WriteLine("5. Поиск по названию");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1": Index(); break;
                case "2": ShowBookByUserInput(); break;
                case "3": AddBookByUserInput(); break;
                case "4": DeleteBookByUserInput(); break;
                case "5": SearchByUserInput(); break;
                case "0": return;
                default: view.ShowMessage("Неизвестная команда."); break;
            }
        }
    }

    private void ShowBookByUserInput()
    {
        Console.Write("Введите ID книги: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Show(id);
    }

    private void AddBookByUserInput()
    {
        Console.Write("Введите ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Console.Write("Введите название: ");
        string title = Console.ReadLine() ?? "";

        Console.Write("Введите автора: ");
        string author = Console.ReadLine() ?? "";

        Console.Write("Введите год: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            view.ShowMessage("Некорректный год.");
            return;
        }

        Console.Write("Доступна? (y/n): ");
        bool isAvailable = (Console.ReadLine() ?? "").Trim().ToLower() == "y";

        Add(new Book
        {
            Id = id,
            Title = title,
            Author = author,
            Year = year,
            IsAvailable = isAvailable
        });
    }

    private void DeleteBookByUserInput()
    {
        Console.Write("Введите ID книги: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Delete(id);
    }

    private void SearchByUserInput()
    {
        Console.Write("Введите часть названия: ");
        string text = Console.ReadLine() ?? "";
        Search(text);
    }
}