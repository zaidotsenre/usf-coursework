//
// COP 4365 – Fall 2022
//
// Homework #2: A Smarter Stoplight Problem
//
// Description: Defines a controller class to track and update the traffic lights.
//
// File name: StoplightController.cs
//
// By: Ernesto Diaz
//
//

namespace SmarterStoplight_ClassLibrary
{
    public class StoplightController
    {
        // Private data members
        Stoplight[] stoplights;
        ControllerState state;
        bool emergency;

        // Public properties
        public Stoplight[] Stoplights { get { return stoplights; } }
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
            stoplights = new Stoplight[]
            {
                new Stoplight("North", StoplightState.Red),
                new Stoplight("South", StoplightState.Red),
                new Stoplight("East", StoplightState.Red),
                new Stoplight("West", StoplightState.Red)
            };
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
        public void StartEmergencyAlert(string direction)
        {
            emergency = true;
            direction = direction.ToLower();
            switch (direction)
            {
                case "north":
                    State = ControllerState.GRRR;
                    break;
                case "south":
                    State = ControllerState.RGRR;
                    break;
                case "east":
                    State = ControllerState.RRGR;
                    break;
                case "west":
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



        // Private methods

        //
        // Method Name: FlipLIghts
        // Description: Sets the current state of individual lights based on the state of the system
        void FlipLights(ControllerState controllerState)
        {
            switch (controllerState)
            {
                case ControllerState.GRRR:
                    stoplights[0].State = StoplightState.Green;
                    stoplights[1].State = StoplightState.Red;
                    stoplights[2].State = StoplightState.Red;
                    stoplights[3].State = StoplightState.Red;
                    break;
                case ControllerState.GGRR:
                    stoplights[0].State = StoplightState.Green;
                    stoplights[1].State = StoplightState.Green;
                    stoplights[2].State = StoplightState.Red;
                    stoplights[3].State = StoplightState.Red;
                    break;
                case ControllerState.YGRR:
                    stoplights[0].State = StoplightState.Yellow;
                    stoplights[1].State = StoplightState.Green;
                    stoplights[2].State = StoplightState.Red;
                    stoplights[3].State = StoplightState.Red;
                    break;
                case ControllerState.RGRR:
                    stoplights[0].State = StoplightState.Red;
                    stoplights[1].State = StoplightState.Green;
                    stoplights[2].State = StoplightState.Red;
                    stoplights[3].State = StoplightState.Red;
                    break;
                case ControllerState.RYRR:
                    stoplights[0].State = StoplightState.Red;
                    stoplights[1].State = StoplightState.Yellow;
                    stoplights[2].State = StoplightState.Red;
                    stoplights[3].State = StoplightState.Red;
                    break;
                case ControllerState.RRGR:
                    stoplights[0].State = StoplightState.Red;
                    stoplights[1].State = StoplightState.Red;
                    stoplights[2].State = StoplightState.Green;
                    stoplights[3].State = StoplightState.Red;
                    break;
                case ControllerState.RRGG:
                    stoplights[0].State = StoplightState.Red;
                    stoplights[1].State = StoplightState.Red;
                    stoplights[2].State = StoplightState.Green;
                    stoplights[3].State = StoplightState.Green;
                    break;
                case ControllerState.RRYG:
                    stoplights[0].State = StoplightState.Red;
                    stoplights[1].State = StoplightState.Red;
                    stoplights[2].State = StoplightState.Yellow;
                    stoplights[3].State = StoplightState.Green;
                    break;
                case ControllerState.RRRG:
                    stoplights[0].State = StoplightState.Red;
                    stoplights[1].State = StoplightState.Red;
                    stoplights[2].State = StoplightState.Red;
                    stoplights[3].State = StoplightState.Green;
                    break;
                case ControllerState.RRRY:
                    stoplights[0].State = StoplightState.Red;
                    stoplights[1].State = StoplightState.Red;
                    stoplights[2].State = StoplightState.Red;
                    stoplights[3].State = StoplightState.Yellow;
                    break;


            }
        }
    }
}
