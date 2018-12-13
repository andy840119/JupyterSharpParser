using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace JupyterSharpParser.Test.Helpers
{
    public class CompareHelper
    {
        /// <summary>
        /// See :
        /// https://stackoverflow.com/a/844855/4105113
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="to"></param>
        /// <param name="ignore"></param>
        /// <returns></returns>
        public static bool PublicInstancePropertiesEqual<T>(T self, T to, params string[] ignore) where T : class
        {
            if (self != null && to != null)
            {
                var type = self.GetType();

                var ignoreList = new List<string>(ignore);
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var pi in properties)
                    if (!ignoreList.Contains(pi.Name))
                    {
                        var selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                        var toValue = type.GetProperty(pi.Name).GetValue(to, null);

                        if (selfValue == null)
                            return selfValue == null && toValue == null;

                        var selfValueType = selfValue.GetType();
                        if (selfValueType.IsClass && selfValueType != typeof(string))
                        {
                            if (PublicInstancePropertiesEqual(selfValue, toValue, ignore) == false)
                                return false;
                        }
                        else if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                        {
                            return false;
                        }
                    }

                return true;
            }

            return self == to;
        }

        public static bool CompareWithJsonFormat<T>(T self, T to) where T : class
        {
            var selfString = JsonConvert.SerializeObject(self);
            var toString = JsonConvert.SerializeObject(to);

            return selfString == toString;
        }
    }
}