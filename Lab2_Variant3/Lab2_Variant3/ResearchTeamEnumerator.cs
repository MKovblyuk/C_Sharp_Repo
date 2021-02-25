using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Lab2_Variant3
{
    class ResearchTeamEnumerator : IEnumerator
    {
        private ArrayList participants;
        private int position = -1;

        public ResearchTeamEnumerator(ArrayList participants,ArrayList publications)
        {
            this.participants = (ArrayList)GetParticipantsWithPublication(participants, publications);
        }
        public object Current => (position == -1 || position >= participants.Count) ?
            throw new InvalidOperationException() : participants[position];

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


        private IEnumerable GetParticipantsWithPublication(ArrayList participants,ArrayList publications)
        {
            foreach (Person person in participants)
            {
                if (publications.ToArray().Any(p => ((Paper)p).Author.Equals(person)))
                    yield return person;
            }
        }
    }
}
