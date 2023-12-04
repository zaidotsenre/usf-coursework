//
// COP 4365 – Fall 2022
//
// Homework #2: A Smarter Stoplight Problem
//
// Description: Defines enums for use in classes
//
// File name: EnumDefinitions.cs
//
// By: Ernesto Diaz
//
//

namespace SmarterStoplight_ClassLibrary
{
    public enum StoplightState
    {
        Red,
        Yellow,
        Green
    }

    public enum ControllerState
    {
        GRRR,
        GGRR,
        YGRR,
        RGRR,
        RYRR,
        RRGR,
        RRGG,
        RRYG,
        RRRG,
        RRRY
    }

}
