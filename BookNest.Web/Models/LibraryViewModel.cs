namespace BookNest.Web.Models;

public class LibraryViewModel
{
    public List<Book> Books { get; set; } = [];
    public string Query { get; set; } = "";
    public string Status { get; set; } = "all";
    public int Total { get; set; }
    public int Reading { get; set; }
    public int Finished { get; set; }
    public int WantToRead { get; set; }
}
