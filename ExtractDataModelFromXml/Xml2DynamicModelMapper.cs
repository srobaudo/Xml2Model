using System.Linq;
using System.Xml;

namespace ExtractDataModelFromXml
{
    public class Xml2DynamicModelMapper : IXml2ModelMapper
    {
        public dynamic Map(XmlDocument xml)
        {
            var dataElements = xml.GetElementsByTagName("Data")
                .Cast<XmlNode>().Where(node => node.Attributes?["ID"] != null)
                .ToDictionary(
                    node => node.Attributes["ID"].InnerText,
                    node => (object) node.InnerText);

            return new Model(dataElements);
        }
    }
}
