using System;
using System.Xml;

namespace Core.Utils {

    public class XML_Reader {

        private XmlDocument doc;

        public XML_Reader(string pathToXML) {
            doc = new XmlDocument();
            doc.Load(pathToXML);
        }

        public string GetTextFromNode(string xpathToNode) {
            XmlNode node;
            try {
                node = doc.DocumentElement.SelectSingleNode(xpathToNode);
            }
            catch (XmlException) {
                throw new ArgumentException("The Node Could Not Be Found");
            }
            return node.InnerText;
        }

    }

}