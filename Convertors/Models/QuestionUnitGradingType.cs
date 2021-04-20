using System.Xml.Serialization;

namespace Convertors.Models
{
    public class QuestionUnitGradingType
    {
        [XmlText]
        public int UnitGradingType { get; set; }
    }
}
