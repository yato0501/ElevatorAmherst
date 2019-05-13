using System;
using System.Collections.Generic;
using System.Text;
using Elevator.ElevatorEngine;
using Elevator.OutsideElevator;

namespace Elevator.InsideElevator
{
	public class ElevatorActions : IElevatorActions
	{
		private readonly IEnumerable<ICallElevator> _buttonList;
		private IElevatorEngine _elevatorEngine;
		public ElevatorActions(IEnumerable<ICallElevator> buttonList, IElevatorEngine elevatorEngine)
		{
			_buttonList = buttonList;
			_elevatorEngine = elevatorEngine;
		}

		//Provides the List of buttons to push for floors
		public IEnumerable<ICallElevator> Buttons {
			get { return _buttonList; }
		}

		public void Close()
		{
			_elevatorEngine.CloseDoor();
		}

		public void Open()
		{
			_elevatorEngine.OpenDoor();
		}
	}
}
