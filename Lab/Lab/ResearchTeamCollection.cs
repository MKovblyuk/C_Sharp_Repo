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
            {
                researchTeams.Add(new ResearchTeam());
                OnResearchTeamAdded(new TeamListHandlerEventArgs(CollectionName, 
                    ResearchTeamAddedMessage, researchTeams.Count - 1));
            }                        
        }

        public void AddResearchTeams(params ResearchTeam[] teams)
        {
            foreach(var team in teams)
            {
                researchTeams.Add(team);
                OnResearchTeamAdded(new TeamListHandlerEventArgs(CollectionName,
                    ResearchTeamAddedMessage, researchTeams.Count - 1));
            }
        }
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

        public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);

        public string CollectionName { get; set; }

        public void InsertAt(int j,ResearchTeam researchTeam)
        {
            if (researchTeams.Count > j && j >= 0)
            {
                researchTeams.Insert(j, researchTeam);
                OnResearchTeamInserted(new TeamListHandlerEventArgs(CollectionName, ResearchTeamInsertedMessage, j));
            }
            else
            {
                researchTeams.Add(researchTeam);
                OnResearchTeamAdded(new TeamListHandlerEventArgs(CollectionName,
                    ResearchTeamAddedMessage, researchTeams.Count - 1));
            }   
        }

        public ResearchTeam this[int index]
        {
            get { return researchTeams[index]; }
            set { researchTeams[index] = value; }
        }

        public event TeamListHandler ResearchTeamAdded;
        public event TeamListHandler ResearchTeamInserted;

        protected virtual void OnResearchTeamAdded(TeamListHandlerEventArgs e) => ResearchTeamAdded?.Invoke(this, e);
        protected virtual void OnResearchTeamInserted(TeamListHandlerEventArgs e) => ResearchTeamInserted?.Invoke(this, e);

        public string ResearchTeamAddedMessage { get; set; } = "ResearchTeam item added in collection";
        public string ResearchTeamInsertedMessage { get; set; } = "ResearchTeam item inserted in collection";
    }
}
