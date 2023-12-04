//
// COP 4365 – Fall 2022
//
// Homework #4: Traffic Study
//
// Description: Contains logic that controls the stoplights.
//
// File name: Program.cs
//
// By: Ernesto Diaz
//
//

using System.Collections.Generic;

namespace Homework4_ClassLibrary
{
    public class StoplightController
    {
        // Private data members
        Dictionary<Direction, StoplightState> stoplights;
        ControllerState state;
        bool emergency;

        // Public properties
        public Dictionary<Direction, StoplightState> Stoplights { get { return stoplights; } }
        public ControllerState State
        {
            get { return state; }
            set 
            {
                state = value;
                if (state > ControllerState.RRRY)
                    state = 0;
                FlipLights(state);
            }
        }
        public bool Emergency { get { return emergency; } }


        // Public methods

        //
        // Method Name: StoplightController
        // Description: A constructor for the class
        public StoplightController()
        {
            stoplights = new Dictionary<Direction, StoplightState>();
            stoplights.Add(Direction.North, StoplightState.Red);
            stoplights.Add(Direction.East, StoplightState.Red);
            stoplights.Add(Direction.South, StoplightState.Red);
            stoplights.Add(Direction.West, StoplightState.Red);

            State = 0;
            emergency = false;
        }

        //
        // Method Name: NextState
        // Description: Sets the light system into it's next corresponding configuration
        public void NextState()
        {
            State++;
        }

        //
        // Method Name: StartEmergencyAlert
        // Description: Sets the system into emergency mode to allow emergency vehicle through
        public void StartEmergencyAlert(Direction dir)
        {
            emergency = true;
            switch (dir)
            {
                case Direction.North:
                    State = ControllerState.GRRR;
                    break;
                case Direction.South:
                    State = ControllerState.RGRR;
                    break;
                case Direction.East:
                    State = ControllerState.RRGR;
                    break;
                case Direction.West:
                    State = ControllerState.RRRG;
                    break;
            }
        }

        //
        // Method Name: StopEmergencyAlert
        // Description: Puts system out of emergency mode
        public void StopEmergencyAlert()
        {
            emergency = false;
        }

        //
        // Method Name: IsGreen
        // Description: Checks if the indicated light is green
        public bool IsGreen(Direction dir)
        {
            return stoplights[dir] == StoplightState.Green ? true : false;
        }


        // Private methods

        //
        // Method Name: FlipLIghts
        // Description: Sets the current state of individual lights based on the state of the system
        void FlipLights(ControllerState controllerState)
        {
            switch (controllerState)
            {
                case ControllerState.GRRR:
                    stoplights[Direction.North] = StoplightState.Green;
                    stoplights[Direction.South] = StoplightState.Red;
                    stoplights[Direction.East] = StoplightState.Red;
                    stoplights[Direction.West] = StoplightState.Red;
                    break;
                case ControllerState.GGRR:
                    stoplights[Direction.North] = StoplightState.Green;
                    stoplights[Direction.South] = StoplightState.Green;
                    stoplights[Direction.East] = StoplightState.Red;
                    stoplights[Direction.West] = StoplightState.Red;
                    break;
                case ControllerState.YGRR:
                    stoplights[Direction.North] = StoplightState.Yellow;
                    stoplights[Direction.South] = StoplightState.Green;
                    stoplights[Direction.East] = StoplightState.Red;
                    stoplights[Direction.West] = StoplightState.Red;
                    break;
                case ControllerState.RGRR:
                    stoplights[Direction.North] = StoplightState.Red;
                    stoplights[Direction.South] = StoplightState.Green;
                    stoplights[Direction.East] = StoplightState.Red;
                    stoplights[Direction.West] = StoplightState.Red;
                    break;
                case ControllerState.RYRR:
                    stoplights[Direction.North] = StoplightState.Red;
                    stoplights[Direction.South] = StoplightState.Yellow;
                    stoplights[Direction.East] = StoplightState.Red;
                    stoplights[Direction.West] = StoplightState.Red;
                    break;
                case ControllerState.RRGR:
                    stoplights[Direction.North] = StoplightState.Red;
                    stoplights[Direction.South] = StoplightState.Red;
                    stoplights[Direction.East] = StoplightState.Green;
                    stoplights[Direction.West] = StoplightState.Red;
                    break;
                case ControllerState.RRGG:
                    stoplights[Direction.North] = StoplightState.Red;
                    stoplights[Direction.South] = StoplightState.Red;
                    stoplights[Direction.East] = StoplightState.Green;
                    stoplights[Direction.West] = StoplightState.Green;
                    break;
                case ControllerState.RRYG:
                    stoplights[Direction.North] = StoplightState.Red;
                    stoplights[Direction.South] = StoplightState.Red;
                    stoplights[Direction.East] = StoplightState.Yellow;
                    stoplights[Direction.West] = StoplightState.Green;
                    break;
                case ControllerState.RRRG:
                    stoplights[Direction.North] = StoplightState.Red;
                    stoplights[Direction.South] = StoplightState.Red;
                    stoplights[Direction.East] = StoplightState.Red;
                    stoplights[Direction.West] = StoplightState.Green;
                    break;
                case ControllerState.RRRY:
                    stoplights[Direction.North] = StoplightState.Red;
                    stoplights[Direction.South] = StoplightState.Red;
                    stoplights[Direction.East] = StoplightState.Red;
                    stoplights[Direction.West] = StoplightState.Yellow;
                    break;


            }
        }
    }
}
