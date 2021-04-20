using System.Xml.Serialization;

namespace Convertors.Models
{
    public class QuestionDefaultGrade
    {
        [XmlText]
        public double DefaultGrade { get; set; }
    }
}
