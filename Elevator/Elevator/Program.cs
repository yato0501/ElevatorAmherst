using Elevator.ElevatorEngine;
using Elevator.InsideElevator;
using Elevator.OutsideElevator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elevator
{
	class Program
	{
		static void Main(string[] args)
		{
			//Register interface that the users see on each floor to call the elevator
			//Register the interface of the functionalities inside the elevator
			//Register the elevatorEngine
			IServiceCollection sc = new ServiceCollection();
			IServiceProvider sp = sc.AddSingleton<IElevatorEngine, ElevatorEngine.ElevatorEngine>()
			.AddSingleton<ICallElevator, Floor1>()
		   .AddSingleton<ICallElevator, Floor2>()
		   .AddSingleton<ICallElevator, Floor3>()
		   .AddSingleton<ICallElevator, Floor4>()
		   .AddSingleton<ICallElevator, Floor5>()
		   .AddSingleton<IElevatorActions, ElevatorActions>()
		   .BuildServiceProvider();


			//Retrieving the instances to test
			var floors = sp.GetServices<ICallElevator>();
			var elevatorActions = sp.GetService<IElevatorActions>();


			PlayScenario(floors, elevatorActions);


		}

		private static void PlayScenario(IEnumerable<ICallElevator> floors, IElevatorActions elevatorActions)
		{
			var floor1 = (Floor1)floors.FirstOrDefault(x => ((BaseCallElevator)x).Floor == 1);
			var floor2 = (Floor2)floors.FirstOrDefault(x => ((BaseCallElevator)x).Floor == 2);
			var floor3 = (Floor3)floors.FirstOrDefault(x => ((BaseCallElevator)x).Floor == 3);
			var floor4 = (Floor4)floors.FirstOrDefault(x => ((BaseCallElevator)x).Floor == 4);
			var floor5 = (Floor5)floors.FirstOrDefault(x => ((BaseCallElevator)x).Floor == 5);



			Console.WriteLine("A Person is on floor 3 calling the elevator");
			floor3.PushButton();

			Console.WriteLine("Pushes Floor 1");
			elevatorActions.Buttons.FirstOrDefault(x => ((BaseCallElevator)x).Floor == 1).PushButton();

			Console.WriteLine("A Person is on floor 2 calling the elevator");
			floor2.PushButton();

			Console.WriteLine("Pushes Floor 5");
			elevatorActions.Buttons.FirstOrDefault(x => ((BaseCallElevator)x).Floor == 5).PushButton();

			Console.WriteLine("End");
		}
	}
}
