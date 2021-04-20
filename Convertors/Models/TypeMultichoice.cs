using System.Collections.Generic;
using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    [XmlRoot(ElementName = MoodleDefaultSettings.XmlArrayTagItemName)]
    public class TypeMultichoice : Question
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementShuffleAnswers)]
        public string QuestionShuffleAnswerd { get; set; } 

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementCorrectFeedback)]
        public QuestionCorrectFeedback QuestionCorrectFeedback { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementPartiallyCorrectFeedback)]
        public QuestionPartiallyCorrectFeedback QuestionPartiallyCorrectFeedback { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementIncorrectFeedback)]
        public QuestionIncorrectFeedback QuestionIncorrectFeedback { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementShowNumCorrect)]
        public string QuestionShowNumCorrect { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementAnswer)]
        public List<QuestionAnswer> QuestionAnswers { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementSingle)]
        public string QuestionSingle { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementAnswerNumbering)]
        public string QuestionAnswerNumbering { get; set; }
    }
}
