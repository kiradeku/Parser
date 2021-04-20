using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    public class QuestionName
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementText)]
        public string Text { get; set; }
    }
}
