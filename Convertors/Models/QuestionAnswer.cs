using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    public class QuestionAnswer
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementText)]
        public string Text { get; set; }
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementFeedback)]
        public AnswerFeedback AnswerFeedback { get; set; }
        [XmlAttribute(MoodleDefaultSettings.XmlAttributeFracton)]
        public string Type { get; set; }

        [XmlAttribute(MoodleDefaultSettings.XmlAttributeFormat)]
        public string Type1 = "moodle_auto_format";
    }
}
