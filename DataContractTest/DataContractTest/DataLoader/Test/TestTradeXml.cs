using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace DataContractTest.DataLoader.Test
{
    [TestClass]
    public class TestTradeXml
    {
        [TestMethod]
        public void TradeXml()
        {
            var obj = TradeGenerator.NewSwap();

            var serializer = new DataContractSerializer(obj.GetType());
            var settings = new XmlWriterSettings();
            settings.Encoding = new System.Text.UTF8Encoding(false);

            var sw = new StringWriter();
            using (var xw = XmlWriter.Create(sw))
            {
                serializer.WriteObject(xw, obj);
            }

            Console.WriteLine(sw.ToString());

            var rw = XmlReader.Create(new StringReader(sw.ToString()));
            var trade = (Trade)serializer.ReadObject(rw);

            Assert.AreEqual(obj.Legs[0].Cashflows[0].PaymentDate, trade.Legs[0].Cashflows[0].PaymentDate);
            Assert.AreEqual(obj.Legs[1].Cashflows[1].StartDate, trade.Legs[1].Cashflows[1].StartDate);
        }
    }
}
