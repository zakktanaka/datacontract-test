using System;
using System.Collections.Generic;
using System.Reflection;

namespace DataContractTest.DataLoader.Configuration
{
    class ClassMap
    {
        public List<Member> Members { get; set; }
        public Type Type { get; set; }
        public ConstructorInfo ConstructorInfo { get; set; }
    }
}
