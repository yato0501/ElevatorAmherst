using Elevator.ElevatorEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator.OutsideElevator
{
	class Floor2 : BaseCallElevator
	{
		public Floor2(IElevatorEngine elevatorEngine)
			: base(elevatorEngine)
		{ }
		public override int Floor
		{
			get { return 2; }
		}
	}
}
