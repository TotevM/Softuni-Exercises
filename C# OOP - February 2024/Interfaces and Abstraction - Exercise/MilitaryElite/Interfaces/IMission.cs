namespace MilitaryElite.Interfaces;

public enum State
{
    inProgress,
    Finished
}
public interface IMission
{
    string CodeName { get; }
    State State { get; }
    void CompleteMission();
    string PrintMission();
}
