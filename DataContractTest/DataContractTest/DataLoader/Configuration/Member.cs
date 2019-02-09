using System.Reflection;

namespace DataContractTest.DataLoader.Configuration
{
    class Member
    {
        public string Name { get; set; }
        public bool Mandatory { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
    }
}
