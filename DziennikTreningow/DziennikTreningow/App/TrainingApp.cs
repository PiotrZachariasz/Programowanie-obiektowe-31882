using DziennikTreningow.Data;

namespace DziennikTreningow.App;

public class TrainingApp
{
    private readonly JsonDataStore<AppState> _store;
    private AppState _state;

    public TrainingApp(string filePath)
    {
        _store = new JsonDataStore<AppState>(filePath);
        _state = _store.Load() ?? new AppState();
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== DZIENNIK TRENINGÓW ===");
            Console.WriteLine("1. Dodaj zawodnika");
            Console.WriteLine("2. Dodaj trening");
            Console.WriteLine("3. Pokaż treningi zawodnika");
            Console.WriteLine("4. Statystyki (LINQ)");
            Console.WriteLine("5. Zapisz");
            Console.WriteLine("0. Wyjście");
            Console.Write("Wybór: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddAthlete();
                    break;
                case "2":
                    AddTraining();
                    break;
                case "3":
                    ShowAthleteTrainings();
                    break;
                case "4":
                    ShowStats();
                    break;
                case "5":
                    Save();
                    break;
                case "0":
                    Save();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }
        }
    }

    private void AddAthlete()
    {
        Console.Write("Podaj imię/nick zawodnika: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Nazwa nie może być pusta.");
            return;
        }

        _state.Athletes.Add(new AthleteDto { Name = name.Trim() });
        Console.WriteLine("Dodano zawodnika.");
    }

    private void AddTraining()
    {
        if (_state.Athletes.Count == 0)
        {
            Console.WriteLine("Brak zawodników. Dodaj zawodnika najpierw.");
            return;
        }

        var athlete = PickAthlete();
        if (athlete == null) return;

        Console.WriteLine("Typ treningu: 1=BJJ, 2=ZAPASY");
        Console.Write("Wybór: ");
        var t = Console.ReadLine();

        DateTime date = ReadDate("Data (yyyy-mm-dd): ");
        int dur = ReadInt("Czas trwania w minutach: ", 1, 600);
        int intensity = ReadInt("Intensywność 1-10: ", 1, 10);

        var dto = new TrainingDto
        {
            Date = date,
            DurationMinutes = dur,
            Intensity = intensity
        };

        if (t == "1")
        {
            dto.Type = "BJJ";
            dto.Rounds = ReadInt("Liczba rund: ", 0, 50);
        }
        else if (t == "2")
        {
            dto.Type = "WRESTLING";
            dto.TechniquesCount = ReadInt("Liczba ćwiczeń technicznych: ", 0, 200);
        }
        else
        {
            Console.WriteLine("Zły typ treningu.");
            return;
        }

        athlete.Trainings.Add(dto);
        Console.WriteLine("Dodano trening.");
    }

    private void ShowAthleteTrainings()
    {
        var athlete = PickAthlete();
        if (athlete == null) return;

        if (athlete.Trainings.Count == 0)
        {
            Console.WriteLine("Brak treningów.");
            return;
        }

        Console.WriteLine($"\nTreningi: {athlete.Name}");
        foreach (var tr in athlete.Trainings.OrderByDescending(t => t.Date))
        {
            Console.WriteLine(FormatTraining(tr));
        }
    }

    private void ShowStats()
    {
        if (_state.Athletes.Count == 0)
        {
            Console.WriteLine("Brak danych.");
            return;
        }

        var minutesPerAthlete = _state.Athletes
            .Select(a => new
            {
                a.Name,
                Minutes = a.Trainings.Sum(t => t.DurationMinutes)
            })
            .OrderByDescending(x => x.Minutes);

        Console.WriteLine("\nSuma minut treningu (LINQ):");
        foreach (var x in minutesPerAthlete)
        {
            Console.WriteLine($"{x.Name}: {x.Minutes} min");
        }

        var allTrainings = _state.Athletes.SelectMany(a => a.Trainings).ToList();
        var bjjCount = allTrainings.Count(t => t.Type == "BJJ");
        var wrCount = allTrainings.Count(t => t.Type == "WRESTLING");

        Console.WriteLine($"\nŁącznie treningów: {allTrainings.Count} (BJJ: {bjjCount}, ZAPASY: {wrCount})");
    }

    private void Save()
    {
        _store.Save(_state);
        Console.WriteLine("Zapisano do pliku JSON.");
    }

    private AthleteDto? PickAthlete()
    {
        Console.WriteLine("\nWybierz zawodnika:");
        for (int i = 0; i < _state.Athletes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_state.Athletes[i].Name}");
        }

        int idx = ReadInt("Numer: ", 1, _state.Athletes.Count);
        return _state.Athletes[idx - 1];
    }

    private static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();

            if (int.TryParse(s, out int value) && value >= min && value <= max)
                return value;

            Console.WriteLine($"Podaj liczbę z zakresu {min}-{max}.");
        }
    }

    private static DateTime ReadDate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();

            if (DateTime.TryParse(s, out var d))
                return d.Date;

            Console.WriteLine("Podaj datę w formacie yyyy-mm-dd.");
        }
    }

    private static string FormatTraining(TrainingDto t)
    {
        if (t.Type == "BJJ")
            return $"BJJ  | {t.Date:yyyy-MM-dd} | {t.DurationMinutes} min | Int: {t.Intensity}/10 | Rundy: {t.Rounds}";

        return $"ZAP  | {t.Date:yyyy-MM-dd} | {t.DurationMinutes} min | Int: {t.Intensity}/10 | Techniki: {t.TechniquesCount}";
    }
}
