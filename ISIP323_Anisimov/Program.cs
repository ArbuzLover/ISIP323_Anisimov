
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
    public decimal price { get; set; }

    public Book(string Name, string Author, Genre Genre, int Year, decimal Price)
    {
        
    } 
}