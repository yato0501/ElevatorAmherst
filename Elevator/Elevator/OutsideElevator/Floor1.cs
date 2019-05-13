using Elevator.ElevatorEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator.OutsideElevator
{
	public class Floor1 : BaseCallElevator
	{
		public Floor1(IElevatorEngine elevatorEngine)
			:base(elevatorEngine)
		{}
		public override int Floor
		{
			get { return 1; }
		}
	}
}
