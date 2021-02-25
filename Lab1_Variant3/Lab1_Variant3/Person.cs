using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_Variant3
{
    class Person
    {
        private string name;
        private string surname;
        private DateTime birthDate;

        public Person()
        {
            name = "default person name";
            surname = "default person surname";
            birthDate = new DateTime(1, 1, 1);
        }
        public Person(string name, string surname, DateTime birthDate)
        {
            this.name = name;
            this.surname = surname;
            this.birthDate = birthDate;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public int BirthYear
        {
            get { return birthDate.Year; }
            set { birthDate = new DateTime(value, birthDate.Month, birthDate.Day); }
        }

        public override string ToString() =>
            ToShortString() + "\nbirth date: " + birthDate.ToString();

        public virtual string ToShortString() =>
            "name: " + name + "\nsurname: " + surname;
    }
}
