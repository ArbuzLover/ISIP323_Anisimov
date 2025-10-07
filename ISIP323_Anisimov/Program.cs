
using System.Collections.Generic;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
List<Book> library = new List<Book>();
library.Add(new Book("Майн Кампф","Адольф Г.",Genre.comedy, 1924,1000));
library.Add(new Book("Как жить с огромным члено?", "Башкалова Алиса Алексеевна", Genre.drama,2007, 100000));
library.Add(new Book("Дневник зомби", "Стив", Genre.drama, 2026, 500));
library.Add(new Book("Букварь", "АБВГДЕЙКО", Genre.comedy, 2000,500));
library.Add(new Book("Макан.История успеха","Башкалова Алиса Алексеевна", Genre.fantasy, 2025,1000000));

while (true)
{
    Console.WriteLine("\n=== Учет товаров: меню ===");
    Console.WriteLine("1 - Показать все товары");
    Console.WriteLine("2 - Добавить товар");
    Console.WriteLine("3 - Удалить товар");
    Console.WriteLine("4 - Заказать поставку (пополнить количество)");
    Console.WriteLine("5 - Продать товар");
    Console.WriteLine("6 - Поиск товаров (по коду, названию, категории)");
    Console.WriteLine("7 - История продаж (и отмена последней продажи)");
    Console.WriteLine("8 - Отчёт о продажах");
    Console.WriteLine("0 - Выход");
    Console.Write("Выберите команду: ");
    string choice = Console.ReadLine().Trim();
    Console.WriteLine();
    switch (choice)
    {
        case "1": VivodAll(library); break;
        case "2": AddBook(library); break;
        case "3": DelBook(library); break;
        case "4": FindBook(library); break;
        case "5": SortByName(library); break;
        case "6": SortByYear(library); break;
        case "7": SortByPrice(library); break;
        case "8": CountBooks(library); break;
        case "0": return;
        default: Console.WriteLine("Неверная команда. Попробуйте снова."); break;
    }
}
static void VivodAll(List<Book> library)
{
    if (!library.Any()) { Console.WriteLine("Список товаров пуст."); return; }
    foreach (var p in library) p.Vivod();
}

static void AddBook(List<Book> library)
{
    Console.Write("Введите название новой книги: ");
    string name = Console.ReadLine();
    Console.Write("Введите название автора новой книги: ");
    string author = Console.ReadLine();
    Console.Write("Введите категорию");
    Console.WriteLine("Доступные категории:");
    foreach (var val in Enum.GetValues(typeof(Genre)))
    Console.WriteLine($"{(int)val} - {val}");
    int genre = Convert.ToInt32(Console.ReadLine()); 
    Console.Write("Введите цену товара: ");
    decimal price = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Введите количество товара: ");
    int year = Convert.ToInt32(Console.ReadLine());
    
    Book book = new Book(name,author,(Genre)genre,year,price);
    library.Add(book);
    Console.WriteLine("Товар добавлен:");
    book.Vivod();
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