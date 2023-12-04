
/* Variables */
TextReader textReader = File.OpenText("C:\\Users\\Ernesto\\Desktop\\state_data.txt");
Dictionary<string, int> statePopulation = new Dictionary<string, int>();
Dictionary<string, double> percentagePopulation = new Dictionary<string, double>();
Dictionary<string, int> numberOfReps = new Dictionary<string, int>();

const int totalReps = 435;

/* Methods */

// Calculates percentage of total pop that lives in 13 colonies
double percentage13Colonies(Dictionary<string, double> percentages)
{
    List<string> thirteenColonies = new List<string>
    {
        "Virginia", "Massachusetts", "Rhode Island", "Connecticut",
        "New Hampshire", "New York", "New Jersey", "Pennsylvania", "Delaware",
        "Maryland", "North Carolina", "South Carolina", "Georgia"
    };
    double percentage = 0;
    foreach (KeyValuePair<string, double> entry in percentages)
    {
        if (thirteenColonies.Contains(entry.Key))
        {
            percentage += entry.Value;
        }
    }
    return percentage;
}

// Tells us if a California, Texas, Florida, and New York are enough to get a bill passed
bool willItPass()
{
    int reps = numberOfReps["California"] + numberOfReps["Florida"] + numberOfReps["Texas"] + numberOfReps["New York"];
    if (reps > totalReps / 2)
    {
        return true;
    }
    return false;
}


/* Program (entry point)*/

// Read values
string? line;
while ((line = textReader.ReadLine()) != null)
{
    string[]? values;
    string state;
    int population;
    double percentage;
    int representatives;
    
    if(line != null)
    {
        values = line?.Split(";");
    } else
    {
        NullReferenceException nullReference = new NullReferenceException("Line read resulted in null value.");
        throw(nullReference);
    }

    state = values[0];
    int.TryParse(values[1], out population);
    double.TryParse(values[2], out percentage);
    int.TryParse(values[3], out representatives);

    statePopulation.Add(state, population);
    percentagePopulation.Add(state, percentage);
    numberOfReps.Add(state, representatives);

}

Console.WriteLine("- " + (percentage13Colonies(percentagePopulation)/100).ToString("P") + " of the US population lives in the original 13 colonies."); ;
Console.WriteLine("- If California fell into the ocean, we would lose " + percentagePopulation["California"] + "% of the US population.");
Console.WriteLine("- If President Biden needs to get a bill passed and only California, Texas, Florida, " +
    "and New York support it, the bill will " + (willItPass() ? "" : "not ") + "pass the House.");
double flRepsPercentage = (double)numberOfReps["Florida"] / totalReps;
Console.WriteLine("- " + flRepsPercentage.ToString("P") + " of representatives come from Florida.");
int legalStoners = statePopulation["Washington"] + statePopulation["Oregon"] + statePopulation["Colorado"] + statePopulation["Alaska"] ;
Console.WriteLine("- " +  legalStoners.ToString("N0") + " people can legaly use weed.");


