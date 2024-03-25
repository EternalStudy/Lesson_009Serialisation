using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace Lesson_009Serialisation
{
        public class JsonToXml
        {
            public static void Main()
            {
                string json = File.ReadAllText("input.json");
                XmlDocument xmlDoc = ConvertJsonToXml(json);
                xmlDoc.Save("output.xml");
            }
            public static XmlDocument ConvertJsonToXml(string json)
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(XElement));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                XElement root = (XElement)ser.ReadObject(ms);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(root.ToString());
                return xmlDoc;
            }
        }
}
