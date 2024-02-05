using System;
using Microsoft.Extensions.DependencyInjection;
using MontyHall.Service.Interfaces;
using MontyHall.Service.Models;
using MontyHall.Service.Repositories;

namespace MontyHall.ConsoleApp
{
    class Program
    {
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the number of simulations of the game you want to create");

                int numberOfSimulators = GetNumberOfSimulators();

                Console.WriteLine("Do you want to switch doors? Enter yes or no");

                bool isSwitch = GetSwitchStrategy();

                ConfigureServices();

                var engine = serviceProvider.GetService<IGameRepository>();
                engine.Init(new GameModel { Tries = numberOfSimulators, Switch = isSwitch });

                var player = serviceProvider.GetService<IPlayerRepository>();
                player.Init(engine);

                //Todo: For the large number of runs , kindly make the method async.
                player.AutoPlay(shouldChangeChoice: isSwitch);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Todo: Implememnt Logging for exception loggings instead of console lines.
            }

        }

        private static int GetNumberOfSimulators()
        {
            var numberOfSimulatorsString = Console.ReadLine().ToString();
            Int32.TryParse(numberOfSimulatorsString, out int numberOfSimulators);
            if (!(numberOfSimulators > 0))
            {
                Console.WriteLine("Kindly enter proper number for simulations greater than 0");
                return GetNumberOfSimulators();
            }

            return numberOfSimulators;
        }

        private static bool GetSwitchStrategy()
        {
            bool isSwitch = false;
            switch (Console.ReadLine().ToLower())
            {
                case "yes":
                    isSwitch = true;
                    break;
                case "no":
                    isSwitch = false;
                    break;
                default:
                    Console.WriteLine("Please Enter yes or no");
                    GetSwitchStrategy();
                    break;
            }

            return isSwitch;
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();

            serviceProvider = services.BuildServiceProvider();
        }
    }
}
