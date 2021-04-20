using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    public class QuestionCorrectFeedback
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementText)]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = MoodleDefaultSettings.XmlAttributeFormat)]
        public string Type = "html";
    }

}
