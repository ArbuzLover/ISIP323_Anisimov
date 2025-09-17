using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Category
{
    food = 0,
    toys = 1,
    electro = 2
}

public class Product
{
    public int id { get; }
    public string Name { get; set; }
    public decimal price { get; set; }
    public int quantity { get; set; }
    public bool InStock => quantity > 0;
    public Category Category { get; set; }

    public Product(string n, decimal p, int q, Category category)
    {
        if (string.IsNullOrWhiteSpace(n)) throw new ArgumentException("Название товара не должно быть пустым");
        if (p <= 0) throw new ArgumentException("Цена должна быть положительной");
        if (q < 0) throw new ArgumentException("Количество не может быть отрицательным");
        id = id++;
        Name = n.Trim();
        price = p;
        quantity = q;
        Category = category;
    }
    public void Vivod() { Console.WriteLine($"ID: {id} | Название: {Name} | Цена: {price:F2} | Количество {quantity} В наличии: {(InStock ? "Да" : "Нет")} | Категория: {Category}   "); }
}

