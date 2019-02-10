using System;
using System.Collections.Generic;
using System.Text;

namespace DataContractTest.DataLoader.Parser
{
    interface IStringParser<T> : IStringParser
    {
        T ConvertFrom(string stringvalue);
        string ConvertTo(T objectvalue);
        Type TargetType { get; }
    }
}
