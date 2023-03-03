using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Core.Utils
{

    public class XML_Reader
    {

        private XmlDocument doc;

        public XML_Reader(string pathToXML)
        {
            doc = new XmlDocument();
            doc.Load(pathToXML);
        }

        public string GetTextFromNode(string xpathToNode)
        {
            XmlNode node;
            try
            {
                node = doc.DocumentElement.SelectSingleNode(xpathToNode);
            }
            catch (XmlException)
            {
                throw new ArgumentException("The Node Could Not Be Found");
            }
            return node.InnerText;
        }
        public List<string> GetTextListFromNodes(string xpathToNode)
        {
            XmlNodeList nodes;
            try
            {
                nodes = doc.DocumentElement.SelectNodes(xpathToNode);
            }
            catch (XmlException)
            {
                throw new ArgumentException("The Node Could Not Be Found");
            }
            List<string> list = nodes.Cast<XmlNode>().Select(x => (x.InnerText)).ToList();
            return list;
        }

    }

}