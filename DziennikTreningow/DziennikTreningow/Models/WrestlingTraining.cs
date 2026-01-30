namespace DziennikTreningow.Models;

public class WrestlingTraining : TrainingSession
{
    public int TechniquesCount { get; private set; }

    public WrestlingTraining(DateTime date, int durationMinutes, int intensity, int techniquesCount)
        : base(date, durationMinutes, intensity)
    {
        TechniquesCount = techniquesCount;
    }

    public override string GetSummary()
    {
        return "ZAP  | " + base.GetSummary() + $" | Techniki: {TechniquesCount}";
    }
}