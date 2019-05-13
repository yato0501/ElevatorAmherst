using Elevator.OutsideElevator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator.InsideElevator
{
	public interface IElevatorActions
	{
		//Open funtion from within the Elevator
		void Open();

		//Close function from within the Elevator
		void Close();

		//The Elevator knows all the floors
		IEnumerable<ICallElevator> Buttons { get; }
	}
}
