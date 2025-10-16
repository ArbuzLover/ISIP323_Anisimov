using System;
using System.Reflection;


List<Student> spisok_st = new List<Student>();
List<Person> people = new List<Person>();
List<Teacher> prepods = new List<Teacher>();
List<Student> students = new List<Student>();
Dictionary<Course, List<Student>> cour_stud = new Dictionary<Course, List<Student>>();

void add_Teacher(List<Teacher> prepods, List<Person> people)
{
    Console.WriteLine("Введите имя препода: ");
    string name = Console.ReadLine();
    Console.WriteLine("Введите его возраст: ");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите его опыт работы: ");
    int exp = Convert.ToInt32(Console.ReadLine());
    Teacher newPrepod = new Teacher(name, age, exp);
    prepods.Add(newPrepod);
    people.Add(newPrepod);
}

void add_Student(List<Student> students, List<Person> people)
{
    Console.WriteLine("Введите имя студента: ");
    string name = Console.ReadLine();

    Console.WriteLine("Введите курс: ");
    int course = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите возраст: ");
    int age = Convert.ToInt32(Console.ReadLine());
    Student newStudent = new Student(name, age, course);
    students.Add(newStudent);
    people.Add(newStudent);
}

 void sign_up(List<Student> students, Dictionary<Course, List<Student>> cour_stud)
{
    Student temp = null;
    Console.WriteLine("Напишите id");
    int id = Convert.ToInt32(Console.ReadLine());
    foreach (Student s in students)
    {
        if (s.ID == id)
        {
            temp = s;
            break;
        }
    }

    if (temp == null)
    {
        Console.WriteLine("Студент не найден!");
        return;
    }

    Console.Write("Напишите название курса");
    string temp1 = Console.ReadLine();
    foreach (var key in cour_stud.Keys)
    {
        if (key.NameCourse == temp1)
        {
            cour_stud[key].Add(temp);
            Console.WriteLine("Студент записан на курс!");
            return;
        }
    }
    Console.WriteLine("Курс не найден!");
}

 void add_course(List<Teacher> prepods)
{
    Console.WriteLine("Введите название курса ");
    string name = Console.ReadLine();
    Console.WriteLine("Введите время  ");
    string time = Console.ReadLine();
    Console.WriteLine("Введите id препода  ");
    int ID = Convert.ToInt32(Console.ReadLine());

    Teacher foundPrepod = null;
    foreach (Teacher p in prepods)
    {
        if (p.ID == ID)
        {
            foundPrepod = p;
            break;
        }
    }

    if (foundPrepod == null)
    {
        Console.WriteLine("Преподаватель не найден!");
        return;
    }

   Course newCourse = new Course(name, time, foundPrepod);
    cour_stud.Add(newCourse, new List<Student>());
    Console.WriteLine("Курс добавлен!");
}



while (true)
{
    Console.WriteLine("--------------------МЕНЮ------------------\n" +
        "1 - РАБОТА СО СТУДЕНТАМИ\n"+
        "2 - РАБОТА С ПРЕПОДОВАТЕЛЯМИ\n"+
        "3 - РАБОТА С КУРСАМИ\n"+
        "0 - ВЫХОД\n"
        +"------------------------------------------------\n");
    string choice = Console.ReadLine().Trim();
    switch (choice)
    {
        default: Console.WriteLine("Такой команды нету, попробуйте ещё раз!");
            break;
        case "1":
            Console.WriteLine("---------------МЕНЮ СТУДЕНТОВ------------------\n"+
                "1 - Добавить студента\n"+
                "2 - Записать студента на курс\n"+
                "3 - Вывести студента и его курсы\n"+
                "0 - Выйти в основное меню\n"+
                "--------------------------------\n");
            choice = Console.ReadLine().Trim();
            switch (choice)
            {
                default:Console.WriteLine("Такой команды нету, попробуйте ещё раз!"); break;
                case "1": add_Student(students,people); break;
                case "2": sign_up(students, cour_stud); break;
                case "3": int temp = Convert.ToInt32(Console.ReadLine());
                    foreach (var student in students)
                    {
                        student.Print();
                    }
                    break;
                case "0": return 1;
            }
        break;
        case "2":
            Console.WriteLine("---------------МЕНЮ ПРЕПОДОВАТЕЛЕЙ------------------\n"+
               "1 - Добавить преподователя\n" +
               "2 - Вывести преподователя\n" +
               "0 - Выйти в основное меню\n" +
               "--------------------------------\n");
            choice = Console.ReadLine().Trim();
            switch (choice)
            {
                default: Console.WriteLine("Такой команды нету, попробуйте ещё раз!"); break;
                case "1": add_Teacher(prepods, people); break;
                case "2":
                    foreach (var prepod in prepods)
                    {
                        prepod.Print();
                    }

                    break;
                case "0": break;
            }
            break;
        case "3":
            Console.WriteLine("---------------МЕНЮ КУРСОВ------------------\n"+
                "1 - Добавить курс\n" +
                "2 - Вывести всех студентов и всех курсов\n" +
                "0 - Выйти в основное меню\n" +
                "--------------------------------\n");
                choice = Console.ReadLine().Trim();
                switch (choice)
                {
                    default: Console.WriteLine("Такой команды нету, попробуйте ещё раз!"); break;
                    case "1": add_course(prepods); break;
                    case "2": foreach (KeyValuePair<Course, List<Student>> cs in cour_stud)
                    {
                        Console.WriteLine(cs.Key.NameCourse);
                        foreach (Student s in cs.Value)
                        {
                            Console.WriteLine(s.ID + " " + s.FIO);
                        }
                    }
                    break;
                    case "0": return 1;
                }
                break;
        case "0": return 0;
    }
}



class Person
{
    public string FIO { get; private set; }
    private int Age;
    private static int ids = 0;
    public int ID { get; private set; }

    public Person(string fio, int age)
    {
        ids++;
        ID = ids;
        FIO = fio;
        Age = age;
    }
    public virtual void Print()
    {
        Console.WriteLine($"Номер: {ID}\n ФИО: {FIO}\n Возраст: {Age} ");
    }
}

class Student : Person
{

    private int CourseNumber { get; set; }

    public Student(string fio,  int age,  int CourseNumber)
        : base(fio, age)
    {
        this.CourseNumber = CourseNumber;
    }

    public override void Print()
    {
        Console.WriteLine("Student");
        base.Print();
        Console.WriteLine($" Курс обучения: {CourseNumber}\n");
    }
}

class Teacher : Person
{
    public int Exp { get; private set; }
    public Teacher(string fio, int age, int exp) : base(fio, age) {
        this.Exp = exp;
    }
    public override void Print()
    {
        Console.WriteLine("Teacher");
        base.Print();
        Console.WriteLine($"Опыт работы: {Exp}\n");
    }
}

class Course
{
    public string NameCourse { get;private set; }
    private string Time { get; set; }
    private Teacher Teacher { get; set; }

    public Course(string name_cour, string time, Teacher teacher)
    {

        this.NameCourse = name_cour;
        this.Time = time;
        this.Teacher = teacher;
    }
}
