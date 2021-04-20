using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    public abstract class PoorEntity : ITypeAttribute
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementIdNumber)]
        public string IdNumber { get; set; }

        [XmlAttribute(AttributeName = MoodleDefaultSettings.XmlAttributeType)]
        public string Type { get; set; }
    }
}
