using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static string Login;
        public static List<Products> products = Core.Context.Products.ToList();
        public static List<Users> users = Core.Context.Users.ToList();
        public static List<Cart> Carts = Core.Context.Cart.ToList();
        public static List<PVZ> pvz = Core.Context.PVZ.ToList();
        public static List<Orders> orders = Core.Context.Orders.ToList();

        public static void reg()
        {
            Console.WriteLine("Для регистрации напишите ваше имя");
            string login = Console.ReadLine();
            Console.WriteLine("Напишите пароль");
            string password1 = Console.ReadLine();
            Console.WriteLine("Повторите ваш пароль");
            string password2 = Console.ReadLine();
            if (password1 == password2)
            {
                Users user = new Users
                {
                    Name = login,
                    Password = password1
                };
                Core.Context.Users.Add(user);
                Core.Context.SaveChanges();
            }
        }

        public static void PrintAllProducts()
        {
            Console.WriteLine("Сегодня в наличии такие товары:");
            foreach (var prod in products)
            {
                Console.WriteLine($"ID: {prod.ID}, {prod.Name},цена: {prod.Price},количество: {prod.Quantity}");

            }

        }

        public static void AddCart()
        {
            Console.WriteLine("Хотите ли вы что то купить?y/n");
            string temp = Console.ReadLine();
            int id = users.First(u => u.Name == Login).ID;
            if (temp == "y")
            {
                Console.WriteLine("Введите ID товара");
                int productid = Convert.ToInt32(Console.ReadLine());
                Cart cart = new Cart
                {
                    UserID = id,
                    ProductID = productid,
                };

                Core.Context.Cart.Add(cart);
                Core.Context.SaveChanges();

            }
        }
        public static void AddOrder()
        {
            int id = users.First(u => u.Name == Login).ID;
            List<Cart> order = Carts.Where(u => u.UserID == id).ToList();
            foreach (var cart in order)
            {
                foreach (var prod in products)
                {
                    if (prod.ID == cart.ProductID)
                    {
                        Console.WriteLine($"id:{prod.ID},{prod.Name},цена:{prod.Price}, количество: {prod.Quantity}");
                    }
                }
            }
            Console.WriteLine(" хотите ли вы заказать все эти товары?y/n");
            string temp_choice = Console.ReadLine();
            if (temp_choice == "y")
            {
                Console.WriteLine("Выберете пвз");
                foreach (PVZ punkt in pvz)
                {
                    Console.WriteLine($"{punkt.ID},{punkt.Addres}");
                }
                Console.WriteLine("Введите ID пвз");
                int id_pvz = Convert.ToInt32(Console.ReadLine());
                foreach (Cart cart in order)
                {
                    if (id == cart.UserID)
                    {
                        Orders NewOrder = new Orders()
                        {
                            UserID = id,
                            ProductID = cart.ProductID,
                            PVZID = id_pvz,
                            Date = DateTime.Now
                        };
                        Core.Context.Orders.Add(NewOrder);
                        Core.Context.Cart.Remove(cart);
                        Core.Context.SaveChanges();
                        Carts.Remove(cart);
                    }
                }
                Console.WriteLine("Заказ оформлен и скоро будет доставлен");
            }
        }

        public static void HistoryOrders()
        {
            int tempID = users.First(x => x.Name == Login).ID;
            List<Orders> order_user = Core.Context.Orders.Where(u => u.UserID == tempID).ToList();
            var groupedOrders = order_user
            .GroupBy(orders => new DateTime(orders.Date.Year, orders.Date.Month, orders.Date.Day, orders.Date.Hour, orders.Date.Minute, 0))
    .OrderBy(group => group.Key)
    .ToList();

            foreach (var orderGroup in groupedOrders)
            {
                Console.WriteLine($"Заказ от {orderGroup.Key:dd.MM.yyyy HH:mm}");
                Console.WriteLine("Товары в заказе:");

                foreach (var item in orderGroup)
                {
                    foreach (Products prod in products)
                    {
                        if (prod.ID == item.ProductID)
                        {
                            Console.WriteLine($"  - {prod.Name},{prod.Price}");
                        }
                    }
                }

            }
        }

        public static void auth()
        {
            Console.WriteLine("Войдите в аккаунт,введите ваш логин");
            Login = Console.ReadLine();
            Console.WriteLine("Войдите в аккаунт,введите ваш пароль");
            string password = Console.ReadLine();
            int id_user = Core.Context.Users.First(x => x.Name == Login).ID;
            foreach (Users user in users)
            {
                if (user.Name.Trim() == Login)
                {
                    if (user.Password.Trim() == password)
                    {
                        Console.WriteLine("Вы успешно вошли в свою учетную запись");
                        while (true)
                        {
                            Console.WriteLine("Выберете:" +
                                "1: Cписок товаров и добавление в корзину\n" +
                                "2: Корзина и оформление заказа\n" +
                                "3: Просмотр истории заказов с датой\n");
                            int temp = Convert.ToInt32(Console.ReadLine());
                            switch (temp)
                            {
                                case 1:
                                    PrintAllProducts();
                                    AddCart();
                                    break;
                                case 2:
                                    AddOrder();

                                    break;
                                case 3:
                                    HistoryOrders();
                                    break;
                            }
                        }  


                    }
                    else { Console.WriteLine("Неправильный пароль"); }
                }
                else { Console.WriteLine("Неправильный логин"); }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("=========МЕНЮ========");
            while (true)
            {
                Console.WriteLine("Выберете: \n" +
                    "1 - Просмотр товара\n" +
                    "2 - Регистрация\n" +
                    "3 - Вход в аккаунт\n");
                int temp_choice = Convert.ToInt32(Console.ReadLine());
                switch (temp_choice)
                {
                    case 1:
                        PrintAllProducts();
                        break;
                    case 2:
                        reg();
                        break;

                    case 3:
                        auth();
                        break;

                }
            }

        }

    }
}
