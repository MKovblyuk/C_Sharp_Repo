using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace Lab
{
    class ResearchTeam : Team, INameAndCopy, IEnumerable<Person>, IComparer<ResearchTeam>
    {
        private string researchTheme;
        private TimeFrame researchDuration;
        private List<Person> participants = new List<Person>();
        private List<Paper> publications = new List<Paper>();

        public ResearchTeam()
        {
            researchTheme = "default research theme";
            researchDuration = TimeFrame.Long;
        }
        public ResearchTeam(string researchTheme, string organizationName,int registerNumber, TimeFrame researchDuration)
            : base(organizationName, registerNumber)
        {
            this.researchTheme = researchTheme;
            this.researchDuration = researchDuration;
        }

        public string ResearchTheme
        {
            get { return researchTheme; }
            set { researchTheme = value; }
        }


        public TimeFrame ResearchDuration
        {
            get { return researchDuration; }
            set { researchDuration = value; }
        }

        public List<Person> Participants
        {
            get { return participants; }
            set { participants = value; }
        }

        public List<Paper> Publications
        {
            get { return publications; }
            set { publications = value; }
        }

        public Team Team
        {
            get { return new Team(organizationName, registerNumber); }
            set
            {
                organizationName = value.Name;
                registerNumber = value.RegisterNumber;
            }
        }

        public bool this[TimeFrame time] => time == researchDuration;

        public Paper Paper => publications == null ? null : publications
            .Aggregate((p1,p2) => p1.PublicationDate > p2.PublicationDate ? p1 : p2);

        public void AddPapers(params Paper[] papers) => publications.AddRange(papers);

        public virtual string ToShortString() =>
            new StringBuilder(base.ToString())
            .Append("\nResearch theme: ").Append(researchTheme)
            .Append("\nResearch duration: ").Append(researchDuration).ToString();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(ToShortString());
            sb.Append("\nPublications:\n");
            foreach(Paper paper in publications)
            {
                sb.Append("\n").Append(paper).Append("\n");
            }

            sb.Append("\nParticipants:\n");
            foreach(Person person in participants)
            {
                sb.Append("\n").Append(person).Append("\n");
            }

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType())) 
                return false;
            else 
            {
                ResearchTeam rt = (ResearchTeam)obj;

                bool equalsParticipants = false;
                if (Participants == rt.Participants)
                    equalsParticipants = true;
                else if (Participants != null && rt.Participants != null)
                    equalsParticipants = Participants.SequenceEqual(rt.Participants);

                bool equalsPublications = false;
                if (Publications == rt.Publications)
                    equalsPublications = true;
                else if (Publications != null && rt.Publications != null)
                    equalsPublications = Publications.SequenceEqual(rt.Publications);

                return equalsParticipants &&
                    equalsPublications &&
                    Team.Equals(rt.Team) &&
                    researchTheme.Equals(rt.ResearchTheme) &&
                    researchDuration.Equals(rt.ResearchDuration);
;
            }

        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash *= 23 + researchTheme.GetHashCode();
            hash *= 23 + researchDuration.GetHashCode();

            if (publications != null)
            {
                foreach (Paper paper in publications)
                    hash *= 23 + paper.GetHashCode();
            }

            if (participants != null)
            {
                foreach (Person person in participants)
                    hash *= 23 + person.GetHashCode();
            }

            return hash;
        }

        public override object DeepCopy()
        {
            ResearchTeam researchTeam = new ResearchTeam(researchTheme, organizationName, registerNumber, researchDuration);
            foreach(Paper paper in publications)
            {
                researchTeam.Publications.Add((Paper)paper.DeepCopy());
            }
            foreach(Person person in participants)
            {
                researchTeam.Participants.Add((Person)person.DeepCopy());
            }

            return researchTeam;
        }

        public static bool operator ==(ResearchTeam r1, ResearchTeam r2) => r1.Equals(r2);
        public static bool operator !=(ResearchTeam r1, ResearchTeam r2) => !(r1 == r2);

        public IEnumerable<Person> GetParticipantsWithoutPublication()
        {
            foreach (Person person in participants)
            {
                if (!publications.Any(p => p.Author.Equals(person)))
                    yield return person;
            }
        }

        public IEnumerable<Paper> GetPublicationsLastYears(int lastYears)
        {
            foreach(Paper paper in publications)
            {
                if (paper.PublicationDate.Year > DateTime.Now.Year - lastYears)
                    yield return paper;
            }
        }

        public IEnumerator<Person> GetEnumerator() => new ResearchTeamEnumerator(Participants, Publications);
        IEnumerator  IEnumerable.GetEnumerator() => this.GetEnumerator();
        public IEnumerable<Person> GetParticipantsWithMoreThanOnePub()
        {
            foreach(Person person in participants)
            {
                if (publications.Where((p) => p.Author.Equals(person)).Count() > 1)
                    yield return person;
            }
        }
        public IEnumerable<Paper> GetPublicationsLastYear() => GetPublicationsLastYears(1);
        public int Compare(ResearchTeam t1, ResearchTeam t2) => string.Compare(t1.ResearchTheme, t2.ResearchTheme);

    }
}
