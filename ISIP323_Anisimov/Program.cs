


public enum Sex
{
    men = 0,
    women = 1
}

class Person
{
    private string FIO;
    private Sex Sex;
    private static int ids = 0;
    private int ID;

    public Person(string fio, Sex sex)
    {
        ids++;
        ID = ids;
        FIO = fio;
       Sex =sex;
    }
    public virtual void Print()
    {
        Console.WriteLine($"Номер: {ID}\n ФИО: {FIO}\n Пол: {Sex} ");
    }
}

class Student : Person
{

    private int CourseNumber { get; set; }

    public Student(string fio,  Sex sex,  int CourseNumber)
        : base(fio, sex)
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
    private int Exp { get; set; }
    public Teacher(string fio, Sex sex, int exp) : base(fio, sex) {
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
    private string NameCourse { get; set; }
    private string Time { get; set; }
    private Teacher Teacher { get; set; }

    public Course(string name_cour, string time, Teacher teacher)
    {

        this.NameCourse = name_cour;
        this.Time = time;
        this.Teacher = teacher;
    }
}
