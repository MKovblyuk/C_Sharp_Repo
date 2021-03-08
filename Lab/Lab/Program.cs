using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeamCollection collection1 = new ResearchTeamCollection() { CollectionName = "Collection 1"};
            ResearchTeamCollection collection2 = new ResearchTeamCollection() { CollectionName = "Collection 2"};

            TeamsJournal teamsJournal1 = new TeamsJournal();
            TeamsJournal teamsJournal2 = new TeamsJournal();

            collection1.ResearchTeamAdded += teamsJournal1.ResearchTeamChanged;
            collection1.ResearchTeamInserted += teamsJournal1.ResearchTeamChanged;

            collection1.ResearchTeamAdded += teamsJournal2.ResearchTeamChanged;
            collection1.ResearchTeamInserted += teamsJournal2.ResearchTeamChanged;
            collection2.ResearchTeamAdded += teamsJournal2.ResearchTeamChanged;
            collection2.ResearchTeamInserted += teamsJournal2.ResearchTeamChanged;

            // collection 1

            collection1.AddDefaults();
            collection1.AddResearchTeams(
                new ResearchTeam(),
                new ResearchTeam(),
                new ResearchTeam()
            );

            collection1.InsertAt(3, new ResearchTeam());
            collection1.InsertAt(9, new ResearchTeam());



            // collection 2

            collection2.AddDefaults();
            collection2.AddResearchTeams(
                new ResearchTeam(),
                new ResearchTeam(),
                new ResearchTeam()
            );

            collection2.InsertAt(3, new ResearchTeam());
            collection2.InsertAt(9, new ResearchTeam());

            Console.WriteLine("Teams journal 1");
            Console.WriteLine(teamsJournal1);

            Console.WriteLine("Teams journal 2");
            Console.WriteLine(teamsJournal2);
        }

    }
}
