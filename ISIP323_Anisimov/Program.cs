
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
    Console.WriteLine("\n=== Библиотека: меню ===");
    Console.WriteLine("1 - Показать все книги");
    Console.WriteLine("2 - Добавить книгу");
    Console.WriteLine("3 - Удалить книгу");
    Console.WriteLine("4 - Найти книгу");
    Console.WriteLine("5 - Отсортировать по названию");
    Console.WriteLine("6 - Отсортировать по годам");
    Console.WriteLine("7 - Вывести самую дорогую и дешёвую книгу");
    Console.WriteLine("8 - Вывести книги каждого автора");
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
    if (!library.Any()) { Console.WriteLine("Список книг пуст."); return; }
    foreach (var p in library) p.Vivod();
}

static void AddBook(List<Book> library)
{
    Console.Write("Введите название новой книги: ");
    string name = Console.ReadLine();
    Console.Write("Введите название автора новой книги: ");
    string author = Console.ReadLine();
    Console.Write("Введите жанр");
    Console.WriteLine("Доступные жанры:");
    foreach (var val in Enum.GetValues(typeof(Genre)))
    Console.WriteLine($"{(int)val} - {val}");
    int genre = Convert.ToInt32(Console.ReadLine()); 
    Console.Write("Введите цену книги: ");
    decimal price = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Введите дату создания книги: ");
    int year = Convert.ToInt32(Console.ReadLine());
    
    Book book = new Book(name,author,(Genre)genre,year,price);
    library.Add(book);
    Console.WriteLine("Книга добавлена:");
    book.Vivod();
}

static void DelBook(List<Book> library)
{
    Console.WriteLine("Введите id книги для удаления");
    int input = Convert.ToInt32(Console.ReadLine());

    foreach (Book t in library.ToList())
    {
        if (t.id == input)
        {
            library.Remove(t);
            Console.WriteLine("Книга была удалена!");
        }

    }
}

static void FindBook(List<Book> library)
{
    Console.WriteLine("Введите поиск по какому признаку вы хотите осуществить\n" +
  "Название-1\n" +
  "Автор-2\n" +
  "Жанр-3\n");
    int temp3 = Convert.ToInt32(Console.ReadLine());
    switch (temp3)
    {
        case 1:
            bool flag1 = true;
            Console.WriteLine("Введите возможное название книги: ");
            string name = Console.ReadLine();
            foreach (Book t in library)
            {
                if (t.Name.Contains(name)) { t.Vivod(); flag1 = false; }
            }
            if (flag1) { Console.WriteLine("Не нашлось такой книги :("); }
            break;
        case 2:
            bool flag2 = true;
            Console.WriteLine("Введите возможного автора: ");
            string author = Console.ReadLine();
            foreach (Book t in library)
            {
                if (t.Author.Contains(author)) { t.Vivod(); flag2 = false; }
            }
            if (flag2) { Console.WriteLine("Не нашлось такого автора :("); }
            break;
        case 3:
            bool flag3 = true;
            Console.WriteLine("выберете жанр fantasy=0,\r\n comedy=1,\r\n drama=2");
            int temp = Convert.ToInt32(Console.ReadLine());
            foreach (Book t in library)
            {
                if (t.Genre == (Genre)temp)
                {
                    t.Vivod();
                    flag3 = false;
                }
            }
            if (flag3) { Console.WriteLine("Жанр не найден!"); }

            break;
    }
}

static void SortByName(List<Book> library)
{
    var sortedBook = from p in library
                        orderby p.Name
                        select p;
    foreach (var p in sortedBook)
    { p.Vivod(); }
}

static void SortByYear(List<Book> library)
{
    var sortedBook = from p in library
                     orderby p.Year
                     select p;
    foreach (var p in sortedBook)
    { p.Vivod(); }
}

static void SortByPrice(List<Book> library) 
{
    if (library.Count == 0)
    {
        Console.WriteLine("Список книг пуст");
        return;
    }

    var mostExpensive = library.MaxBy(book => book.Price);
    var cheapest = library.MinBy(book => book.Price);

    Console.WriteLine("Самая дорогая книга:");
    Console.WriteLine($"\"{mostExpensive.Name}\" - {mostExpensive.Author} | Цена: {mostExpensive.Price} руб.");

    Console.WriteLine("\nСамая дешевая книга:");
    Console.WriteLine($"\"{cheapest.Name}\" - {cheapest.Author} | Цена: {cheapest.Price} руб.");
}

static void CountBooks(List<Book> library)
{
    var groupedBooks = library.GroupBy(book => book.Author)
                                 .Select(group => new
                                 {
                                     author = group.Key,
                                     BookCount = group.Count(),
                                     Books = group.ToList()
                                 })
                                 .OrderByDescending(x => x.BookCount);

    foreach (var authorGroup in groupedBooks)
    {
        Console.WriteLine($"Автор: {authorGroup.author}");
        Console.WriteLine($"Количество книг: {authorGroup.BookCount}");
        Console.WriteLine("Книги:");

        foreach (var book in authorGroup.Books)
        {
            Console.WriteLine($"  - \"{book.Name}\" ({book.Year}) - {book.Price} руб.");
        }
        Console.WriteLine();
    }
}

public enum Genre
{
    fantasy = 0,
    comedy = 1,
    drama = 2
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
        ids++;
        id = ids;
        Name = name;
        Author = author;
        Genre = genre;  
        Year = year;
        Price = price;
    }

    public void Vivod() { Console.WriteLine($"ID: {id} | Название: {Name} | Автор: {Author} | Жанр: {Genre} | Год создания: {Year} | Цена: {Price:F2} "); }
}