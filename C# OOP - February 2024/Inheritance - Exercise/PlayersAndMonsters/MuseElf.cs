namespace PlayersAndMonsters;

internal class MuseElf : Elf
{
    public MuseElf(string username, int level) : base(username, level)
    {
        Username = username;
        Level = level;
    }

    public string Username { get; set; }
    public int Level { get; set; }

    public override string ToString()
    {
        return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
    }
}
