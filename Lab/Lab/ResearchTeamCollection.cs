using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab
{
    class ResearchTeamCollection
    {
        private List<ResearchTeam> researchTeams = new List<ResearchTeam>();
        
        public void AddDefaults()
        {
            int teamsCount = 3;
            for (int i = 0; i < teamsCount; i++)
                researchTeams.Add(new ResearchTeam());
        }

        public void AddResearchTeams(params ResearchTeam[] teams) => researchTeams.AddRange(teams);

        public void SortByRegisterNumber() => researchTeams.Sort();
        public void SortByResearchTheme() => researchTeams.Sort(new ResearchTeam());
        public void SortByPublicationsCount() => researchTeams.Sort(new ResearchTeamPublicationComparator());

        public int MinRegisterNumber => researchTeams.Count > 0 ? researchTeams.Min(t => t.RegisterNumber) : 0;
        public IEnumerable<ResearchTeam> TwoYearsResearches =>
            researchTeams.Where(t => t.ResearchDuration == TimeFrame.TwoYears);

        public List<ResearchTeam> ResearchesWithParticipants(int count) => researchTeams.Count > 0 ?
            researchTeams.Where(t => t.Participants.Count() == count).ToList() : new List<ResearchTeam>();

        public List<IGrouping<int,ResearchTeam>> NGroup(int value) => researchTeams.Count > 0 ?
            researchTeams.GroupBy(t => t.Publications.Count()).ToList() : new List<IGrouping<int,ResearchTeam>>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            researchTeams.ForEach(team => sb.Append(team.ToString()).Append("\n"));
            return sb.ToString();
        }

        public virtual string ToShortString()
        {
            StringBuilder sb = new StringBuilder();
            researchTeams.ForEach(team =>
                sb.Append(team.ToShortString())
                .Append("\nPublications count: ").Append(team.Publications.Count)
                .Append("\nParticipants count: ").Append(team.Participants.Count)
                .Append("\n"));

            return sb.ToString();
        }
    }
}
