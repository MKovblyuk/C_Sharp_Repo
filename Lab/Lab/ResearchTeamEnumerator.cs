using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
    class ResearchTeamEnumerator : IEnumerator<Person>
    {
        private List<Person> participants;
        private int position = -1;

        public ResearchTeamEnumerator(List<Person> participants,List<Paper> publications)
        {
            this.participants = GetParticipantsWithPublication(participants, publications).ToList();
        }
        public Person Current => (position == -1 || position >= participants.Count) ?
            throw new InvalidOperationException() : participants[position];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if(position < participants.Count - 1)
            {
                position++;
                return true;
            }
            return false;
        }

        public void Reset() => position = -1;
        public void Dispose() { }

        private IEnumerable<Person> GetParticipantsWithPublication(List<Person> participants,List<Paper> publications)
        {
            foreach (Person person in participants)
            {
                if (publications.Any(p => p.Author.Equals(person)))
                    yield return person;
            }
        }

    }
}
