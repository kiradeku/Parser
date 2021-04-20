using System.Collections.Generic;
using System.IO;

namespace Convertors.Moodle
{
    public interface IMoodleConvertorXml<TModel> where TModel : class, ITypeAttribute
    {
        void ToXml(Stream output, IEnumerable<TModel> models);
        IEnumerable<TModel> FromXml(Stream output);
    }
}
