using wt_lab3_3mvc_cherevan.Models;

namespace wt_lab3_3mvc_cherevan.Views;

public class BookView
{
    public void ShowBooks(List<Book> books)
    {
        Console.WriteLine("=== СПИСОК КНИГ ===");
        if (books.Count == 0)
        {
            Console.WriteLine("(список пуст)");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine(
                $"{book.Id}. {book.Title} | {book.Author} | {book.Year} г. | " +
                $"Доступна: {(book.IsAvailable ? "да" : "нет")}"
            );
        }
    }

    public void ShowBook(Book book)
    {
        Console.WriteLine("=== КНИГА ===");
        Console.WriteLine($"ID: {book.Id}");
        Console.WriteLine($"Название: {book.Title}");
        Console.WriteLine($"Автор: {book.Author}");
        Console.WriteLine($"Год: {book.Year}");
        Console.WriteLine($"Доступна: {(book.IsAvailable ? "да" : "нет")}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}