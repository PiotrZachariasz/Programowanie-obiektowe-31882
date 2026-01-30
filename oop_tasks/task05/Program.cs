class bankAccount
{
    private double saldo;

    public void inCome(double sum)
    {
        saldo = saldo + sum;
    }
    
    public double printSaldo()
    {
        return saldo;
    }

    public void outCome(double sum)
    {
        if (sum <= saldo)
        {
            saldo = saldo - sum;
            Console.WriteLine("Wypłacono: " + sum);
        }
        else
        {
            Console.WriteLine("Brak środków!");
        }
    }
}

class Program
{
    static void Main()
    {
        bankAccount account = new bankAccount();
        
        account.inCome(100);
        Console.WriteLine("Saldo: " + account.printSaldo());

        account.outCome(50);
        Console.WriteLine("Saldo: " + account.printSaldo());

        account.outCome(500);
        Console.WriteLine("Saldo: " + account.printSaldo());
    }
}