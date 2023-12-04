// COP 4931 - IT Software Systems Development
// Instructor - James Anderson
// Student - Ernesto Diaz
// Assignment - AHPA 20: The Missing File

FileStream OpenMyFile(string fileName)
{
    try
    {
        FileStream fileStream = File.Open(fileName, FileMode.Open);
        return fileStream;
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("File was not found. Error detected by the method.");
        throw;
    }
}


string fileName = "Happy News.txt";

try
{
    FileStream fileStream = OpenMyFile(fileName);
}
catch (FileNotFoundException)
{
    Console.WriteLine("File was not found by main program.");
}
