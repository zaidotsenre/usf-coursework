//*********************************************************
//  Rainfall.java       
//
//  This program asks the user to enter rainfall amounts 
//  for the year. It then computes the total rainfall
//  the average rainfall, and reports the months with the 
//  highest and lowest amount of rainfall.
//
//  I pledge my Honor that I have not cheated, and will not cheat, on this assignment. 
//  Ernesto Diaz
//*********************************************************

import java.util.Scanner;
import java.text.DecimalFormat;

public class Rainfall
{
   public static void main(String [] args)
   {
      // Declare constant to store size of both arrays
      final int NUM_MONTH = 12;     
     

Scanner scan = new Scanner(System.in);
      
      // Declare array to store the rainfall data
      double [] rain = new double [NUM_MONTH];  
   
      // Declare array to store the name of each month
      // Use an initialization list here
      String [] month = {"January", "February", 
      "March", "April", "May", "June", "July",
      "August", "September", "October", "November", "December"};
      
      // Get the rainfall for each month. 
      for (int i = 0; i < NUM_MONTH; i++)
      {
         System.out.print("Enter the rainfall (in inches) for "
            + month[i] + ": ");
         rain[i] = scan.nextDouble();
         
         // Validate the input
         while (rain[i]<0)
         {
         
            System.out.println("Values must be 0 of more.");
            System.out.print("Re-enter the rainfall for " + month[i] + ": ");
            rain[i] = scan.nextDouble();

         }
         
      }
   
      // Calculate the running sum
      double total = 0;
      for (int i = 0; i < NUM_MONTH; i++)
         total += rain[i];
      
      // Format output to 2 decimal places
      DecimalFormat fmt = new DecimalFormat("0.##"); 
      
      // Display the total rainfall
      System.out.println("The total rainfall for the year is " + fmt.format(total) + " inches.");
                         
      // Calculate the average
      double average;
      average = total/NUM_MONTH;
 
      
      // Display the average 
      System.out.println("The average for the year is " + fmt.format(average) + " inches.");
                         
      // Now determine the largest amount of rainfall
      double largest = rain[0];   

      int index = 0;
      
      for (int i = 1; i < NUM_MONTH; i++)                  
      {
         if (rain[i] > largest)
         {
            largest = rain[i];
            index = i;
         }
      }
                                  
      // Display the largest amount of rainfall and the
      // month when it occured
      System.out.println("The largest amount of rainfall for the year is " + 
         largest + " inches in " + month[index] + ".");

      // Now determine the smallest amount of rainfall
      double smallest = rain[0];   // holds smallest value
                  
      index = 0;  // reset index
      
      for (int i = 1; i < NUM_MONTH; i++)                  
      {
         if (rain[i] < smallest)
         {
            smallest = rain[i];
            index = i;
         }
      }

      // Display the smallest amount of rainfall and the
      // month when it occured
      System.out.println("The smallest amount of rainfall for the year is " + 
         smallest + " inches in " + month[index] + ".");

   }
}