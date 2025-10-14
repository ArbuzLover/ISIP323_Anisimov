

public enum Sex
{
    men = 0,
    women = 1
}

class Person
{
    private string FIO;
    private Sex Sex;

    public Person(string fio, Sex sex)
    {
        FIO = fio;
       Sex =sex;
    }
    public virtual void Print()
    {
        Console.WriteLine($"ФИО: {FIO}\n Пол: {Sex} ");
    }
}

class Student : Person
{
    private static int ids = 0;
    private int StudentID;
    private int CourseNumber;

    public Student(string fio,  Sex sex,  int CourseNumber)
        : base(fio, sex)
    {
        ids++;
        StudentID = ids;
        this.CourseNumber = CourseNumber;
    }

    public override void Print()
    {
        Console.WriteLine("Student");
        base.Print();
        Console.WriteLine($"Номер студента: {StudentID}\n Курс обучения: {CourseNumber}\n");
    }
}
