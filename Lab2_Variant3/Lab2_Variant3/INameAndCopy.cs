using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_Variant3
{
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}
