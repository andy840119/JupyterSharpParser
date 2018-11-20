using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JupyterSharpPhaser.Test.Helpers
{
    public class ClassCompareHelper
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
                Type type = self.GetType();

                List<string> ignoreList = new List<string>(ignore);
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo pi in properties)
                {
                    if (!ignoreList.Contains(pi.Name))
                    {
                        object selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                        object toValue = type.GetProperty(pi.Name).GetValue(to, null);

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
                }
                return true;
            }
            return self == to;
        }
    }
}