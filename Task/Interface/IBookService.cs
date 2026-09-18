using ConsoleApp2.Model;

namespace ConsoleApp2.Interface;

public interface IBookService
{
    void Add(Book book);

    Book GetById(int id);

    List<Book> GetByGenre(Genre genre);

    Book GetMostExpensiveBook();

    Book GetCheapestBook();

    double GetAveragePrice();

    int CountByGenre(Genre genre);

    List<Book> GetByPriceRange(double min, double max);
}
