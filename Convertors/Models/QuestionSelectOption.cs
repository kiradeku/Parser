using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    public class QuestionSelectOption
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementText)]
        public string Text { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementGroup)]
        public int Group { get; set; }
    }
}
