using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    public class QuestionSubQuestion
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementText)]
        public string Text { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementAnswer)]
        public QuestionAnswer Answer { get; set; }

        [XmlAttribute(AttributeName = MoodleDefaultSettings.XmlAttributeFormat)]
        public string Type = "html";
    }
}
