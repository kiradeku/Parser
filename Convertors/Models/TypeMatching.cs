using System.Collections.Generic;
using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    [XmlRoot(ElementName = MoodleDefaultSettings.XmlArrayTagItemName)]
    public class TypeMatching : Question
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementShuffleAnswers)]
        public string QuestionShuffleAnswer { get; set; } 

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementCorrectFeedback)]
        public QuestionCorrectFeedback QuestionCorrectFeedback { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementPartiallyCorrectFeedback)]
        public QuestionPartiallyCorrectFeedback QuestionPartiallyCorrectFeedback { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementIncorrectFeedback)]
        public QuestionIncorrectFeedback QuestionIncorrectFeedback { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementShowNumCorrect)]
        public string QuestionShownumcorrect { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementSubQuestion)]
        public List<QuestionSubQuestion> QuestionSubQuestions { get; set; }
    }

}
