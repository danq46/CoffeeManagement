using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace CoffeeManagement.Utilities
{
    public static class QueryStringHelper
    {
        public static T GetQueryStringValue<T>(this HttpRequest request, String key, T defaultValue) where T : IConvertible
        {
            var stringValue = String.Empty;
            var value = request.QueryString.ToString();

            if (!String.IsNullOrEmpty(value))
            {
                value.Replace("?", String.Empty);

                var parameters = value.Contains("&") 
                    ? value.Split("&").ToList() 
                    : new List<String>() { value };

                parameters.ForEach(parameter => {
                    var valueKey = parameter.Split("=");
                    if (valueKey[0].ToUpper().Equals(key.ToUpper()))
                        stringValue = valueKey[1].ToString();
                });

                try 
                { 
                    var returnValue = (T)Convert.ChangeType(stringValue, typeof(T), CultureInfo.InvariantCulture);
                    return defaultValue;
                } 
                catch (Exception ex)
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }
    }
}
