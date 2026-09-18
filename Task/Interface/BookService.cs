using ConsoleApp2.Exceptons;
using ConsoleApp2.Model;
using System.Data;

namespace ConsoleApp2.Interface;

public class BookService : IBookService
{
    private static List<Book> books = new List<Book>();

    public void Add(Book book)
    {
        foreach (Book item in books)
        {
            if (item.Title == book.Title && item.Author == book.Author)
            {
                throw new ConflictExceptions("Bu muellife aid kitab movcuddur");
            }
        }

        books.Add(book);
    }

    public Book GetById(int id)
    {
        foreach (Book book in books)
        {
            if (book.Id == id)
            {
                return book;
            }
        }

        throw new NotFoundExceptions("Kitab tapilmadi!");
    }

    public List<Book> GetByGenre(Genre genre)
    {
        List<Book> result = new List<Book>();

        foreach (Book book in books)
        {
            if (book.Genre == genre)
            {
                result.Add(book);
            }
        }

        return result;
    }

    public Book GetMostExpensiveBook()
    {
        Book mostExpensive = books[0];

        foreach (Book book in books)
        {
            if (book.Price > mostExpensive.Price)
            {
                mostExpensive = book;
            }
        }

        return mostExpensive;
    }

    public Book GetCheapestBook()
    {
        Book cheapest = books[0];

        foreach (Book book in books)
        {
            if (book.Price < cheapest.Price)
            {
                cheapest = book;
            }
        }

        return cheapest;
    }

    public double GetAveragePrice()
    {
        double total = 0;

        foreach (Book book in books)
        {
            total += book.Price;
        }

        return total / books.Count;
    }

    public int CountByGenre(Genre genre)
    {
        int count = 0;

        foreach (Book book in books)
        {
            if (book.Genre == genre)
            {
                count++;
            }
        }

        return count;
    }

    public List<Book> GetByPriceRange(double min, double max)
    {
        List<Book> result = new List<Book>();

        foreach (Book book in books)
        {
            if (book.Price >= min && book.Price <= max)
            {
                result.Add(book);
            }
        }

        return result;
    }
}
