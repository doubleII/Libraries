using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Extensions
{
    public static class PropertyCache<T>
    {
        private static readonly Lazy<IReadOnlyCollection<PropertyInfo>> publicPropertiesLazy
            = new Lazy<IReadOnlyCollection<PropertyInfo>>(() => typeof(T).GetProperties());

        public static IReadOnlyCollection<PropertyInfo> PublicProperties => PropertyCache<T>.publicPropertiesLazy.Value;
    }

    public static class Extensions
    {
        /// <summary>
        /// check proprerty from T if not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<string> IsPropertyNotNull<T>(this T source) 
            => PropertyCache<T>.PublicProperties
                    .Where(prop => prop.GetValue(source) != null).Select(prop => prop.Name).ToList();
        /// <summary>
        /// clear all properties from T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        public static void Clear<T>(this T source)
        {
            if (source is null)
                return;

            PropertyCache<T>.PublicProperties
                           .Where(prop => prop.GetValue(source) != null && prop.CanWrite is true && prop.Name != "ItemSource")
                           .ToList().ForEach(prop => 
                           {
                               if(prop.PropertyType == typeof(bool))
                                    prop.SetValue(source, false);

                               else
                                   prop.SetValue(source, null, null);
                           });
        }

        /// <summary>
        /// clear property by name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="names"></param>
        public static void Clear<T>(this T source, List<string> names)
        {
            if (source is null)
                return;

            PropertyCache<T>.PublicProperties
                           .Where(prop => prop.GetValue(source) != null && prop.CanWrite is true && names.Contains(prop.Name) ? true : false)
                           .ToList().ForEach(prop => 
                           {
                               if (prop.PropertyType == typeof(bool))
                                   prop.SetValue(source, false);

                               else
                                   prop.SetValue(source, null, null);
                           }) ;
        }
        
        
                /// <summary>
        /// enable property if contains name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="names"></param>
        public static void Enable<T>(this T source, string name)
        {
            if (source is null)
                return;

            PropertyCache<T>.PublicProperties
                           .Where(prop => prop.Name.Contains(name) && prop.CanWrite is true ? true : false)
                           .ToList().ForEach(prop =>
                           {
                               if (prop.GetValue(source) is false)
                                   prop.SetValue(source, true);
                           });
        }

        /// <summary>
        /// desable property if contains name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="names"></param>
        public static void Desable<T>(this T source, string name)
        {
            if (source is null)
                return;

            PropertyCache<T>.PublicProperties
                           .Where(prop => prop.Name.Contains(name) && prop.CanWrite is true ? true : false)
                           .ToList().ForEach(prop => 
                           {
                               if(prop.GetValue(source) is true )
                                    prop.SetValue(source, false); 
                           });
        }
        
               /// <summary>
        /// check if empty property if contains name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="names"></param>
        public static bool IsEmpty<T>(this T source, string name)
        {
            bool result = true;
            if (source is null)
                return result;

            PropertyCache<T>.PublicProperties
                           .Where(prop => prop.Name == name)
                           .ToList().ForEach(prop =>
                           {
                               var value = prop.GetValue(source);
                               if (!string.IsNullOrEmpty($"{value}"))
                                   result = false;
                                   
                           });
            return result;
        }
		
		        /// <summary>
        /// check proprerty from T if null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<string> IsPropertyNotNull<T>(this T source)
            => PropertyCache<T>.PublicProperties
                    .Where(prop => prop.GetValue(source) == null).Select(prop => prop.Name).ToList();


    }
}
