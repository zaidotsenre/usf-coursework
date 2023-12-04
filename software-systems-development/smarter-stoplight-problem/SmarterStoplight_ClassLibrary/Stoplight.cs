//
// COP 4365 – Fall 2022
//
// Homework #2: A Smarter Stoplight Problem
//
// Description: Defines Stoplight class
//
// File name: Stoplight.cs
//
// By: Ernesto Diaz
//
//


namespace SmarterStoplight_ClassLibrary
{

    public class Stoplight
    {
        string name;
        StoplightState state;


        public string Name { get { return name; } }
        public StoplightState State
        {
            get { return state; }
            set { state = value; }
        }

        //
        // Method Name: Stoplight
        // Description: Constructor 
        public Stoplight(string name, StoplightState state)
        {
            this.name = name;
            this.state = state;

        }

    }

}

