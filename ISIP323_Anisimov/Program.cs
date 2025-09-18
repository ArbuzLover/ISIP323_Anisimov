using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
List<Product> products = new List<Product>();
products.Add(new Product("Лабуба", 100, 25, Category.toys));
products.Add(new Product("Чебумени", 9999, 1, Category.food));
products.Add(new Product("Меч", 200, 0, Category.toys));
products.Add(new Product("Iphone", 1000, 2, Category.electro));
products.Add(new Product("Пицца", 5, 100, Category.food));





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
        case "1": VivodAll(products); break;
        case "2": AddProduct(products); break;
        case "3": RemoveProduct(products); break;
        case "4": OrderSupply(products); break;
        case "5": SellProduct(products); break;
        case "6": SearchProducts(products); break;
        case "7": //ShowSalesHistoryAndUndo(); break;
        case "8": //PrintSalesReport(); break;
        case "0": return;
        default: Console.WriteLine("Неверная команда. Попробуйте снова."); break;
    }
}

static void VivodAll(List<Product> products)
{
    if (!products.Any()) { Console.WriteLine("Список товаров пуст."); return; }
    foreach (var p in products) p.Vivod();
}
static string ProverName(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string s = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
        Console.WriteLine("Значение не может быть пустым!");
    }
}

static decimal ProverPrice1(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string s = Console.ReadLine();
        if (decimal.TryParse(s, out var v) && v > 0) return v;
        Console.WriteLine("Введите корректную положительную цену (число).");
    }
}

static int ProverPrice2(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var s = Console.ReadLine();
        if (int.TryParse(s, out var v) && v >= 0) return v;
        Console.WriteLine("Введите целое число >= 0.");
    }
}

static int ProverQuant(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var s = Console.ReadLine();
        if (int.TryParse(s, out var v) && v > 0) return v;
        Console.WriteLine("Введите целое число > 0.");
    }
}





static void AddProduct(List<Product> products)
{
    Console.Write("Введите название товара: ");
    string name = Console.ReadLine();
    Console.Write("Введите цену товара: ");
    decimal price = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Введите количество товара: ");
    int qty = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите категорию");
    Console.WriteLine("Доступные категории:");
    foreach (var val in Enum.GetValues(typeof(Category)))
        Console.WriteLine($"{(int)val} - {val}");
    int category = Convert.ToInt32(Console.ReadLine());
    Product prod = new Product(name, price, qty, (Category)category);
    products.Add(prod);
    Console.WriteLine("Товар добавлен:");
    prod.Vivod();
}

static void RemoveProduct(List<Product> products)
{
    Console.WriteLine("Введите id товара для удаления");
    int input = Convert.ToInt32(Console.ReadLine());

    foreach (Product t in products.ToList())
    {
        if (t.id == input)
        {
        products.Remove(t);
        }
        
    }
}


static void OrderSupply(List<Product> products)
{
    bool flag = true;
        Console.WriteLine("Напишите id уже добавленного товар,на который вы хотите оформить поставку");
        int temp = Convert.ToInt32(Console.ReadLine());
        foreach (Product t in products)
        {
            if (temp == t.id)
            {
                Console.WriteLine("напиишите колличество товара который хотите заказать");
                int temp1 = Convert.ToInt32(Console.ReadLine());
                t.quantity += temp1;
                flag = false;
            }
        }
    if (flag)
    {
        Console.WriteLine("вашего товара не нашлось в списке(");
    }
}

static void SellProduct(List<Product> products)
{
        Console.WriteLine("Напишите уже добавленный товар,который вы хотите продать");
        string temp = Console.ReadLine();
        foreach (Product t in products)
        {
            if (temp == t.Name)
            {
                Console.WriteLine("напиишите колличество товара который хотите продать");
                int temp1 = Convert.ToInt32(Console.ReadLine());
                if (t.quantity >= temp1)
                {
                    t.quantity -= temp1;
                }
                else
                {
                    Console.WriteLine("вашего товара недостаточно в наличии");
                }
            }
            else
            {
                Console.WriteLine("вашего товара не нашлось в списке(");
            }
        }
}

