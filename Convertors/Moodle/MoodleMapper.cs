using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Convertors.Moodle
{
    public sealed class MoodleMapper<TModel> : IEnumerable<KeyValuePair<string, Type>> where TModel : class, ITypeAttribute
    {
        private readonly Dictionary<string, Type> _mapping;

        public MoodleMapper()
        {
            _mapping = new Dictionary<string, Type>();
        }

        internal bool CreateSerializer(string name, out XmlSerializer serializer)
        {
            if (name is not null)
            {
                if (_mapping.TryGetValue(name, out Type type))
                {
                    serializer = new(type);
                    return true;
                }
            }

            serializer = default;
            return false;
        }

        public bool Map<TMap>(string name) where TMap : TModel
        {
            if (name is not null)
            {
                return _mapping.TryAdd(name, typeof(TMap));
            }

            return false;
        }

        public bool Unmap(string name)
        {
            if (name is not null)
            {
                return _mapping.Remove(name);
            }

            return false;
        }

        public IEnumerator<KeyValuePair<string, Type>> GetEnumerator()
        {
            return _mapping.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
