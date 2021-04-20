using System;
using System.Runtime.Serialization;

namespace Convertors.Moodle
{
    public class MoodleConvertorException : Exception
    {
        public MoodleConvertorException() { }
        public MoodleConvertorException(string message) : base(message) { }
        public MoodleConvertorException(string message, Exception innerException) : base(message, innerException) { }
        protected MoodleConvertorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