static void SearchProducts(List<Product> products)
{
    Console.WriteLine("Введите поиск по какому признаку вы хотите осуществить\n" +
  "id-1\n" +
  "name-2\n" +
  "category-3\n");
    int temp3 = Convert.ToInt32(Console.ReadLine());
    switch (temp3)
    {
        case 1:
            poiskID();
            break;
        case 2:
            poiskName();
            break;
        case 3:
            poiskKategory();
            break;
    }

    void poiskID()
    {
        bool flag = true;
        Console.WriteLine("Введите id товара");
        int temp = Convert.ToInt32(Console.ReadLine());
        foreach (Product t in products)
        {
            if (t.id == temp)
            {
                Console.WriteLine($"{t.Name}, {t.id}, {t.price}, {t.quantity},{t.InStock},{t.Category}");
                flag = false;
            }

            if (flag) { Console.WriteLine("товар не найден"); }
        }
    }
    void poiskName()
    {
        bool flag = true;
        Console.WriteLine("Введите навзание товара");
        string temp = Console.ReadLine();
        foreach (Product t in products)
        {
            if (t.Name == temp)
            {
                Console.WriteLine($"{t.Name}, {t.id}, {t.price}, {t.quantity},{t.InStock},{t.Category}");
            }

        }
        if (flag) { Console.WriteLine("товар не найден"); }

    }

        void poiskKategory()
{
    bool flag = true;
    Console.WriteLine("выберете категорию water=1,\r\n snack=2,\r\n chebumany=3");
    int temp = Convert.ToInt32(Console.ReadLine());
    foreach (Product t in products)
    {
        if (t.Category == (Category)temp)
        {
            Console.WriteLine($"{t.Name}, {t.id}, {t.price}, {t.quantity},{t.InStock},{t.Category}");
        }
    }
    if (flag) { Console.WriteLine("товар не найден"); }

}
}


//static void ShowSalesHistoryAndUndo()
//{
//    if (!salesHistory.Any()) { Console.WriteLine("История продаж пуста."); return; }
//    Console.WriteLine("История продаж (последняя сверху):");
//    foreach (var s in salesHistory) Console.WriteLine($"Код {s.Code} | {s.Name} | Количество: {s.Quantity} | Сумма: {s.Sum:F2}");
//    Console.Write("Отменить последнюю продажу? (y/n): ");
//    if ((Console.ReadLine() ?? "").ToLower() == "y")
//    {
//        var last = salesHistory.Pop();
//        var prod = products.FirstOrDefault(x => x.Code == last.Code);
//        if (prod != null) prod.Quantity += last.Quantity;
//        Console.WriteLine($"Последняя продажа отменена. Возвращено {last.Quantity} шт товара \"{last.Name}\".");
//    }
//}

//static void PrintSalesReport()
//{
//    if (!salesHistory.Any()) { Console.WriteLine("Продаж нет."); return; }
//    var grouped = salesHistory
//    .GroupBy(s => s.Code)
//    .Select(g => new { Code = g.Key, Name = g.First().Name, TotalQty = g.Sum(x => x.Quantity), TotalSum = g.Sum(x => x.Sum) })
//    .ToList();

//    Console.WriteLine("=== Отчёт о продажах ===");
//    decimal grandTotal = 0;
//    foreach (var item in grouped)
//    {
//        Console.WriteLine($"Код {item.Code} | {item.Name} | Продано: {item.TotalQty} шт | Сумма: {item.TotalSum:F2} руб");
//        grandTotal += item.TotalSum;
//    }
//    Console.WriteLine($"Итого по всем продажам: {grandTotal:F2} руб");
//}






public enum Category
{
    food = 0,
    toys = 1,
    electro = 2
}

public class Product
{
    static public int ids = 0;
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
        ids += 1;
        id += ids;
        Name = n.Trim();
        price = p;
        quantity = q;
        Category = category;
    }
    public void Vivod() { Console.WriteLine($"ID: {id} | Название: {Name} | Цена: {price:F2} | Количество {quantity} В наличии: {(InStock ? "Да" : "Нет")} | Категория: {Category} "); }
}


