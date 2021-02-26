using Intergraph.IPS.Germany.CommandHandler;
using Intergraph.IPS.Germany.Logging;
using Intergraph.IPS.Germany.RFL.PatientData;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetId(string sql)
        {
            var input = DbHandler.GetData(sql).Tables[0].Rows[0].ItemArray[0].ToString();
            var pattern = @"[a-zA-Z]+";
            var replacement = "";
            Regex regex = new Regex(pattern);
            var result = regex.Replace(input, replacement);
            int.TryParse(result, out int num);
            return num;
        }

        public static int GetId(cPatientData patient)
        {
            var pattern = @"[a-zA-Z]+";
            var replacement = "";
            Regex regex = new Regex(pattern);
            var result = regex.Replace(patient.ID, replacement);
            int.TryParse(result, out int num);
            return num;
        }

        public static bool IsSingleEntry(DataTable table)
        {
            if (table.Rows.Count == 0)
            {
                GerLog.PrintError($"Database error. No etry found!");
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
                GerLog.PrintError($"Database mismatch");
                MessageBox.Show($"Anzahl der Einträge {table.Rows.Count}. Rufen Sie bitte den Administrator!\n Mehr Info finden Sie in der Log-Datei.", "Fehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
    }
}
