using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml;

namespace ExtractDataModelFromXml
{
    public class Xml2ExpandoModelMapper : IXml2ModelMapper
    {
        public dynamic Map(XmlDocument xml)
        {
            var dataElements = xml.GetElementsByTagName("Data")
                .Cast<XmlNode>().Where(node => node.Attributes?["ID"] != null);

            var model = new ExpandoObject() as IDictionary<string, object>;
            foreach (var node in dataElements)
            {
                model[node.Attributes["ID"].InnerText] = node.InnerText;
            }

            return model;
        }
    }
}
