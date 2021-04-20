using System.Collections.Generic;
using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    [XmlRoot(ElementName = MoodleDefaultSettings.XmlArrayTagItemName)]
    public class TypeOrdering : Question
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementCorrectFeedback)]
        public QuestionCorrectFeedback QuestionCorrectFeedback { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementPartiallyCorrectFeedback)]
        public QuestionPartiallyCorrectFeedback QuestionPartiallyCorrectFeedback { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementIncorrectFeedback)]
        public QuestionIncorrectFeedback QuestionIncorrectFeedback { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementAnswer)]
        public List<QuestionAnswer> QuestionAnswers { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementLayOutType)]
        public string LayOutType { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementSelectType)]
        public string SelectType { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementSelectCount)]
        public string SelectCount { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementGradingType)]
        public string GradingType { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementShowGrading)]
        public string ShowGrading { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementNumberingStyle)]
        public string NumberingStyle { get; set; }
    }
}
