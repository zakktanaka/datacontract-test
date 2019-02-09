using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace DataContractTest
{
    [DataContract]
    public class TestClass
    {
        [DataMember]
        public int Number;
        //DataMemberAttributeが無いのでシリアル化されない
        public string Message;
        //プライベートでもDataMemberAttributeがあればシリアル化される
        [DataMember]
        private string PrivateMessage;

        [DataMember(Name = "int", IsRequired = true)]
        public int Int { get; set; }

        [DataMember(Name = "intnull", IsRequired = true)]
        public int? IntNullable { get; set; }

        [DataMember]
        public string String { get; set; }

        [DataMember]
        public string NullString { get; private set; }

        //コンストラクタ
        public TestClass()
        {
            this.Number = 10;
            this.Message = "こんにちは。";
            this.PrivateMessage = "はじめまして。";
        }

        //コンストラクタ
        public TestClass(int num, string msg, string pmsg)
        {
            this.Number = num;
            this.Message = msg;
            this.PrivateMessage = pmsg;
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestClass obj = new TestClass();

            DataContractSerializer serializer =
                new DataContractSerializer(typeof(TestClass));
            var settings = new XmlWriterSettings();
            settings.Encoding = new System.Text.UTF8Encoding(false);

            var sw = new StringWriter();
            XmlWriter xw = XmlWriter.Create(sw);
            serializer.WriteObject(xw, obj);
            xw.Close();
            Console.WriteLine(sw.GetStringBuilder().ToString());
        }

        [TestMethod]
        public void TestMethod2()
        {
            var sr = new StringReader("<?xml version=\"1.0\" encoding=\"utf-16\" ?><TestClass xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns =\"http://schemas.datacontract.org/2004/07/DataContractTest\" ><NullString i:nil=\"true\" /><Number>10</Number><PrivateMessage>はじめまして。</PrivateMessage><String i:nil=\"true\" /><int>0</int></TestClass>");
            DataContractSerializer serializer =
                new DataContractSerializer(typeof(TestClass));

            var xr = XmlReader.Create(sr);
            var t = (TestClass) serializer.ReadObject(xr);
        }
    }
}
