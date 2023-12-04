//
// COP 4365 – Fall 2022
//
// Homework #4: Traffic Study
//
// Description: Contains the entry point and main loop of the console version of the program.
//
// File name: Program.cs
//
// By: Ernesto Diaz
//
//

using System.Diagnostics;
using Homework4_ClassLibrary;

const int runTime = 240; //Program will exit after this many seconds 

// Variables
StoplightController stoplightController = new StoplightController();
Stopwatch stopwatch = Stopwatch.StartNew();
TimeSpan lastSwitch = stopwatch.Elapsed;
TimeSpan lastCarCheck = stopwatch.Elapsed;
List<int> timings = new List<int> { 6, 3, 3, 3, 3 };
List<Car> cars = GetCarData("C:\\Users\\Ernesto\\Downloads\\Homework 4 - Traffic Study\\Homework4_Console\\data.txt");
List<Car> carLine = new List<Car>();
List<Car> pastCars = new List<Car>();
bool headerFlag = true;
int carLineMax = 0;

// Print table heading and intial state of the system

PrintState(stoplightController, stopwatch.Elapsed);

// Main loop
while (true)
{
    // Put cars into line
    foreach (Car car in cars)
    {
        if (stopwatch.Elapsed.TotalSeconds >= car.ArrivalTime)
        {
            carLine.Add(car);
            carLineMax = carLine.Count > carLineMax ? carLine.Count : carLineMax;

            cars.Remove(car);
            break;
        }
    }

    // Make cars go through intersection
    if (stopwatch.Elapsed.TotalSeconds - lastCarCheck.TotalSeconds >= 1)
    {
        foreach(Car car in carLine)
        {
            if (stoplightController.IsGreen(car.Direction))
            {
                car.ExitTime = (int)stopwatch.Elapsed.TotalSeconds;
                pastCars.Add(car);
                carLine.Remove(car);
                PrintCarAlert(car);
                break;
            }
        }
        lastCarCheck = stopwatch.Elapsed;
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

    // Exit program at the set time
    if (stopwatch.Elapsed.TotalSeconds >= runTime)
    {
        Console.WriteLine();
        Console.WriteLine("-------------------------");
        Console.WriteLine("-------------------------");
        Console.WriteLine("FINAL REPORT");
        Console.WriteLine("-------------------------");
        Console.WriteLine("-------------------------");
        Console.WriteLine("Car Count:");
        Console.WriteLine(" North: " + CountCars(pastCars, Direction.North));
        Console.WriteLine(" South: " + CountCars(pastCars, Direction.South));
        Console.WriteLine(" East: " + CountCars(pastCars, Direction.East));
        Console.WriteLine(" West: " + CountCars(pastCars, Direction.West));
        Console.WriteLine("-------------------------");

        Console.WriteLine("Maximum size of line: " + carLineMax);
        Console.WriteLine("-------------------------");

        Console.WriteLine("Average Wait Time:");
        Console.WriteLine(" North: " + AverageWaitTime(pastCars, Direction.North));
        Console.WriteLine(" South: " + AverageWaitTime(pastCars, Direction.South));
        Console.WriteLine(" East: " + AverageWaitTime(pastCars, Direction.East));
        Console.WriteLine(" West: " + AverageWaitTime(pastCars, Direction.West));
        Console.WriteLine("-------------------------");

        break;
    }

}




//
// Method Name: Print State
// Description: Writes current state of the system to the console (formatted)
void PrintState(StoplightController controller, TimeSpan currentTime)
{
    if (headerFlag)
    {
        Console.WriteLine(String.Format("{0,15}{1,15}{2,15}{3,15}{4,15}", "Current Time", "North Light", "South Light", "East Light", "West Light"));
        Console.WriteLine(String.Format("{0,15}{1,15}{2,15}{3,15}{4,15}", "------------", "-----------", "-----------", "----------", "----------"));
        headerFlag = false;
    }

    Console.Write(String.Format("{0,15}", (int)currentTime.TotalSeconds));
    Console.Write(String.Format("{0,15}", controller.Stoplights[Direction.North]));
    Console.Write(String.Format("{0,15}", controller.Stoplights[Direction.South]));
    Console.Write(String.Format("{0,15}", controller.Stoplights[Direction.East]));
    Console.Write(String.Format("{0,15}", controller.Stoplights[Direction.West]));
    Console.WriteLine();
}

//
// Method Name: Print Car Alert
// Description: Prints an alert to the console when a car passes the interception
void PrintCarAlert(Car car)
{
    Console.WriteLine();
    Console.WriteLine("A car has gone through the intersection:");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Sequence Number: " + car.SequenceNumber);
    Console.WriteLine("Arrival Time: " + car.ArrivalTime);
    Console.WriteLine("Exit Time: " + car.ExitTime);
    Console.WriteLine("Total Time Waiting: " + (car.ExitTime - car.ArrivalTime));
    Console.WriteLine();
    headerFlag = true;
}


//
// Method Name: Get Car Data
// Description: Reads car data from file and returns a list of cars
List<Car> GetCarData(string filePath)
{
    TextReader textReader = File.OpenText(filePath);
    string? line;
    List<Car> cars = new List<Car>();
    int sequenceNumber = 0;
    while ((line = textReader.ReadLine()) != null ){
        char direction = line[0];
        int arrivalTime; 
        int.TryParse(line.Substring(1), out arrivalTime);
        Car car = new Car(sequenceNumber, arrivalTime, GetDirectionFromChar(direction));
        cars.Add(car);
        sequenceNumber++;
    }
    return cars;
}


//
// Method Name: Get Direction From Char
// Description: Takes a char as input and attempts to return corresponding direction enum value
Direction GetDirectionFromChar(char directionChar)
{
    switch (directionChar)
    {
        case 'N':
            return Direction.North;
        case 'E':
            return Direction.East;
        case 'S':
            return Direction.South;
        case 'W':
            return Direction.West;
    }

    return Direction.Undefined;
}

//
// Method Name: CountCars
// Description: Counts the number of cars in the given list that come from the given direction
int CountCars(List<Car> cars, Direction dir)
{
    int count = 0;
    foreach (Car car in cars)
    {
        if(car.Direction == dir)
        {
            count++;
        }
    }
    return count;
}

//
// Method Name: AverageWaitTime
// Description: Calculates the average wait time of cars coming from the specified direction
double AverageWaitTime(List<Car> cars, Direction dir)
{
    double sum = 0;
    int count = 0;
    foreach(Car car in cars)
    {
        if(car.Direction == dir)
        {
            sum += (car.ExitTime - car.ArrivalTime);
            count++;
        }
    }
    return sum / count;
}


