using BenchmarkDotNet.Running;
using SimpleConsoleGame;
using SimpleConsoleGame.BenchMarks;


#if BENCHMARK
BenchmarkRunner.Run<InventoryBenchMarks>();
#else

new SetUp().SetUpGame();

Console.WriteLine("Game Over");

#endif