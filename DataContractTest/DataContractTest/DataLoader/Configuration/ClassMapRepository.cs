using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace DataContractTest.DataLoader.Configuration
{
    class ClassMapRepository
    {
        private static ConcurrentDictionary<Type, Lazy<ClassMap>> cache = new ConcurrentDictionary<Type, Lazy<ClassMap>>();

        private static void CheckValidType(Type type)
        {
            if (type.GetCustomAttributes(typeof(DataContractAttribute), false).Length == 0)
            {
                throw new Exception();
            }

            if (GetDefaultConstructorInfo(type) == null)
            {
                throw new Exception();
            }
        }

        private static ConstructorInfo GetDefaultConstructorInfo(Type type)
        {
            return type.GetConstructor(Type.EmptyTypes);
        }

        private static bool ShouldBeMember(PropertyInfo propertyinfo)
        {
            return
                GetDataMemberAttribute(propertyinfo) != null && 
                propertyinfo.GetCustomAttribute(typeof(IgnoreDataMemberAttribute)) == null;
        }

        private static DataMemberAttribute GetDataMemberAttribute(PropertyInfo propertyinfo)
        {
            return propertyinfo.GetCustomAttribute(typeof(DataMemberAttribute)) as DataMemberAttribute;
        }

        private static ClassMap GenerateClassMap(Type type)
        {
            CheckValidType(type);

            return new ClassMap
            {
                Type = type,
                ConstructorInfo = GetDefaultConstructorInfo(type),
                Members = GenerateMembers(type)
            };
        }

        private static Member NewMember(PropertyInfo propertyinfo)
        {
            var datamember = GetDataMemberAttribute(propertyinfo);

            return new Member
            {
                Name = datamember.Name ?? propertyinfo.Name,
                Mandatory = datamember.IsRequired,
                PropertyInfo = propertyinfo,
            };
        }

        private static List<Member> GenerateMembers(Type type)
        {
            foreach(var propertyinfo in type.GetProperties().Where(pi => ShouldBeMember(pi)))
            {

            }

            return type.GetProperties()
                .Where(pi => ShouldBeMember(pi))
                .Select(pi => NewMember(pi))
                .ToList();
        }

        public ClassMap GetClassMap(Type type)
        {
            return cache.GetOrAdd(type, key => new Lazy<ClassMap>(()=> GenerateClassMap(key))).Value;
        }
    }
}
