using System;

class CNT4704Lab
{
  public static void Main(string[] myInput)
  {
     int i, sum = 0;
     Console.WriteLine("\nYou entered " + myInput.Length + " numbers:");
     //
     // Problem (1) Something is missing from the header of the 'for' statement. 
	 // Hint: the syntax of for-loop in C# is the same as Java or C or C++.
     //
     for (i = 0; i < myInput.Length; i++) 
     {
		Console.Write(myInput[i] + "  ");
		sum = sum + Int32.Parse(myInput[i]);
     }
     //
     // Problem (2) The sum is not displayed because the WriteLine method in 
	 // the next line prints only a string. You need to include the value of
	 // sum in this method. Hint: Google 'WriteLine C#' for examples of this method.
     //
     Console.WriteLine("\n\nSum of your input numbers = " + sum);
     Console.WriteLine("\nGood Bye!");
  }
}