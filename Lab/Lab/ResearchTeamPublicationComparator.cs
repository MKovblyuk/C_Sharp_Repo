using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class ResearchTeamPublicationComparator : IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam t1, ResearchTeam t2) => t1.Publications.Count - t2.Publications.Count;
    }
}
