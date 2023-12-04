//
// COP 4365 – Fall 2022
//
// Homework #2: A Smarter Stoplight Problem
//
// Description: Contains the entry point and main loop of the console version of the program.
//
// File name: Program.cs
//
// By: Ernesto Diaz
//
//

using System.Diagnostics;
using SmarterStoplight_ClassLibrary;

// Variables
StoplightController stoplightController = new StoplightController();
Stopwatch stopwatch = Stopwatch.StartNew();
TimeSpan lastSwitch = stopwatch.Elapsed;
List<int> timings = new List<int> { 6, 3, 3, 3, 3 };

// Print table heading and intial state of the system
Console.WriteLine(String.Format("{0,15}{1,15}{2,15}{3,15}{4,15}", "Current Time", "North Light", "South Light", "East Light", "West Light"));
Console.WriteLine(String.Format("{0,15}{1,15}{2,15}{3,15}{4,15}", "------------", "-----------", "-----------", "----------", "----------"));
PrintState(stoplightController, stopwatch.Elapsed);

// Main loop
while (true)
{
    // Simulate emergency vehicle
    if ((int)stopwatch.Elapsed.TotalSeconds == 35 && !stoplightController.Emergency)
    {
        string direction = "East";
        stoplightController.StartEmergencyAlert(direction);
        Console.WriteLine("An emergency vehicle has been detected coming from the " + direction.ToUpperInvariant());
        PrintState(stoplightController, stopwatch.Elapsed);
    }
    if ((int)stopwatch.Elapsed.TotalSeconds == 45 && stoplightController.Emergency)
    {
        Console.WriteLine("The emergency vehicle has left the area.");
        stoplightController.StopEmergencyAlert();
    }

    // Stoplight routine
    if ((stopwatch.Elapsed.TotalSeconds - lastSwitch.TotalSeconds > timings[0]) && !stoplightController.Emergency)
    {
        stoplightController.NextState();
        lastSwitch = stopwatch.Elapsed;
        int first = timings[0];
        timings.RemoveAt(0);
        timings.Add(first);

        PrintState(stoplightController, stopwatch.Elapsed);

    }


}


//
// Method Name: Print State
// Description: Writes current state of the system to the console (formatted)
void PrintState(StoplightController controller, TimeSpan currentTime)
{
    Console.Write(String.Format("{0,15}", (int)currentTime.TotalSeconds));
    foreach (Stoplight stoplight in controller.Stoplights)
    {
        Console.Write(String.Format("{0,15}", stoplight.State));

    }
    Console.WriteLine();
}




