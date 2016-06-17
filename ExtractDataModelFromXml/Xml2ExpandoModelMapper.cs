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
                .Cast<XmlNode>().Where(node => node.Attributes?["ID"] != null)
                .ToDictionary(
                    node => node.Attributes["ID"].InnerText,
                    node => (object)node.InnerText);

            var model = new ExpandoObject() as IDictionary<string, object>;
            foreach (var element in dataElements)
            {
                model.Add(element);
            }

            return model;
        }
    }
}
