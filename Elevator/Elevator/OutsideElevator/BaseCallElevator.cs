using Elevator.ElevatorEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator.OutsideElevator
{
	public abstract class BaseCallElevator : ICallElevator
	{
		protected IElevatorEngine _elevatorEngine;
		public BaseCallElevator(IElevatorEngine elevatorEngine)
		{
			_elevatorEngine = elevatorEngine;
		}
		public abstract int Floor { get; }

		public virtual void PushButton()
		{
			_elevatorEngine.AddToQueue(Floor);
		}
	}
}
