//
// COP 4365 – Fall 2022
//
// Homework #4: Traffic Study
//
// Description: A class to create car objects that store the info of each individual car.
//
// File name: Program.cs
//
// By: Ernesto Diaz
//
//

namespace Homework4_ClassLibrary
{
    public class Car
    {
        int sequenceNumber;
        int arrivalTime;
        int exitTime;
        Direction direction; 

        public int SequenceNumber { get { return sequenceNumber; } }
        public int ArrivalTime { get { return arrivalTime; } }
        public int ExitTime { get { return exitTime; } set { exitTime = value; } }
        public Direction Direction { get { return direction; }}

        //
        // Method Name: Car
        // Description: Constructor for car class
        public Car (int sequenceNumber, int arrivalTime, Direction direction)
        {
            this.sequenceNumber = sequenceNumber;
            this.arrivalTime = arrivalTime;
            this.direction = direction;
        }
    }
}
