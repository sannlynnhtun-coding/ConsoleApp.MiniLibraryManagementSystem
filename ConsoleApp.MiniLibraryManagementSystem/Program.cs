using ConsoleApp.MiniLibraryManagementSystem;
using ConsoleApp.MiniLibraryManagementSystem.Features.Book;
using ConsoleApp.MiniLibraryManagementSystem.Features.Report;
using ConsoleApp.MiniLibraryManagementSystem.Features.User;

Console.WriteLine("Welcome to the Library Management System!");

var bookManager = new BookManager();
var userManager = new UserManager();

// Sample usage
userManager.RegisterUser("John Doe", "john.doe@example.com", "password123");
var userId = userManager.AuthenticateUser("john.doe@example.com", "password123");

if (userId != null)
{
    bookManager.AddBook("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565");
    bookManager.LendBook("9780743273565", userId.Value);
    bookManager.ReturnBook("9780743273565", userId.Value);

    // Pass data to the report manager
    var reportManager = new ReportManager(bookManager.GetBooks(), bookManager.GetLendings(), userManager.GetUsers());

    reportManager.GenerateBookReport();
    reportManager.GenerateUserActivityReport();
}
else
{
    Console.WriteLine("Authentication failed.");
}