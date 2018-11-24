using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JupyterSharpPhaser.Web.Extensions
{
    public class SelectListItemHelpers
    {
        /// <summary>
        /// See :
        /// https://stackoverflow.com/a/22546853/4105113
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        public static List<SelectListItem> EnumDropDownList<TEnum>(TEnum selectedValue)
        {
            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var value in values)
            {
                string text = value.ToString();

                var member = typeof(TEnum).GetMember(value.ToString());
                if (member.Any())
                {
                    var customAttributes = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (customAttributes.Any())
                    {
                        text = ((DescriptionAttribute)customAttributes[0]).Description;
                    }
                }

                items.Add(new SelectListItem
                {
                    Text = text,
                    Value = value.ToString(),
                    Selected = (value.Equals(selectedValue))
                });
            }
            return items;
        }
    }
}
