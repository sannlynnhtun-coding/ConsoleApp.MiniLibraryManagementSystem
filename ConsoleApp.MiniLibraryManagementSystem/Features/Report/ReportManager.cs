using ConsoleApp.MiniLibraryManagementSystem.Features.Book;
using ConsoleApp.MiniLibraryManagementSystem.Features.User;

namespace ConsoleApp.MiniLibraryManagementSystem.Features.Report;

public class ReportManager
{
    private List<BookDto> books;
    private List<LendingDto> lendings;
    private List<UserDto> users;

    public ReportManager(List<BookDto> books, List<LendingDto> lendings, List<UserDto> users)
    {
        this.books = books;
        this.lendings = lendings;
        this.users = users;
    }

    public void GenerateBookReport()
    {
        Console.WriteLine("Book Report:");
        Console.WriteLine("------------");

        foreach (var book in books)
        {
            var isLentOut = lendings.Any(l => l.ISBN == book.ISBN);
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Status: {(isLentOut ? "Lent Out" : "Available")}");
        }

        Console.WriteLine();
    }

    public void GenerateUserActivityReport()
    {
        Console.WriteLine("User Activity Report:");
        Console.WriteLine("----------------------");

        foreach (var user in users)
        {
            var userLendings = lendings.Where(l => l.UserId == user.Id).ToList();
            Console.WriteLine($"User: {user.Name}, Email: {user.Email}");

            if (userLendings.Any())
            {
                foreach (var lending in userLendings)
                {
                    var book = books.First(b => b.ISBN == lending.ISBN);
                    Console.WriteLine($"  Lent Book: {book.Title}, ISBN: {book.ISBN}, Lend Date: {lending.LendDate}");
                }
            }
            else
            {
                Console.WriteLine("  No lending records.");
            }
        }

        Console.WriteLine();
    }
}