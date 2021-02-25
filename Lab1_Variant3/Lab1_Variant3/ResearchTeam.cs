using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab1_Variant3
{
    class ResearchTeam
    {
        private string researchName;
        private string organizationName;
        private int registrationNumber;
        private TimeFrame researchDuration;
        private Paper[] papers;

        public ResearchTeam()
        {
            researchName = "default research name";
            organizationName = "default organization name";
            registrationNumber = 0;
            researchDuration = TimeFrame.Long;
        }
        public ResearchTeam(string researchName, string organizationName,int registrationNumber,TimeFrame researchDuration)
        {
            this.researchName = researchName;
            this.organizationName = organizationName;
            this.registrationNumber = registrationNumber;
            this.researchDuration = researchDuration;
        }

        public string ResearchName
        {
            get { return researchName; }
            set { researchName = value; }
        }

        public string OrganizationName
        {
            get { return organizationName; }
            set { organizationName = value; }
        }

        public int RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; }
        }

        public TimeFrame ResearchDuration
        {
            get { return researchDuration; }
            set { researchDuration = value; }
        }

        public Paper[] Papers
        {
            get { return papers; }
            set { papers = value; }
        }

        public bool this[TimeFrame time] => time == researchDuration;

        public Paper Paper => papers == null ? null :
            papers.Aggregate((p1,p2) => p1.PublicationDate > p2.PublicationDate ? p1 : p2);

        public void AddPapers(params Paper[] papers) => 
            this.papers = this.papers == null ? papers : this.papers.Concat(papers).ToArray();

        public virtual string ToShortString() =>
            new StringBuilder("Research name: ").Append(researchName)
            .Append("\nOrganization name: ").Append(organizationName)
            .Append("\nRegistration number: ").Append(registrationNumber)
            .Append("\nResearch duration: ").Append(researchDuration).ToString();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(ToShortString());
            sb.Append("\nPublications:\n");
            foreach(Paper paper in papers)
            {
                sb.Append("\n").Append(paper).Append("\n");
            }
            return sb.ToString();
        }
    }
}
