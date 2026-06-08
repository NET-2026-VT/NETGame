using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleConsoleGame;
using SimpleConsoleGame.Extensions;
using SimpleConsoleGame.GameWorld;
using SimpleConsoleGame.LimitedList;


//IConfiguration config = new ConfigurationBuilder()
//                                .SetBasePath(Environment.CurrentDirectory)
//                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                                .Build();

var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices(services =>
               {
                   services.AddSingleton<IConsoleUI, ConsoleUI>();
                   services.AddSingleton<IMap, Map>();
                  // services.AddSingleton<IConfiguration>(config);
                   services.AddSingleton<Game>();
                   services.AddSingleton<ILimitedList<string>>(new MessageLog<string>(6));
                   services.AddSingleton<ILimitedList<Item>>(new LimitedList<Item>(3));
               })
               .UseConsoleLifetime()
               .Build();

host.Services.GetRequiredService<Game>().Run();


//var x = config.GetMapSizeFor("x");
//var y = config.GetMapSizeFor("y");
//var map = new Map(height: y , width: x);
//var ui = new ConsoleUI(map);
//var game = new Game(new ConsoleUI(new Map(new )), map);

//game.Run();

Console.WriteLine("Game Over");