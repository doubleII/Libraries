using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Extensions
{
    public static class Utility
    {
        
         public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source is null)
                return true;

            return !source.Any();
        }
        
        private string ByteArrayToString(byte[] arr)
        {
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding("ISO-8859-1");
            return enc.GetString(arr);
        }

        public static bool IsSingleEntry(DataTable table)
        {
            if (table.Rows.Count == 0)
            {
                Console.WriteLine($"Database error. No etry found!");
                MessageBox.Show($"Anzahl der Einträge {table.Rows.Count}. Die Datenbank muss gepflegt werden.\nRufen Sie bitte den Administrator.", "Datenbankfehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (table.Rows.Count == 1)
                return true;

            else if (table.Rows.Count > 1)
            {
                MessageBox.Show($"Anzahl der Einträge {table.Rows.Count}. Die Datenbank muss gepflegt werden.\nRufen Sie bitte den Administrator.", "Datenbankfehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                Console.WriteLine($"Database mismatch");
                MessageBox.Show($"Anzahl der Einträge {table.Rows.Count}. Rufen Sie bitte den Administrator!\n Mehr Info finden Sie in der Log-Datei.", "Fehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
		
		/// get time intervall from now in minutes back
		public static long GetTimeDiff(this DateTime time){
			 return Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Minute, DateTime.Now, time);
		}

        /// <summary>
        /// try parse date time
        /// </summary>
        /// <param name="stringDate"></param>
        /// <returns></returns>
        public static DateTime? TryParse(this string stringDate)
        {
            DateTime date;
            return DateTime.TryParse(stringDate, out date) ? date : (DateTime?)null;
        }

        /// <summary>
        /// try parse date time string return HH:mm:ss string
        /// </summary>
        /// <param name="stringDate"></param>
        /// <returns></returns>
        public static string TryParseTime(this string stringDate)
        {
            DateTime date;
            if ((DateTime.TryParse(stringDate, out date) ? date : (DateTime?)null) is null)
                return null;
            DateTime.TryParse(stringDate, out date);
            return date.ToString("HH:mm:ss");
        }

        /// <summary>
        /// try parse date time string return HHmmss string
        /// </summary>
        /// <param name="stringDate"></param>
        /// <returns></returns>
        public static string TryParseTimeToString(this string stringDate)
        {
            DateTime date;
            if ((DateTime.TryParse(stringDate, out date) ? date : (DateTime?)null) is null)
                return null;
            DateTime.TryParse(stringDate, out date);
            return date.ToString("HHmmss");
        }

        /// <summary>
        /// only numbers
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string OnlyNumbers(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            var t = text;
            if (Regex.IsMatch(t, "[^0-9]"))
            {
                MessageBox.Show("Geben Sie bitte nur Zahlen ein.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t = t.Remove(t.Length - 1);
            }
            return t;
        }

        public static bool HasOnlyNumbers(this string text)
        {
            if(string.IsNullOrEmpty(text))
                return true;
                
            var t = text;
            if (Regex.IsMatch(t, "^[0-9]*$"))
                return true;
            return false;
        }
        
            /// <summary>
        /// https://regexlib.com/Search.aspx?k=phone&AspxAutoDetectCookieSupport=1
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string IsPhoneNumber(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return null;

            var s = source;
            if(!Regex.IsMatch(s, "^(\\(?\\+?[0-9]*\\)?)?[0-9_\\- \\(\\)]*$"))
            {
                MessageBox.Show("Geben Sie eine gültige Telefonnnumer ein. Telefonnummerformat: (+49)(0)20-12341234 | 01012341234 | +49 (0) 1234-1234", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                s = s.Remove(s.Length - 1);
            }
            return s;
        }

        /// <summary>
        /// return string date time yyyMMMdd 000000
        /// </summary>
        /// <param name="strtime"></param>
        /// <returns></returns>
        public static string FormatDateTimeStringToyyyyMMdd(this string strtime)
            => DateTime.Now.ToString("yyyyMMdd") + "000000";

        /// <summary>
        /// return date time from yyyyMMMMddHHmmssMS/MW sommer winter time
        /// </summary>
        /// <param name="strtime"></param>
        /// <returns></returns>
        public static DateTime? ConvertStringTimeToDateTime(this string strtime)
        {
            if (string.IsNullOrEmpty(strtime))
                return null;

            if (DateTime.TryParseExact(strtime.Substring(0, strtime.Length - 2), "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                return result;
            
            return null;
        }

        /// <summary>
        /// return date time from string yyyyMMMMddHHmmss without sommer winter suffix
        /// </summary>
        /// <param name="strtime"></param>
        /// <returns></returns>
        public static DateTime? ConvertStringTimeToDateTime2(this string strtime)
    {
            if (string.IsNullOrEmpty(strtime))
            return null;
                
            if (DateTime.TryParseExact(strtime, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                return result;

            return null;
        }

        /// <summary>
        /// db format with md/ms sommer/winter time datetime to string
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ConvertTimeToDbFormat(this DateTime time)
          => time.ToString("yyyyMMddHHmmss") + (TimeZone.CurrentTimeZone.IsDaylightSavingTime(time) ? "MD" : "MS");

        /// <summary>
        /// db format md/ms sommer/winter time string to stirng
        /// </summary>
        /// <param name="strtime"></param>
        /// <returns></returns>
        public static string ConvertTimeToDbFormat(this string strtime)
        {
            if (DateTime.TryParseExact(strtime, new[] { "HH:mm dd.MM.yyyy", "HH:mm:ss dd.MM.yyyy", "dd.MM.yyyy HH:mm", "dd.MM.yyyy HH:mm:ss", "yyyyMMddHHmmss" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                return result.ToString("yyyyMMddHHmmss") + (TimeZone.CurrentTimeZone.IsDaylightSavingTime(result) ? "MD" : "MS");
            return null;
        }

        public static DateTime FirstDayOfMonth(this DateTime current)
             => current.AddDays(1 - current.Day);

        public static DateTime LastDayOfMonth(this DateTime date)
        {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

            DateTime last = date.FirstDayOfMonth().AddDays(daysInMonth - 1);
            return last;
        }

        public static string ReplaceCommaWithPoint(this string value)
        {
            if(value.Length < 10)
                value = value +"00000";

            value = value.Substring(0, value.IndexOf(",") + 6);
            return value.Replace(",", ".");
        }

        public static bool IsFalseIfEmpty<T>(this T input, Func<T, bool> condition)
        {
            if(condition(input))
                return true;
            return false;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable) 
            => enumerable == null || !enumerable.Any();

        public static string IsNullIfEmpty(this string source)
            => string.IsNullOrEmpty(source) ? null : source;

        public static int RunProcess(this ProcessStartInfo start)
        {
            using (Process process = Process.Start(start))
            {
                process.WaitForExit();
                int exitcode = process.ExitCode;
                return exitcode;
            }
        }
        
        public static uint? TryParseNullable(this string val)
        {
            int outValue;
            return int.TryParse(val, out outValue) ? (uint?)outValue : null;
        }
        
        
        public static string UppercaseFirst(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }
        
        
        
        /// <summary>
        /// Get string value after [first] a.
        /// </summary>
        public static string Before(this string value, string a)
        {
            int posA = value.IndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            return value.Substring(0, posA);
        }
        
        /// <summary>
        /// Get string value between [first] a and [last] b.
        /// </summary>
        public static string Between(this string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }
        
        /// <summary>
        /// Get string value after [last] a.
        /// </summary>
        public static string After(this string value, string a)
        {
            int posA = value.LastIndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }
            return value.Substring(adjustedPosA);
        }
        
        
        /// <summary>
        /// Get string value after [last] a.
        /// </summary>
        public static string AfterFirsIndex(this string value, string a)
        {
            int posA = value.IndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }
            return value.Substring(adjustedPosA);
        }
        
        
        
         /// <summary>
        /// async await for methods thea are called from constructor
        /// </summary>
        /// <param name="task"></param>
        /// <param name="continueOnCapturedContext"></param>
        /// <param name="onException"></param>
        public static async void SafeFireAndForget(this System.Threading.Tasks.Task task, bool continueOnCapturedContext = true, Action<Exception> onException = null)
        {
            try
            {

                await task.ConfigureAwait(continueOnCapturedContext);
            }
            catch (Exception ex) when (onException != null)
            {

                onException(ex);
            }
        }
        
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source is null)
                return true;
            
            return !source.Any();
        }
		
		public static bool IsNotNullOrEmpty<T>(this T input, Func<T, bool> condition)
        {
            Console.WriteLine($">>{input}");

            if (condition(input))
                return false;
            return true;
        }
		
		
		public static StringBuilder addValue<T>(T x, T y, string oldValue, string newValue, StringBuilder result, Func<T, T, bool> condition)
        {
            if (condition(x, y))
                return result.Replace(oldValue, newValue);
            
            if (newValue is "'T'")
                return result.Replace(oldValue, "'F'");

            return result.Replace(oldValue, null);
        }
    }
}
