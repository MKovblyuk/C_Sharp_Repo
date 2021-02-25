using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_Variant3
{
    class Paper
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

    }
}
