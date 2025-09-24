using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Console.Write("Введите текст на русском(минимум 100 символов): ");
string Text = Console.ReadLine();
while(Text.Length < 100)
{
    Console.WriteLine("Слишком короткий текст!");
    Console.Write("Введите текст на русском(минимум 100 символов): ");
    Text = Console.ReadLine();

}
string[] TextList = Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
while (true)
{
    Console.WriteLine("\n=== МЕНЮ ===");
    Console.WriteLine("1 - Количество слов в введёном тексте");
    Console.WriteLine("2 - Самое короткое слово");
    Console.WriteLine("3 - Количество предложений в тексте");
    Console.WriteLine("4 - Количество гласных и согласных букв в тексте");
    Console.WriteLine("5 - Самое длинное слово");
    //Console.WriteLine("6 - Поиск товаров (по коду, названию, категории)");
    //Console.WriteLine("7 - История продаж (и отмена последней продажи)");
    //Console.WriteLine("8 - Отчёт о продажах");
    Console.WriteLine("0 - Выход");
    Console.Write("Выберите команду: ");
    string choice = Console.ReadLine().Trim();
    Console.WriteLine();
    switch (choice)
    {
        case "1": KolvoWords(); break;
        case "2": ShortWord(); break;
        case "3": KolvoPredl(); break;
        case "4": ; break;
        case "5": LongWord(); break;
        case "6": ; break;
        case "0": return;
        default: Console.WriteLine("Неверная команда. Попробуйте снова."); break;
    }
}
void KolvoWords()
{
    Console.WriteLine($"Количество слов в тексте: {TextList.Length}");
}

void ShortWord()
{
    string min = "   ";
    foreach (var word in TextList)
    {
        if (word.Length < min.Length){ min = word; break; }
        else { continue; }
    }
    Console.WriteLine($"Самое короткое слово: '{min}' ");
}

void LongWord()
{
    string max = " ";
    foreach (var word in TextList)
    {
        if (word.Length > max.Length) { max = word;}
    }
    Console.WriteLine($"Самое длинное слово: '{max}' ");
}

void KolvoPredl()
{
    int count = 0;
    foreach (int i in Text)
    {
        if (Text[i] == '.') count++;
    }
    Console.WriteLine($"Количество предложений в тексте: {count}");
}


