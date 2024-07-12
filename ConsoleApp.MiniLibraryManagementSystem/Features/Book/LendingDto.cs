namespace ConsoleApp.MiniLibraryManagementSystem.Features.Book;

public class LendingDto
{
    public string ISBN { get; set; }
    public int UserId { get; set; }
    public DateTime LendDate { get; set; }
}
