using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class Person : INameAndCopy
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

        public override int GetHashCode()
        {
            int hash = 17;
            hash *= 23 + surname.GetHashCode();
            hash *= 23 + name.GetHashCode();
            hash *= 23 + birthDate.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
                return false;
            else
            {
                Person p = (Person)obj;
                return name.Equals(p.Name) &&
                    surname.Equals(p.Surname) &&
                    birthDate.Equals(p.BirthDate);
            }
        }
        
        public virtual object DeepCopy() => new Person(Name, Surname, BirthDate);
        public static bool operator ==(Person p1, Person p2) => p1.Equals(p2);
        public static bool operator !=(Person p1, Person p2) => !(p1 == p2);
    }
}
