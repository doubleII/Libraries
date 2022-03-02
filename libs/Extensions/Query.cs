using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class Query
    {
         public static string addProjection(this string source) => string.IsNullOrEmpty(source) ? null : $"'{source}'";
        // public static string addProjection(this string source)
        // {
            // if (string.IsNullOrEmpty(source))
                // return null;
            // return $"'{source}'";
        // }

        public static string addProjection(this string[] source, string item) => (source.Length == 0) ? null : $"'{item}'";
        // public static string addProjection(this string[] source, string item)
        // {
            // if (source.Length == 0)
                // return null;
            // return $"'{item}'";
        // }

        public static string addCondition(this string str, bool condition, string statement) => 
            (!condition) ? str : str + (!str.Contains(" WHERE ") ? " WHERE " : " ") + statement;
        // public static string addCondition(this string str, bool condition, string statement)
        // {
            // if (!condition)
                // return str;

            // return str + (!str.Contains(" WHERE ") ? " WHERE " : " ") + statement;
        // }

        public static string cleanProjection(this string source)
        {
            if (!source.Contains("null,") || !source.Contains("null"))
                return source;
            if (source.Contains("null,"))
                source = $"{source.Replace("null,", "")}";
            if (source.Contains("null"))
                source = $"{source.Replace("null", "")}".Trim();
            if (source.EndsWith(","))
                source = source.Substring(0, source.Length - 1);
            return source;
        }

        public static string cleanCondition(this string str)
            => (!str.Contains(" WHERE ")) ? str : str.Replace(" WHERE AND ", " WHERE ").Replace(" WHERE OR ", " WHERE ");
        
        // public static string cleanCondition(this string str)
        // {
            // if (!str.Contains(" WHERE "))
                // return str;

            // return str.Replace(" WHERE AND ", " WHERE ").Replace(" WHERE OR ", " WHERE ");
        // }
        public static string ReplaceWhereAndWithWhereOrCondition(this string str)
        {
            if (!str.Contains(" WHERE "))
                return str;

            return str.Replace(" WHERE AND ", " AND ").Replace(" WHERE OR ", " OR ");
        }

        /// <summary>
        /// return null or 'string'
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string IsNullIfEmpty(this string s) => string.IsNullOrEmpty(s) ? "null" : $"'{s}'";

        /// <summary>
        /// return null or "string"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string IsNullIfEmptyType2(this string s) => string.IsNullOrEmpty(s) ? "null" : $"\"{s}\"";

        public static string IsNullIfEmpty<T>(this T[] array, string output) where T : class
        {
            return (array == null || array.Length == 0) ? null : output;
        }

        public static bool IsFalseIfEmpty<T>(this T[] array) where T : class
        {
            return (array == null || array.Length == 0) ? false : true;
        }

        public static bool IsTrueIfEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return true;

            return source.Any() == false;
        }

        public static bool IsFalseIfEmpty(this string s) => string.IsNullOrEmpty(s) ? false : true;

        public static string JoinArray(this string[] source)
        {
            if (source.IsTrueIfEmpty())
                return null;
            return $"'{string.Join("','", source)}'";
        }
        public static bool IsOneItem<T>(this List<T> source)
        {
            if (source.Count == 1)
                return true;
            return false;
        }

        public static string cleanSql(this string sql, string searchString)
        {
            int index = sql.LastIndexOf(searchString);
            if (index != -1)
                sql = sql.Substring(0, index);
            return sql;
        }
        
         /// <summary>
        /// convert db value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ConvertFromDBVal<T>(this object obj)
        {
            // returns the default value for the type or the object
            return (obj == null || obj == DBNull.Value) ? default(T) : (T)obj;
        }
    }
}
