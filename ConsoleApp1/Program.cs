using System;
using System.Collections.Generic;
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
                            PVZID = id_pvz
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

        public static void auth()
        {
            Console.WriteLine("Войдите в аккаунт,введите ваш логин");
            Login = Console.ReadLine();
            Console.WriteLine("Войдите в аккаунт,введите ваш пароль");
            string password = Console.ReadLine();
            int id_user = users.First(x => x.Name == Login).ID;
            foreach (Users user in users)
            {
                if (user.Name == Login)
                {
                    if (user.Password == password)
                    {
                        Console.WriteLine("Вы успешно вошли в свою учетную запись");
                        while (true)
                        {
                            Console.WriteLine("Выберете:" +
                                "1: Cписок товаров и добавление в корзину" +
                                "2: Корзина и оформление заказа" +
                                "3: Просмотр истории заказов с датой");
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
                                    history_of_orders();
                                    break;
                            }
                        }


                    }
                }
            }

        }


        static void Main(string[] args)
        {
            Console.WriteLine("Выберете действие");
            while (true)
            {
                Console.WriteLine("Выбирете:" +
                    "1: Просмотр товара" +
                    "2: Регистрация" +
                    "3: Вход в аккаунт");
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
