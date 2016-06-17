using System.Xml;

namespace ExtractDataModelFromXml
{
    public interface IXml2ModelMapper
    {
        dynamic Map(XmlDocument xml);
    }
}
