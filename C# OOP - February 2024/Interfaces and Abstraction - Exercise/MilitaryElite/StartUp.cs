using MilitaryElite.Interfaces;
using MilitaryElite.Models;
namespace MilitaryElite;

public class StartUp
{
    static void Main(string[] args) 
    {
        ICollection<ISoldier> soldiers = new List<ISoldier>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] soldierTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string soldierType = soldierTokens[0];
            string id = soldierTokens[1];
            string firstName = soldierTokens[2];
            string lastName = soldierTokens[3];
            decimal salary;
            string corps;

            ISoldier currSoldier = null;
            switch (soldierType)
            {
                case "Private":
                    salary = decimal.Parse(soldierTokens[4]);
                    currSoldier = new Private(id, firstName, lastName, salary);
                    break;
                case "LieutenantGeneral":
                    salary = decimal.Parse(soldierTokens[4]);
                    ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    foreach (var privateId in soldierTokens.Skip(5))
                    {
                        ISoldier privateToAdd = soldiers.First(s => s.Id == privateId);
                        general.AddPrivate((IPrivate)privateToAdd);
                    }

                    currSoldier = general;
                    break;
                case "Engineer":
                    salary = decimal.Parse(soldierTokens[4]);
                    corps = soldierTokens[5];

                    try
                    {
                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                        string[] repairsTokens = soldierTokens.Skip(6).ToArray();

                        for (int i = 0; i < repairsTokens.Length; i += 2)
                        {
                            string partName = repairsTokens[i];
                            int hoursWorked = int.Parse(repairsTokens[i + 1]);
                            IRepair repair = new Repair(partName, hoursWorked);
                            engineer.AddRepair(repair);
                        }

                        currSoldier = engineer;
                    }

                    catch (Exception ex)
                    {
                        continue;
                    }
                    break;
                case "Commando":
                    salary = decimal.Parse(soldierTokens[4]);
                    corps = soldierTokens[5];

                    try
                    {
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                        string[] missionsTokens = soldierTokens.Skip(6).ToArray();

                        for (int i = 0; i < missionsTokens.Length; i += 2)
                        {
                            try
                            {
                                string missionCodeName = missionsTokens[i];
                                string missionState = missionsTokens[i + 1];
                                IMission mission = new Mission(missionCodeName, missionState);
                                commando.AddMission(mission);
                            }

                            catch (Exception ex)
                            {
                                continue;
                            }
                        }

                        currSoldier = commando;
                    }

                    catch (Exception ex)
                    {
                        continue;
                    }
                    break;
                case "Spy":
                    int codeNumber = int.Parse(soldierTokens[4]);
                    currSoldier = new Spy(id, firstName, lastName, codeNumber);
                    break;
            }
            if(currSoldier is not null)
            {
                soldiers.Add(currSoldier);
            }
        }

        Console.WriteLine(string.Join("\n", soldiers));
    }
}
