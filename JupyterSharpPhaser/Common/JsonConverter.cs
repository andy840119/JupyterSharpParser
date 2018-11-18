using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Common
{
    /// <summary>
    /// ref :
    /// https://dotblogs.com.tw/wasichris/2015/02/23/149545
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class JsonConverter<T> : JsonConverter
    {
        // 產生物件實體邏輯(須依實際轉換需求進行實作)
        // objectType: ReadJson中預期的物件實體類別型態
        // jObject: 讀取到的JOSN物件
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanWrite => false;

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
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject 
            T target = Create(objectType, jObject);

            // Populate the object properties 
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            // 在產生物件實體時不會用到
            throw new NotImplementedException();
        }
    }
}
