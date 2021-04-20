using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    [XmlRoot(ElementName = MoodleDefaultSettings.XmlArrayTagItemName)]
    public class TypeNumerical : Question
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementUnitGradingType)]
        public QuestionUnitGradingType QuestionUnitGradingType { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementUnitPenalty)]
        public string QuestionUitPenalty { get; set; }
        
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementShowUnits)]
        public string QuestionShowUnits { get; set; } 

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementUnitsLeft)]
        public string QuestionUnitsLeft { get; set; } 
    }
}
