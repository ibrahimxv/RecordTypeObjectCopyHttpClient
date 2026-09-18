using ConsoleApp2.Exceptons;
using ConsoleApp2.Extension;
using ConsoleApp2.Interface;
using ConsoleApp2.Model;

namespace ConsoleApp2;

internal class Program
{
    static void Main(string[] args)
    {
        IBookService service = new BookService();

        Book book1 = new Book (
            "Clean Code",
            "Robert Martin",
            400,
            35,
            5,
            Genre.Programming);

        Book book2 = new Book(
            "C# Basics",
            "John Smith",
            300,
            25,
            10,
            Genre.Programming);

        Book book3 = new Book(
            "Physics",
            "Albert Newton",
            500,
            50,
            3,
            Genre.Science);

        Book book4 = new Book(
            "World History",
            "David Brown",
            450,
            40,
            7,
            Genre.History);

        Book book5 = new Book(
            "The Novel",
            "James White",
            350,
            20,
            0,
            Genre.Novel);

        Book book6 = new Book(
            "Unknown World",
            "Michael Green",
            250,
            60,
            2,
            Genre.Other);

        service.Add(book1);
        service.Add(book2);
        service.Add(book3);
        service.Add(book4);
        service.Add(book5);
        service.Add(book6);

        Console.WriteLine("Books added.");

        try
        {
            Book book = service.GetById(1);

            Console.WriteLine(book.GetShortInfo());
        }
        catch (NotFoundExceptions ex)
        {
            Console.WriteLine(ex.Message);
        }

        List<Book> programmingBooks =
            service.GetByGenre(Genre.Programming);

        foreach (Book book in programmingBooks)
        { 
            Console.WriteLine(book.GetShortInfo()); 
        
        }
        Book expensiveBook = service.GetMostExpensiveBook();
        Console.WriteLine(expensiveBook.GetShortInfo());

        Book cheapestBook = service.GetCheapestBook();
        Console.WriteLine(cheapestBook.GetShortInfo());

        double averagePrice = service.GetAveragePrice();
        Console.WriteLine($"{averagePrice} AZN");

        int count = service.CountByGenre(Genre.Programming);
        Console.WriteLine($"Programming kitablarinin sayi: {count}");

        List<Book> books = service.GetByPriceRange(20, 40);
        foreach (Book book in books) 
        { 
            Console.WriteLine(book.GetShortInfo()); 
        }
        Console.WriteLine($"{book1.Title} stokdadir: {book1.IsInStock()}");
        Console.WriteLine($"{book5.Title} stokdadir: {book5.IsInStock()}");

        Console.WriteLine("Endirimden evvel:");
        Console.WriteLine(book1.GetShortInfo());

        book1.ApplyDiscount(20);

        Console.WriteLine("20% endirimden sonra:");
        Console.WriteLine(book1.GetShortInfo());

        try 
        {
            Book duplicateBook = new Book(
                "Clean Code",
                "Robert Martin",
                400,
                35,
                5, 
                Genre.Programming
                );
            service.Add(duplicateBook);
        } 
        catch 

        (ConflictExceptions ex) 
        { 
            Console.WriteLine(ex.Message); 
        }

        try {
            Book book = service.GetById(999);
            Console.WriteLine(book.GetShortInfo());
        } 
        catch (NotFoundExceptions ex) 
        { 
            Console.WriteLine(ex.Message); 
        }
    }
}
