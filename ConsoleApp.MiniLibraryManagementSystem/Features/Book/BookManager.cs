using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.MiniLibraryManagementSystem.Features.Book;

public class BookManager
{
    private List<BookDto> books = new List<BookDto>();
    private List<LendingDto> lendings = new List<LendingDto>();

    public void AddBook(string title, string author, string isbn)
    {
        books.Add(new BookDto { Title = title, Author = author, ISBN = isbn });
        Console.WriteLine($"Book '{title}' added.");
    }

    public void LendBook(string isbn, int userId)
    {
        var book = books.Find(b => b.ISBN == isbn);
        if (book != null)
        {
            lendings.Add(new LendingDto { ISBN = isbn, UserId = userId, LendDate = DateTime.Now });
            Console.WriteLine($"Book '{book.Title}' lent to user {userId}.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    public void ReturnBook(string isbn, int userId)
    {
        var lending = lendings.Find(l => l.ISBN == isbn && l.UserId == userId);
        if (lending != null)
        {
            lendings.Remove(lending);
            Console.WriteLine($"Book '{isbn}' returned by user {userId}.");
        }
        else
        {
            Console.WriteLine("Lending record not found.");
        }
    }

    public List<BookDto> GetBooks()
    {
        return books;
    }

    public List<LendingDto> GetLendings()
    {
        return lendings;
    }
}