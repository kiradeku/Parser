using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Options;

namespace Convertors.Moodle
{
    internal sealed class MoodleConvertorXml<TModel> : IMoodleConvertorXml<TModel> where TModel : class, ITypeAttribute
    {
        private readonly MoodleConvertorOptions<TModel> _option;

        public MoodleConvertorXml(IOptions<MoodleConvertorOptions<TModel>> option)
        {
            _option = option.Value;
        }

        public void ToXml(Stream output, IEnumerable<TModel> models)
        {
            try
            {
                using XmlWriter writer = XmlWriter.Create(output, _option.WriterSettings);

                writer.WriteStartElement(_option.GetXmlArrayName());

                foreach (TModel model in models)
                {
                    if (_option.Mapper.CreateSerializer(model.Type, out XmlSerializer serializer))
                    {
                        serializer.Serialize(writer, model, _option.DocumentNamespaces);
                    }
                }

                writer.WriteEndElement();
            }
            catch (SystemException error) when (error.InnerException is XmlException innerError)
            {
                throw new MoodleConvertorException("", innerError); //для поользователя, через свой тип исключений
            }
            catch (SystemException error)
            {
                throw new MoodleConvertorException("", error); //для программиста, через свой тип исключений
            }
        }

        public IEnumerable<TModel> FromXml(Stream output)
        {
            List<TModel> models = new List<TModel>();

            try
            {
                using XmlReader reader = XmlReader.Create(output, _option.ReaderSettings);

                while (reader.ReadToFollowing(_option.GetXmlArrayItemName()))
                {
                    if (_option.Mapper.CreateSerializer(reader.GetTypeAttribute(_option.UseLowercase), out XmlSerializer serializer))
                    {
                        models.Add((TModel)serializer.Deserialize(reader));
                    }
                }
            }
            catch (SystemException error) when (error.InnerException is XmlException innerError)
            {
                throw new MoodleConvertorException("", innerError); //для поользователя, через свой тип исключений
            }
            catch (SystemException error)
            {
                throw new MoodleConvertorException("", error); //для программиста, через свой тип исключений
            }

            return models;
        }
    }
}
