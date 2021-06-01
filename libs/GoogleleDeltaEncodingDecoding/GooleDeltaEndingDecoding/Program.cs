using GooleDeltaEndingDecoding;
using System;
using System.Collections.Generic;

//https://stackoverflow.com/questions/3852268/c-sharp-implementation-of-googles-encoded-polyline-algorithm
Console.WriteLine("RUN DELTA ENCODING/DECODING");


Console.WriteLine("ENCODING");
List<Location> points = new List<Location>();
points.Add(new Location() { Latitude = 48.06592, Longitude = 11.62234 });
points.Add(new Location() { Latitude = 48.05616, Longitude = 11.62200 });
points.Add(new Location() { Latitude = 48.04916, Longitude = 11.60380 });

var deltaencoding = GooglePolylineConverter.Encode(points);
Console.WriteLine($"{deltaencoding}");

Console.WriteLine("DECODING");
var coord = GooglePolylineConverter.Decode(deltaencoding);

foreach (var c in coord)
    Console.WriteLine($"latitude: {c.Latitude}, longitude: {c.Latitude}");
