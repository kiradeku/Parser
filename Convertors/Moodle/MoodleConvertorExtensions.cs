using System;
using System.Text;
using System.Xml;
using Convertors.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Convertors.Moodle
{
    public static class MoodleConvertorExtensions
    {
        public static IServiceCollection AddMoodleConverterXml(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            return services.AddMoodleConverterXml<PoorEntity>(option =>
            {
                option.DocumentNamespaces.Add(string.Empty, string.Empty);
                option.WriterSettings.Indent = true;
                option.WriterSettings.Encoding = Encoding.UTF8;

                option.Mapper.Map<TypeTrueFalse>(MoodleDefaultSettings.TrueFalseType);
                option.Mapper.Map<TypeShortAnswer>(MoodleDefaultSettings.ShortAnswerType);
                option.Mapper.Map<Category>(MoodleDefaultSettings.CategoryType);
                option.Mapper.Map<TypeMatching>(MoodleDefaultSettings.MatchingType);
                option.Mapper.Map<TypeGapSelect>(MoodleDefaultSettings.GapSelectType);
                option.Mapper.Map<TypeCloze>(MoodleDefaultSettings.ClozeType);
                option.Mapper.Map<TypeMultichoice>(MoodleDefaultSettings.MultichoiceType);
                option.Mapper.Map<TypeMultichoiceSet>(MoodleDefaultSettings.MultichoiceSetType);
                option.Mapper.Map<TypeNumerical>(MoodleDefaultSettings.NumericalType);
                option.Mapper.Map<TypeOrdering>(MoodleDefaultSettings.OrderingType);
            }, lifetime);
        }

        public static IServiceCollection AddMoodleConverterXml<TModel>(this IServiceCollection services, Action<MoodleConvertorOptions<TModel>> action = null, ServiceLifetime lifetime = ServiceLifetime.Scoped) where TModel : class, ITypeAttribute
        {
            services.Add(ServiceDescriptor.Describe(typeof(IMoodleConvertorXml<TModel>), typeof(MoodleConvertorXml<TModel>), lifetime));

            if (action is not null)
            {
                services.Configure(action);
            }

            return services;
        }

        internal static string GetTypeAttribute(this XmlReader reader, bool useLowercase)
        {
            if (useLowercase)
            {
                return reader.GetAttribute(nameof(ITypeAttribute.Type).ToLower());
            }

            return reader.GetAttribute(nameof(ITypeAttribute.Type));
        }

        internal static string GetXmlArrayName<TModel>(this MoodleConvertorOptions<TModel> option) where TModel : class, ITypeAttribute
        {
            if (string.IsNullOrWhiteSpace(option.XmlArrayName))
            {
                return MoodleDefaultSettings.XmlArrayTagName;
            }

            return option.XmlArrayName;
        }

        internal static string GetXmlArrayItemName<TModel>(this MoodleConvertorOptions<TModel> option) where TModel : class, ITypeAttribute
        {
            if (string.IsNullOrWhiteSpace(option.XmlArrayItemName))
            {
                return MoodleDefaultSettings.XmlArrayTagItemName;
            }

            return option.XmlArrayItemName;
        }
    }
}
