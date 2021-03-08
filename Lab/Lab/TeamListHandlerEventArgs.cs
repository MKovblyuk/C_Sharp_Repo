using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class TeamListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public int ElementNumber { get; set; }

        public TeamListHandlerEventArgs(string collectionName,string changeType,int elementNumber)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ElementNumber = elementNumber;
        }

        public override string ToString() => $"CollectionName: {CollectionName}\n" +
            $"ChangeType: {ChangeType}\nElementNumber: {ElementNumber}\n";
    }
}
