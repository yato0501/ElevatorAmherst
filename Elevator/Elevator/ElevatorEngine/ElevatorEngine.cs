using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Elevator.Constants;
using static Elevator.Constants.Constants;

namespace Elevator.ElevatorEngine
{
	public class ElevatorEngine : IElevatorEngine
	{
		private List<int> _floorQueue;
		
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

			Thread thread = new Thread(new ThreadStart(ElevatorSimulator));
			thread.Start();
		}

		private void ElevatorSimulator()
		{
			while (true)
			{
				if (_currentState == ElevatorState.Stopped)
				{
					if (_floorQueue.Count > 0)
					{
						if (_floorQueue.Contains(_currentFloor))
						{
							OpenDoor();
							CloseDoor();
						}
						_currentState = GetDirection();
					}
				}
				else if (_currentState == ElevatorState.Up)
				{
					GoUp();
					if (_floorQueue.Contains(_currentFloor))
					{
						_currentState = ElevatorState.Stopped;
					}
				}
				else if (_currentState == ElevatorState.Down)
				{
					GoDown();
					if (_floorQueue.Contains(_currentFloor))
					{
						_currentState = ElevatorState.Stopped;
					}
				}
			}
		}

		public void AddToQueue(int floor)
		{
			_floorQueue.Add(floor);
		}

		public void CloseDoor()
		{
			if (_currentState == ElevatorState.Stopped)
			{
				Console.WriteLine("door closing or already closed on floor " + _currentFloor);
				Thread.Sleep(2000);
			}
		}

		public void OpenDoor()
		{
			if (_currentState == ElevatorState.Stopped)
			{
				//remove all queue of current floor from list
				_floorQueue.RemoveAll(x => x == _currentFloor);
				Console.WriteLine("door opening or already opened on floor " + _currentFloor);
				Thread.Sleep(2000);
			}
		}

		public void GoUp()
		{
			_currentState = ElevatorState.Up;
			
			if (_currentFloor < _maxFloor)
			{
				_currentFloor++;
				Thread.Sleep(1000);
			}
			Console.WriteLine("On Floor " + _currentFloor);
		}

		public void GoDown()
		{
			_currentState = ElevatorState.Down;
			
			if (_currentFloor > _minFloor)
			{
				_currentFloor--;
				Thread.Sleep(1000);
			}
			Console.WriteLine("On Floor " + _currentFloor);
		}

		public ElevatorState GetDirection()
		{
			if (_floorQueue.Count == 0 || _currentFloor == _floorQueue[0])
			{
				return ElevatorState.Stopped;
			}
			else if (_currentFloor > _floorQueue[0])
			{
				return ElevatorState.Down;
			}
			else
			{
				return ElevatorState.Up;
			}
		}
	}
}
