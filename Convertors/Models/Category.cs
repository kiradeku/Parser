using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    [XmlRoot(ElementName = MoodleDefaultSettings.XmlArrayTagItemName)]
    public class Category : PoorEntity
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementCategory)]
        public QuestionCategory QuestionCategory { get; set; }
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementInfo)]
        public QuestionInfo QuestionInfo { get; set; }
    }
}
