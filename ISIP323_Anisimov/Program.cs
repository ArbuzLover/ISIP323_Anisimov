
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
List<Book> library = new List<Book>();
library.Add(new Book("Майн Кампф","Адольф Г.",Genre.comedy, 1924,1000));
library.Add(new Book("Как жить с огромным члено?", "Башкалова Алиса Алексеевна", Genre.drama,2007, 100000));
library.Add(new Book("Дневник зомби", "Стив", Genre.drama, 2026, 500));
library.Add(new Book("Букварь", "АБВГДЕЙКО", Genre.comedy, 2000,500));
library.Add(new Book("Макан.История успеха","Башкалова Алиса Алексеевна", Genre.fantasy, 2025,1000000));



static void VivodAll(List<Book> library)
{
    if (!library.Any()) { Console.WriteLine("Список товаров пуст."); return; }
    foreach (var p in library) p.Vivod();
}

static void AddBook(List<Book> library)
{

}

static void DelBook(List<Book> library)
{

}

static void FindBook(List<Book> library) 
{ 

}

static void SortByName(List<Book> library)
{

}

static void SortByYear(List<Book> library)
{

}

static void SortByPrice(List<Book> library) 
{ 

}

static void CountBooks(List<Book> library)
{

}

public enum Genre
{
    fantasy = 0,
    comedy = 1,
    novel = 2,
    drama = 3
}

public class Book
{
    public static int ids = 0;
    public int id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }

    public Genre Genre {get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }

    public Book(string name, string author, Genre genre, int year, decimal price)
    {
        Name = name;
        Author = author;
        Genre = genre;  
        Year = year;
        Price = price;
    }

    public void Vivod() { Console.WriteLine($"ID: {id} | Название: {Name} | Автор: {Author} | Жанр: {Genre} | Год создания: {Year} | Цена: {Price:F2} "); }
}