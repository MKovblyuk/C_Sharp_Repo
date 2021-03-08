using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class TeamsJournal
    {
        private List<TeamsJournalEntry> teams = new List<TeamsJournalEntry>();

        public void ResearchTeamChanged(object sender, TeamListHandlerEventArgs e)
        {
            teams.Add(new TeamsJournalEntry(e.CollectionName, e.ChangeType, e.ElementNumber));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            teams.ForEach(t => sb.Append(t).Append("\n"));

            return sb.ToString();
        }
    }
}
