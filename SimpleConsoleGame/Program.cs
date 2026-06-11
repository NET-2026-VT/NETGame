using SimpleConsoleGame;


#if BENCHMARK
using SimpleConsoleGame.BenchMarks;
using BenchmarkDotNet.Running;
BenchmarkRunner.Run<InventoryBenchMarks>();
#else

new SetUp().SetUpGame();

Console.WriteLine("Game Over");

#endif