using Elevator.ElevatorEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator.OutsideElevator
{
	class Floor5 : BaseCallElevator
	{
		public Floor5(IElevatorEngine elevatorEngine)
			: base(elevatorEngine)
		{ }
		public override int Floor
		{
			get { return 5; }
		}
	}
}
