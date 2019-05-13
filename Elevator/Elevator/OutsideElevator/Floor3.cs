using Elevator.ElevatorEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator.OutsideElevator
{
	class Floor3 : BaseCallElevator
	{
		public Floor3(IElevatorEngine elevatorEngine)
			: base(elevatorEngine)
		{ }
		public override int Floor
		{
			get { return 3; }
		}
	}
}
