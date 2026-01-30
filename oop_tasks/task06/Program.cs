class Animal
{
    public void Eat()
    {
        Console.WriteLine("Zwierzę je");
    }
}

class Dog : Animal 
{
    public void Barking()
    {
        Console.WriteLine("Hau hau!");
    }
}

class Cat : Animal
{
    public void Meowing()
    {
        Console.WriteLine("Miau!");
    }
}

class Program
{
    static void Main()
    {
        Dog dog = new Dog();
        dog.Eat();
        dog.Barking();

        Cat cat = new Cat();
        cat.Eat();
        cat.Meowing();
    }
}