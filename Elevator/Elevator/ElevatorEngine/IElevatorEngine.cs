using System;
using System.Collections.Generic;
using System.Text;
using static Elevator.Constants.Constants;

namespace Elevator.ElevatorEngine
{
	public interface IElevatorEngine
	{
		void AddToQueue(int floor);
		void CloseDoor();
		void OpenDoor();

		void GoUp();

		void GoDown();
		ElevatorState GetDirection();
	}
}
