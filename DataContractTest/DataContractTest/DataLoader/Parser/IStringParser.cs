using System;
using System.Collections.Generic;
using System.Text;

namespace DataContractTest.DataLoader.Parser
{
    interface IStringParser
    {
        object ConvertObjectFrom(string stringvalue);
        string ConvertObjectTo(object objectvalue);
    }
}
