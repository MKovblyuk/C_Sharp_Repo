using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class Team : INameAndCopy,IComparable
    {
        protected string organizationName;
        protected int registerNumber;

        public Team()
        {
            organizationName = "default organization name";
            registerNumber = 1;
        }
        public Team(string organizationName, int registerNumber)
        {
            this.organizationName = organizationName;
            this.registerNumber = registerNumber;
        }
        public string Name
        {
            get { return organizationName; }
            set { organizationName = value; }
        }

        public int RegisterNumber
        {
            get { return registerNumber; }
            set
            {
                registerNumber = value > 0 ? value : 
                    throw new ArgumentOutOfRangeException("Argument must be greater than 0");
            }
        }

        public virtual object DeepCopy() => new Team(organizationName, registerNumber);
        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType())) 
                return false;
            else
            {
                Team t = (Team)obj;
                return organizationName.Equals(t.Name) && registerNumber.Equals(t.RegisterNumber);
            }
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash *= 23 + organizationName.GetHashCode();
            hash *= 23 + registerNumber.GetHashCode();
            return hash;
        }

        public override string ToString() =>"name = " + organizationName + "\nregister number = " + registerNumber;

        public static bool operator ==(Team t1, Team t2) => t1.Equals(t2);
        public static bool operator !=(Team t1, Team t2) => !(t1 == t2);


        public int CompareTo(object obj)
        {
            Team t = obj as Team;
            if (t != null)
                return registerNumber.CompareTo(t.RegisterNumber);
            else throw new Exception("Impossible to compare two objects");

        }
    }
}
