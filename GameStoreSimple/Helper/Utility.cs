using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MVC.Helper
{
    public static class Utility
    {
        /// <summary>
        /// given a display name, return a property info
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayName">display name</param>
        /// <returns></returns>
        public static PropertyInfo GetProperty<T>(string displayName)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();
            PropertyInfo propInfo = null;
            foreach (var prop in properties)
            {
                string name = null;
                var attr = prop.GetCustomAttribute<DisplayNameAttribute>(false);
                if (attr == null)
                {
                    name = prop.Name;
                }
                else
                {
                    name = attr.DisplayName;
                }

                if (name?.ToLowerInvariant() == displayName?.ToLowerInvariant())
                {
                    propInfo = prop;
                    break;
                }
            }
            return propInfo;
        }
    }
}
