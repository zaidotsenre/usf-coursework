//
// COP 4365 – Fall 2022
//
// Homework #4: Traffic Study
//
// Description: Class that stores the state (green, red, yellow) and direction of a stoplight
//
// File name: Program.cs
//
// By: Ernesto Diaz
//
//


namespace Homework4_ClassLibrary
{

    public class Stoplight
    {
        Direction dir;
        StoplightState state;


        public Direction Dir { get { return dir; } }
        public StoplightState State
        {
            get { return state; }
            set { state = value; }
        }

        //
        // Method Name: Stoplight
        // Description: Constructor 
        public Stoplight(Direction dir, StoplightState state)
        {
            this.dir = dir;
            this.state = state;

        }

    }

}

