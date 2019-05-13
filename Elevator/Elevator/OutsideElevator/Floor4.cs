using Elevator.ElevatorEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator.OutsideElevator
{
	class Floor4 : BaseCallElevator
	{
		public Floor4(IElevatorEngine elevatorEngine)
			: base(elevatorEngine)
		{ }
		public override int Floor
		{
			get { return 4; }
		}
	}
}
