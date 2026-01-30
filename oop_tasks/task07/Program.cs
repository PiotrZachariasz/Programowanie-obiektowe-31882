class Zwierze
{
    public virtual void DajGlos()
    {
        Console.WriteLine("Zwierzę wydaje dźwięk");
    }
}

class Pies : Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("Hau hau!");
    }
}

class Kot : Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("Miau!");
    }
}

class Program
{
    static void Main()
    {
        Zwierze[] zwierzeta = new Zwierze[3];
        zwierzeta[0] = new Pies();
        zwierzeta[1] = new Kot();
        zwierzeta[2] = new Zwierze();

        foreach (Zwierze z in zwierzeta)
        {
            z.DajGlos();
        }
    }
}