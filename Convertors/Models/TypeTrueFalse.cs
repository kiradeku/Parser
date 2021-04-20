using System.Collections.Generic;
using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    [XmlRoot(ElementName = MoodleDefaultSettings.XmlArrayTagItemName)]
    public class TypeTrueFalse : Question
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementAnswer)]
        public List<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
