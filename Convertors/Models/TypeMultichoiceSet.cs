using System.Collections.Generic;
using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    [XmlRoot(ElementName = MoodleDefaultSettings.XmlArrayTagItemName)]
    public class TypeMultichoiceSet : Question
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementShuffleAnswers)]
        public string QuestionShuffleAnswerd { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementCorrectFeedback)]
        public QuestionCorrectFeedback QuestionCorrectFeedback { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementIncorrectFeedback)]
        public QuestionIncorrectFeedback QuestionIncorrectFeedback { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementAnswer)]
        public List<QuestionAnswer> QuestionAnswers { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementAnswerNumbering)]
        public string QuestionAnswerNumbering { get; set; }
    }
}
