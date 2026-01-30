using System;

class Person
{
    public string name;
    public int age;

    public void PrzedstawSie()
    {
        Console.WriteLine("Mam na imię " + name + " i mam " + age + " lat.");
    }
}

class Program
{
    static void Main()
    {
        Person person1 = new Person();
        person1.name = "Piotr";
        person1.age = 36;

        Person person2 = new Person();
        person2.name = "Sylwia";
        person2.age = 38;

        person1.PrzedstawSie();
        person2.PrzedstawSie();
    }
}