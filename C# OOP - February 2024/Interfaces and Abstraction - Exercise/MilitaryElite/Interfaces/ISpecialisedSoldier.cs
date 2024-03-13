namespace MilitaryElite.Interfaces
{
    public enum Corps
    {
        Airforces,
        Marines
    }
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
