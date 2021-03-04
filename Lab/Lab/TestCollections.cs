using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class TestCollections
    {
        private List<Team> listTeam = new List<Team>();
        private List<string> listString = new List<string>();
        private Dictionary<Team, ResearchTeam> dictTeam = new Dictionary<Team, ResearchTeam>();
        private Dictionary<string, ResearchTeam> dictString = new Dictionary<string, ResearchTeam>();

        public static ResearchTeam GetResearchTeam(int value) =>
            new ResearchTeam { Team = new Team($"name{value}", value)};

        public TestCollections(int count)
        {
            for(int i = 0;i < count; i++)
            {
                ResearchTeam researchTeam = new ResearchTeam { Team = new Team($"name{i}", i) };

                listTeam.Add(researchTeam.Team);
                listString.Add(researchTeam.Team.ToString());
                dictString.Add(researchTeam.Team.ToString(),(ResearchTeam)researchTeam.DeepCopy());
                dictTeam.Add(researchTeam.Team, researchTeam);
            }
        }

        public void ShowExecutionTime(ResearchTeam researchTeam)
        {
            int start;
            int end;
            bool state;
            Team team = researchTeam.Team;
            String str = team.ToString();

            start = Environment.TickCount;
            state = listTeam.Contains(team);
            end = Environment.TickCount;
            Console.WriteLine($"listTeam : {end - start}");

            start = Environment.TickCount;
            state = listString.Contains(str);
            end = Environment.TickCount;
            Console.WriteLine($"listString : {end - start}");

            start = Environment.TickCount;
            state = dictTeam.ContainsKey(team);
            end = Environment.TickCount;
            Console.WriteLine($"dictTeam by key : {end - start}");

            start = Environment.TickCount;
            state = dictString.ContainsKey(str);
            end = Environment.TickCount;
            Console.WriteLine($"dictString by key : {end - start}");

            start = Environment.TickCount;
            state = dictTeam.ContainsValue(researchTeam);
            end = Environment.TickCount;
            Console.WriteLine($"dictTeam by value : {end - start}");

            start = Environment.TickCount;
            state = dictString.ContainsValue(researchTeam);
            end = Environment.TickCount;
            Console.WriteLine($"dictString by value : {end - start}");
        }

        
    }
}
