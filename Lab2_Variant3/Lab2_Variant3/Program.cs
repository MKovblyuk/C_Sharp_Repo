using System;
using System.Collections;
using System.Linq;

namespace Lab2_Variant3
{
    class Program
    {     
        static void Main(string[] args)
        {
            Team team1 = new Team("A", 23);
            Team team2 = new Team("A", 23);
            ResearchTeam team3 = new ResearchTeam();
            Console.WriteLine("Hash team1 = " + team1.GetHashCode());
            Console.WriteLine("Hash team2 = " + team2.GetHashCode());
            Console.WriteLine("team1 equals team2 : " + team1.Equals(team2));

            try
            {
                team1.RegisterNumber = -2;
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            ResearchTeam researchTeam = new ResearchTeam("resThemeTT","orgNameAAA",22,TimeFrame.Long);
            researchTeam.AddPapers(
                new Paper("paper1",new Person() { Name = "Bob"},new DateTime(2020,6,23)),
                new Paper("paper2", new Person() { Name = "Tom" }, new DateTime(2018, 7, 11)),
                new Paper("paper3", new Person() { Name = "Nick" }, new DateTime(2019, 6, 4)),
                new Paper("paper4", new Person() { Name = "Bob" }, new DateTime(2021, 6, 23)),
                new Paper("paper5", new Person() { Name = "Tom" }, new DateTime(2018, 8, 11))
            );

            Console.WriteLine($"Researc team:\n{researchTeam}\n");
            Console.WriteLine($"Team:\n{researchTeam.Team}\n");

            ResearchTeam researchCopy = (ResearchTeam)researchTeam.DeepCopy();
            researchTeam.Name = "NEW NAME";
            Console.WriteLine($"\nOriginal:\n{researchTeam}\n");
            Console.WriteLine($"\nCopy:\n{researchCopy}\n");


            researchTeam.Participants = new ArrayList(){
                new Person() { Name = "Bob" },
                new Person() { Name = "Tom" },
                new Person() { Name = "Fred" },
                new Person() { Name = "George" },
                new Person() { Name = "Nick" }
            };


            Console.WriteLine("\nParticipants without publications:\n");
            foreach(Person person in researchTeam.GetParticipantsWithoutPublication())
            {
                Console.WriteLine($"{person}\n");
            }

            Console.WriteLine("\nPublications for the last two years:\n");
            foreach (Paper paper in researchTeam.GetPublicationsLastYears(2))
            {
                Console.WriteLine($"{paper}\n");
            }

            Console.WriteLine("\nParticipants with more than one publications:\n");
            foreach (Person person in researchTeam.GetParticipantsWithMoreThanOnePub())
            {
                Console.WriteLine($"{person}\n");
            }

            Console.WriteLine("\nPublications for the last year:\n");
            foreach (Paper paper in researchTeam.GetPublicationsLastYear())
            {
                Console.WriteLine($"{paper}\n");
            }

        }

    }
}
