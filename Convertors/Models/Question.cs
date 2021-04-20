using System.Xml.Serialization;
using Convertors.Moodle;

namespace Convertors.Models
{
    public abstract class Question : PoorEntity
    {
        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementName)]
        public QuestionName QuestionName { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementQuestionText)]
        public QuestionText QuestionText { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementGeneralFeedback)]
        public QuestionGeneralFeedback QuestionGeneralFeedback { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementDefaultGrade)]
        public QuestionDefaultGrade DefaultGrade { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementPenalty)]
        public double Penalty { get; set; }

        [XmlElement(ElementName = MoodleDefaultSettings.XmlElementHidden)]
        public int Hidden { get; set; }
    }
}
