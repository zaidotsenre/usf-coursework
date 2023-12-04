//
// COP 4365 – Fall 2022
//
// Homework #3: The Chatterbox Light System
//
// Description: Entry point of the program.
//
// File name: Program.cs
//
// By: Ernesto Diaz
//
//

using SmarterStoplight_ClassLibrary;
using System.Diagnostics;

Stoplight northLight = new Stoplight();
Stoplight southLight = new Stoplight();
Stoplight eastLight = new Stoplight();
Stoplight westLight = new Stoplight();

northLight.SetDependent(southLight, true);
southLight.SetDependent(eastLight, false);
eastLight.SetDependent(westLight, true);
westLight.SetDependent(northLight, false);

List<Stoplight> stoplights = new List<Stoplight> { northLight, southLight, eastLight, westLight };

Stopwatch sw = Stopwatch.StartNew();
sw.Start();
TimeSpan lastTime = sw.Elapsed;
bool emergencyMode = false;

Console.WriteLine(String.Format("{0,15}{1,15}{2,15}{3,15}{4,15}", "Current Time", "North Light", "South Light", "East Light", "West Light"));
Console.WriteLine(String.Format("{0,15}{1,15}{2,15}{3,15}{4,15}", "------------", "-----------", "-----------", "----------", "----------"));

northLight.TurnGreen();
PrintState(stoplights, sw.Elapsed);
while (true)
{

    // Simulate emergency vehicle
    if ((int)sw.Elapsed.TotalSeconds == 40 && !emergencyMode)
    {
        emergencyMode = true;
        string direction = "East";
        Console.WriteLine("An emergency vehicle has been detected coming from the " + direction.ToUpperInvariant());
        eastLight.EmergencyAlert();
        PrintState(stoplights, sw.Elapsed);
    }
    if ((int)sw.Elapsed.TotalSeconds == 50 && emergencyMode)
    {
        emergencyMode = false;
        Console.WriteLine("The emergency vehicle has left the area.");
        eastLight.EndEmergencyAlert();
    }

    // Print state of system every three seconds
    if (sw.Elapsed.TotalSeconds - lastTime.TotalSeconds > 3)
    {
        lastTime = sw.Elapsed;
        PrintState(stoplights, sw.Elapsed);
    }
}

//
// Method Name: PrintState
// Description: Prints the current state of the system. 
void PrintState(List<Stoplight> stoplights, TimeSpan currentTime)
{
    Console.Write(String.Format("{0,15}", (int)currentTime.TotalSeconds));
    foreach (Stoplight stoplight in stoplights)
    {
        Console.Write(String.Format("{0,15}", stoplight.State));

    }
    Console.WriteLine();
}