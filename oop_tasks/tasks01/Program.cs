while (true)
{
    Console.Write("Podaj hasło: ");
    string password = Console.ReadLine();

    if (password == "admin123")
    {
        Console.WriteLine("Zalogowano pomyślnie!");
        break;
    }

    Console.WriteLine("Błędne hasło, spróbuj ponownie.");
}