namespace DziennikTreningow.Models;

public class Athlete
{
    public string Name { get; private set; }
    public List<TrainingSession> Trainings { get; private set; } = new();

    public Athlete(string name)
    {
        Name = name;
    }

    public void AddTraining(TrainingSession session)
    {
        Trainings.Add(session);
    }
}