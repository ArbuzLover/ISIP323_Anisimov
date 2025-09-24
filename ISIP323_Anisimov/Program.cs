using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
List<textClass> textClasses = new List<textClass>();

while (true)
{
    Console.WriteLine("\n=== МЕНЮ ===");
    Console.WriteLine("1 - Количество слов в введёном тексте");
    Console.WriteLine("2 - Самое короткое слово");
    Console.WriteLine("3 - Количество предложений в тексте");
    Console.WriteLine("4 - Количество гласных и согласных букв в тексте");
    Console.WriteLine("5 - Самое длинное слово");
    Console.WriteLine("6 - Статистика каждой буквы");
    Console.WriteLine("7 - Ввести новый текст)");
    //Console.WriteLine("8 - Отчёт о продажах");
    Console.WriteLine("0 - Выход");
    Console.Write("Выберите команду: ");
    string choice = Console.ReadLine().Trim();
    Console.WriteLine();
    switch (choice)
    {
        case "1": Console.WriteLine($"Количество слов в тексте: {TextList.Length}"); ; break;
        case "2": Console.WriteLine($"Самое короткое слово: '{ShortWord(TextList)}' "); break;
        case "3": Console.WriteLine($"Количество предложений в тексте: {KolvoPredl(Text)}"); ; break;
        case "4": Console.WriteLine($"Количество гласных: {KolvoGlasn(Text)}, количество согласных: {KolvoSoglas(Text)} "); ; break;
        case "5": Console.WriteLine($"Самое длинное слово: '{LongWord(TextList)}' "); ; break;
        case "6":
            foreach (var pair in Stat(Text).OrderByDescending(x => x.Value))
            {
                if (pair.Value > 0)
                {
                    Console.WriteLine($"Буква '{pair.Key}' встречается {pair.Value} раз");
                }
            }
            ; break;
        case "7": textClasses.Add(new textClass(Text, TextList.Length, ShortWord(TextList), KolvoPredl(Text), KolvoGlasn(Text), KolvoSoglas(Text), LongWord(TextList), Stat(Text))); break;
        case "0": return;
        default: Console.WriteLine("Неверная команда. Попробуйте снова."); break;
    }
}
string ShortWord(string[] TextList)
{
    string min = "   ";
    foreach (var word in TextList)
    {
        if (word.Length < min.Length){ min = word; break; }
        else { continue; }
    }
    return min;
}

string LongWord(string[] TextList)
{
    string max = " ";
    foreach (var word in TextList)
    {
        if (word.Length > max.Length) { max = word;}
    }
    return max;
}

int KolvoPredl(string Text)
{
    char[] ABC = { 'А', 'О', 'У', 'Э', 'И', 'Ы', 'Е', 'Ё', 'Ю', 'Я', 'Б', 'В', 'Г', 'Д', 'Ж', 'З', 'Й', 'К', 'Л', 'М', 'Н', 'П', 'Р', 'С', 'Т', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ъ' };
    char[] prep = {'.','!','?',};
    int count = 0;
    for (int i = 0; i < Text.Length; i++)
    {
        if (prep.Contains(Text[i]) && ABC.Contains(Text[i - 1])) { continue; }
        else if(prep.Contains(Text[i])) { count++; } 
    }

    return count;
}

int KolvoGlasn(string Text)
{
    char[] GlasList = { 'А', 'О', 'У', 'Э', 'И', 'Ы', 'Е', 'Ё', 'Ю', 'Я', 'а', 'о', 'у', 'з', 'и', 'ы', 'е', 'ё', 'ю', 'я' };
    int countS = 0, countG = 0;
    foreach (char i in Text)
    {
        if (GlasList.Contains(i)) { countG++; }
    }
    return countG;
}

int KolvoSoglas(string Text)
{
    char[] SoglasList = { 'Б', 'В', 'Г', 'Д', 'Ж', 'З', 'Й', 'К', 'Л', 'М', 'Н', 'П', 'Р', 'С', 'Т', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ъ',
    'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ъ' };
    int countS = 0, countG = 0;
    foreach (char i in Text)
    {

        if (SoglasList.Contains(i)) { countS++; }
    }
    return countS;
}


Dictionary<char, int> Stat(string Text)
{
    Dictionary<char, int> stat = new Dictionary<char, int>() {
        {'А', 0 },
        {'Б',0},
        {'В',0},
        {'Г',0},
        {'Д',0},
        {'Е',0},
        {'Ё',0},
        {'Ж',0},
        {'З',0},
        {'И',0},
        {'Й',0},
        {'К',0},
        {'Л',0},
        {'М',0},
        {'Н',0},
        {'О',0},
        {'П',0},
        {'Р',0},
        {'С',0},
        {'Т',0},
        {'У',0},
        {'Ф',0},
        {'Х',0},
        {'Ц',0},
        {'Ч',0},
        {'Ш',0},
        {'Щ',0},
        {'Ъ',0},
        {'Ы',0},
        {'Ь',0},
        {'Э',0},
        {'Ю',0},
        {'Я',0},


    };
    foreach (char c in Text.ToUpper()) {
    if (stat.ContainsKey(c))
        {
            stat[c]++;
        }
    }
    foreach (var pair in stat.OrderByDescending(x => x.Value)) {
        if (pair.Value > 0)
        {
            Console.WriteLine($"Буква '{pair.Key}' встречается {pair.Value} раз");
        }
    }
    return stat;
}

public class textClass
{
    static public int ids = 0;
    public int id;
    public string text;
    public int countWords;
    public string shortWord;
    public int countPredl;
    public int countGlas;
    public int countSogl; 
    public string longWord;
    public Dictionary<char, int> Statics;

    public textClass(string Text, int countWords, string shortWord, int countPredl, int countGlas, int countSogl, string longWord, Dictionary<char, int> Statics)
    {
        ids += 1;
        id += ids;
        this.text = text;
        this.countWords = countWords;
        this.shortWord = shortWord;
        this.countPredl = countPredl;
        this.countGlas = countGlas;
        this.countSogl = countSogl;
        this.longWord = longWord;
        this.Statics = Statics;
    }
}