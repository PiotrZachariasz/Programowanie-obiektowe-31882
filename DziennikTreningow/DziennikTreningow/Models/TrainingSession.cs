namespace DziennikTreningow.Models;

public abstract class TrainingSession
{
    public DateTime Date { get; private set; }
    public int DurationMinutes { get; private set; }
    public int Intensity { get; private set; }

    protected TrainingSession(DateTime date, int durationMinutes, int intensity)
    {
        Date = date;
        DurationMinutes = durationMinutes;
        Intensity = intensity;
    }

    public virtual string GetSummary()
    {
        return $"{Date:yyyy-MM-dd} | {DurationMinutes} min | Intensywność: {Intensity}/10";
    }
}