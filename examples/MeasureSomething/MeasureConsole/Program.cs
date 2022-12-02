using System;
using MeasureSomething;


static void CalculateSomething()
{
    for (int i = 0; i < 1000000000; i++) ;
}

static string CalculateSomethingTo(int to)
{
    for (int i = 0; i < to; i++); return "done";
}

static int CalculateSomethingAndReturn()
{
    for (int i = 0; i < 1000000000; i++) ;
    //
    return 42;
}

Measure.MeasureTime(() => CalculateSomething());
Console.WriteLine("-------------\n");
//Console.WriteLine($"result: {Measure.MeasureTimeFunc(() => CalculateSomethingAndReturn())}");
Console.WriteLine($"result: {Measure.MeasureTimeFuncTo((x) => CalculateSomethingTo(100), 100)}");