namespace DziennikTreningow.App;

public class AppState
{
    public List<AthleteDto> Athletes { get; set; } = new();
}

public class AthleteDto
{
    public string Name { get; set; } = "";
    public List<TrainingDto> Trainings { get; set; } = new();
}

public class TrainingDto
{
    public string Type { get; set; } = ""; // "BJJ" albo "WRESTLING"
    public DateTime Date { get; set; }
    public int DurationMinutes { get; set; }
    public int Intensity { get; set; }
    public int Rounds { get; set; }
    public int TechniquesCount { get; set; }
}