using System;
using System.Collections.Generic;
using System.Text;
using Elevator.Constants;
using static Elevator.Constants.Constants;

namespace Elevator.ElevatorEngine
{
	public class ElevatorEngine : IElevatorEngine
	{
		private IList<int> _floorQueue;
		
		private ElevatorState _currentState;

		private int _currentFloor;
		private int _minFloor;
		private int _maxFloor;

		public ElevatorEngine()
		{
			_currentState = ElevatorState.Stopped;
			_floorQueue = new List<int>();
			_currentFloor = 1;
			_minFloor = 1;
			_maxFloor = 5;
		}

		public void AddToQueue(int floor)
		{
			_floorQueue.Add(floor);
		}

		public void CloseDoor()
		{
			if (_currentState == ElevatorState.Stopped)
			{
				Console.WriteLine("door closing or already closed");
			}
		}

		public void OpenDoor()
		{
			if (_currentState == ElevatorState.Stopped)
			{
				Console.WriteLine("door opening or already opened");
			}
		}

		public void GoUp()
		{
			_currentState = ElevatorState.Up;
			if (_currentFloor < _maxFloor)
			{
				_currentFloor++;
			}
		}

		public void GoDown()
		{
			_currentState = ElevatorState.Down;
			if (_currentFloor > _minFloor)
			{
				_currentFloor--;
			}
		}

		public ElevatorState GetDirection()
		{
			if (_currentFloor > _floorQueue[0])
			{
				return ElevatorState.Down;
			}
			else if (_currentFloor < _floorQueue[0])
			{
				return ElevatorState.Up;
			}
			else
			{
				return ElevatorState.Stopped;
			}
		}
	}
}
