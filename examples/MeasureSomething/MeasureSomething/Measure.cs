using System;
using System.Diagnostics;

namespace MeasureSomething
{
    public static class Measure
    {
        public static void MeasureTime(Action a)
        {
            var watch = Stopwatch.StartNew();
            a();
            watch.Start();
            Console.WriteLine($">> measure time: {watch.Elapsed}");
        }

        public static int MeasureTimeFunc(Func<int> f)
        {
            var watch = Stopwatch.StartNew();
            var result = f();
            watch.Start();
            Console.WriteLine($">> measure time: {watch.Elapsed}");
            return result;
        }

        public static string MeasureTimeFuncTo(Func<int, string> f, int to)
        {
            var watch = Stopwatch.StartNew();
            string result = f(to);
            watch.Start();
            Console.WriteLine(string.Format(" -- messure time {0:mm\\:ss}", watch.Elapsed));
            return result;
        }
    }
}
