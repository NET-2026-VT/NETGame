using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleConsoleGame.GameWorld;
using SimpleConsoleGame.LimitedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleGame;

internal class SetUp
{
    public void SetUpGame()
    {
        var host = Host.CreateDefaultBuilder()
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
    }
}
