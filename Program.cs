// See https://aka.ms/new-console-template for more information
using BenchmarkCountAny;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<BenchmarkIEnumerableMethods>();
//var summary = BenchmarkRunner.Run<BenchmarkCollectionMethods>();


Console.WriteLine(summary);
Console.ReadLine();