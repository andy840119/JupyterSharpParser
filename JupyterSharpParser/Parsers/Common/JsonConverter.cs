using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JupyterSharpParser.Parsers.Common
{
    /// <summary>
    /// ref :
    /// https://dotblogs.com.tw/wasichris/2015/02/23/149545
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class JsonConverter<T> : JsonConverter
    {
        public override bool CanWrite => false;

        /// <summary>
        /// Create T from Type and JObject
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            // Load JObject from stream 
            var jObject = JObject.Load(reader);

            // Create target object based on JObject 
            var target = Create(objectType, jObject);

            // Populate the object properties 
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}