using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Paper> publications = new List<Paper>
            {
                new Paper(),
                new Paper(),
                new Paper(),
                new Paper()
            };

            List<Person> participants = new List<Person>
            {
                new Person(),
                new Person(),
                new Person()
            };

            ResearchTeam t1 = new ResearchTeam("theme1", "org1", 5, TimeFrame.Long)
            {
                Publications = publications.Take(4).ToList(),
                Participants = participants.Take(3).ToList()
            };
            ResearchTeam t2 = new ResearchTeam("theme5", "org13", 2, TimeFrame.TwoYears)
            {
                Publications = publications.Take(3).ToList(),
                Participants = participants.Take(2).ToList()
            };
            ResearchTeam t3 = new ResearchTeam("theme6", "org14", 3, TimeFrame.Long)
            {
                Publications = publications.Take(3).ToList(),
                Participants = participants.Take(2).ToList()
            };
            ResearchTeam t4 = new ResearchTeam("theme3", "org5", 15, TimeFrame.TwoYears)
            {
                Publications = publications.Take(1).ToList(),
                Participants = participants.Take(3).ToList()
            };
            ResearchTeam t5 = new ResearchTeam("theme2", "org2", 12, TimeFrame.Year)
            {
                Publications = publications.Take(4).ToList(),
                Participants = participants.Take(2).ToList()
            };
            ResearchTeam t6 = new ResearchTeam("theme11", "org2", 5, TimeFrame.TwoYears)
            {
                Publications = publications.Take(2).ToList(),
                Participants = participants.Take(3).ToList()
            };

            ResearchTeamCollection collection = new ResearchTeamCollection();
            collection.AddResearchTeams(t1, t2, t3, t4, t5, t6);

            Console.WriteLine("Sorted by register number:");
            collection.SortByRegisterNumber();
            Console.WriteLine(collection.ToShortString());

            Console.WriteLine("Sorted by research theme:");
            collection.SortByResearchTheme();
            Console.WriteLine(collection.ToShortString());

            Console.WriteLine("Sorted by publications count:");
            collection.SortByPublicationsCount();
            Console.WriteLine(collection.ToShortString());

            Console.WriteLine("Min register number:");
            Console.WriteLine(collection.MinRegisterNumber);

            Console.WriteLine("Research duration TwoYears:");
            foreach(var rt in collection.TwoYearsResearches)
            {
                Console.WriteLine(rt);
            }

            Console.WriteLine("Grouping by publications count:");
            foreach(var g in collection.NGroup(2))
            {
                Console.WriteLine($"Key = {g.Key}");
                Console.WriteLine("Research teams:");
                foreach (var t in g)
                    Console.WriteLine(t);
            }

            int elementsCount = 0;
            string inputStr;
            do
            {
                Console.WriteLine("Enter elements count: ");
                inputStr = Console.ReadLine();
            }
            while (!int.TryParse(inputStr,out elementsCount) || elementsCount < 1);

            TestCollections test = new TestCollections(elementsCount);
            Console.WriteLine("Showing execution time for first object:");
            test.ShowExecutionTime(TestCollections.GetResearchTeam(0));

            Console.WriteLine("Showing execution time for middle object:");
            test.ShowExecutionTime(TestCollections.GetResearchTeam(elementsCount / 2));

            Console.WriteLine("Showing execution time for last object:");
            test.ShowExecutionTime(TestCollections.GetResearchTeam(elementsCount - 1));

            Console.WriteLine("Showing execution time for non-existent object:");
            test.ShowExecutionTime(TestCollections.GetResearchTeam(elementsCount + 1));

        }

    }
}
