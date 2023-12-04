//
// COP 4365 – Fall 2022
//
// Homework #4: Traffic Study
//
// Description: Enum definitions for use in the program.
//
// File name: Program.cs
//
// By: Ernesto Diaz
//
//

using System;

namespace Homework4_ClassLibrary
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

    public enum Direction
    {
        North,
        East,
        South,
        West,
        Undefined
    }

}
