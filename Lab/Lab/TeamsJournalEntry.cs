using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class TeamsJournalEntry
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public int NewElementNumber { get; set; }

        public TeamsJournalEntry(string collectionName,string changeType,int newElementNumber)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            NewElementNumber = newElementNumber;
        }

        public override string ToString() => $"CollectionName: {CollectionName}\n" +
            $"ChangeType: {ChangeType}\nNewElementNumber: {NewElementNumber}\n";

    }
}
