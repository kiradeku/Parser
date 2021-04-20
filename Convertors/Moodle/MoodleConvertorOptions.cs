using System.Xml;
using System.Xml.Serialization;

namespace Convertors.Moodle
{
    public sealed class MoodleConvertorOptions<TModel> where TModel : class, ITypeAttribute
    {
        public MoodleConvertorOptions()
        {
            UseLowercase = true;
            XmlArrayName = MoodleDefaultSettings.XmlArrayTagName;
            XmlArrayItemName = MoodleDefaultSettings.XmlArrayTagItemName;

            Mapper = new MoodleMapper<TModel>();

            ReaderSettings = new XmlReaderSettings
            {
                Async = true
            };

            WriterSettings = new XmlWriterSettings
            {
                Async = true
            };

            DocumentNamespaces = new XmlSerializerNamespaces();
        }

        public bool UseLowercase { get; set; }
        public string XmlArrayName { get; set; }
        public string XmlArrayItemName { get; set; }

        public MoodleMapper<TModel> Mapper { get; }
        public XmlReaderSettings ReaderSettings { get; }
        public XmlWriterSettings WriterSettings { get; }
        public XmlSerializerNamespaces DocumentNamespaces { get; }
    }
}
