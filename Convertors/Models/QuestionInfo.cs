using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    public class QuestionInfo
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementText)]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = MoodleDefaultSettings.XmlAttributeFormat)]
        public string Type = "html";
    }
}
