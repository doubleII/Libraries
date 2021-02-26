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
    }
}
