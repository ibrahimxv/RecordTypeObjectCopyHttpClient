namespace ConsoleApp2.Model;

public class Book
{
    private static int _id;
    public int Id { get;}

    public Book(
        string title,
        string author,
        int pageCount,
        double price,
        int stockCount,
        Genre genre)
    {
        Id = ++_id;

        Title = title;
        Author = author;
        PageCount = pageCount;
        Price = price;
        StockCount = stockCount;
        Genre = genre;
        CreatedAt = DateTime.Now;
    }

    public string? Title { get; set; }
    public int PageCount { get; set; }
    public double Price { get; set; }
    public int StockCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public Genre Genre { get; set; }
    public string Author { get; set; }
}
