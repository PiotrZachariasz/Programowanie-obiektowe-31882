namespace DziennikTreningow.Models;

public class BjjTraining : TrainingSession
{
    public int Rounds { get; private set; }

    public BjjTraining(DateTime date, int durationMinutes, int intensity, int rounds)
        : base(date, durationMinutes, intensity)
    {
        Rounds = rounds;
    }

    public override string GetSummary()
    {
        return "BJJ  | " + base.GetSummary() + $" | Rundy: {Rounds}";
    }
}