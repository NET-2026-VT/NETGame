using SimpleConsoleGame;

//Use when multiple benchmarks
//BenchmarkSwitcher.FromTypes(
//[
//    typeof(InventoryBenchMarks),
//]).Run(args);


#if BENCHMARK
using SimpleConsoleGame.BenchMarks;
using BenchmarkDotNet.Running;
BenchmarkRunner.Run<InventoryBenchMarks>();
#else

new SetUp().SetUpGame();

Console.WriteLine("Game Over");

#endif

