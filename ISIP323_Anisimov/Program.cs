Console.Write("Введите число операций: ");
string k = Console.ReadLine();
int kolvo = Convert.ToInt32(k);

if (kolvo < 2 || kolvo > 40) Console.WriteLine("Некорректное кол-во операций!");
else
{
    double sum = 0;
    double[] price = new double[kolvo];
    string[] inf = new string[kolvo];
    Console.WriteLine("Введите информацию о операции по шаблону 'Название услуги или товара; Количество денег(в рублях)'");
    for (int i = 0; i < kolvo; i++)
    {
        Console.Write($"Операция № {i + 1}: ");
        string operation = Console.ReadLine();
        string[] operations = operation.Split(';');
        inf[i] = operations[0];
        price[i] = Convert.ToDouble(operations[1]);
        sum += price[i];
    }



    void menu()
    {
        Console.WriteLine("=======================================");
        Console.WriteLine("Меню: ");
        Console.WriteLine("Нажмите нужный номер, для выбора:");
        Console.WriteLine("1.Вывод данных");
        Console.WriteLine("2.Статистика (среднее, максимальное, минимальное, сумма)");
        Console.WriteLine("3.Сортировка по цене (пузырьковая сортировка)");
        Console.WriteLine("4.Конвертация валюты (пользователь вводит курс или выбирает из списка)");
        Console.WriteLine("5.Поиск по названию");
        Console.WriteLine("0.Выход");
        Console.WriteLine("=======================================");
        string ch = Console.ReadLine();
        int choice = Convert.ToInt32(ch);

        switch (choice)
        {
            case 1:
                for (int i = 0; i < price.Length; i++)
                {
                    Console.Write($"|{inf[i]} -- {price[i]}Руб.|\n");
                }
                menu();
                break;
            case 2:
                Console.WriteLine("Сумма всех операций: " + sum);
                Console.WriteLine($"Максимальная стоимость: {price.Max()}");
                Console.WriteLine($"Минимальная стоимость: {price.Min()}");
                Console.WriteLine($"Средняя стоимость: {price.Average()}");
                menu();
                break;
            case 3:
                for (int i = 0; i < kolvo - 1; i++)
                {
                    for (int j = 0; j < kolvo - i - 1; j++)
                    {
                        if (price[j] > price[j + 1])
                        {
                            // меняем местами суммы
                            double swapPrice = price[j];
                            price[j] = price[j + 1];
                            price[j + 1] = swapPrice;

                            // меняем местами названия
                            string swapInf = inf[j];
                            inf[j] = inf[j + 1];
                            inf[j + 1] = swapInf;
                        }
                    }
                }
                Console.WriteLine("\nОтсортированный список:");
                for (int i = 0; i < kolvo; i++)
                    Console.WriteLine($"{inf[i]} — {price[i]} руб.");
                menu();
                break;
            case 4:
                menu();
                break;
            case 5:
                Console.WriteLine("Введите название: ");
                string a = Console.ReadLine();
                a.ToLower();
                int num = 0;
                for (int i = 0; i < inf.Length; i++)
                {
                    if (inf[i].Contains(a))
                    {
                        Console.WriteLine(inf[i]);
                        num++;
                    }
                }
                if (num == 0)
                {
                    Console.WriteLine("Такого нету.");
                }
                menu();
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Нету такого номера");
                menu();
                break;
        }
    }
    menu();
}
