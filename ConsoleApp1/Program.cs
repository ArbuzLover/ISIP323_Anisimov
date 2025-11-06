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
