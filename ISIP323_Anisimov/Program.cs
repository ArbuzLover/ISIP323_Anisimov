
using System.Diagnostics;

public enum Genre
{
    fantasy = 0,
    comedy = 1,
    novel = 2
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