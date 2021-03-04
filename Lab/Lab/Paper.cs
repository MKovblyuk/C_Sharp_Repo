using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class Paper : INameAndCopy
    {
        public string Name { get; set; }
        public Person Author { get; set; }
        public DateTime PublicationDate { get; set; }

        public Paper()
        {
            Name = "default publication name";
            Author = new Person();
            PublicationDate = new DateTime(1, 1, 1);
        }
        public Paper(string name,Person author,DateTime publicationDate)
        {
            Name = name;
            Author = author;
            PublicationDate = publicationDate;
        }

        public override string ToString() =>
            new StringBuilder("Publication Name: ").Append(Name)
            .Append("\nPublication Date: ").Append(PublicationDate)
            .Append("\nAuthor:\n").Append(Author).ToString();

        public virtual object DeepCopy() => new Paper(Name, (Person)Author.DeepCopy(), PublicationDate);

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                Paper paper = (Paper)obj;
                return Name.Equals(paper.Name) &&
                    Author.Equals(paper.Author) &&
                    PublicationDate.Equals(paper.PublicationDate);
            }
            else return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash *= 23 + Name.GetHashCode();
            hash *= 23 + Author.GetHashCode();
            hash *= 23 + PublicationDate.GetHashCode();
            return hash;
        }

        public static bool operator ==(Paper p1, Paper p2) => p1.Equals(p2);
        public static bool operator !=(Paper p1, Paper p2) => !(p1 == p2);
    }
}
