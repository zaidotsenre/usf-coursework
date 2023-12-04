//*********************************************************
// TempConv.java 
//
// This program prints a range of converted temperature
// (from Celsius to Fahrenheit) to a text file.
//
// I pledge my Honor that I have not cheated, and will not cheat, on this assignment.
// Ernesto Diaz
//*********************************************************

import java.util.Scanner; // Needed for the Scanner class
import java.io.*;         // Needed for the File class

public class TempConv
{
   public static void main(String[] args) throws IOException
   {
     final int BASE = 32;
     final double CONVERSION_FACTOR = 9.0/5.0;
     
     // Variables for Starting and ending Celsius
     // Temperatures
     int startC, endC;

     // Variable Fahrenheit Temperatures
     double fheit;
     
     // For keyboard input
     Scanner scan = new Scanner(System.in);
     
     // Get starting and ending temperatures
     System.out.print("What is the starting temperature? ");
     startC = scan.nextInt();
     
     System.out.print("What is the ending temperature? ");
     endC = scan.nextInt();
     
     scan.nextLine(); // get newline character [Enter]
   
     // Open the file.
     PrintWriter outfile = new PrintWriter("TempTable.txt"); 

     // Print table header to the file
     outfile.println("Celsius temperature     Farenheit temperature");
 

     // Get data and write to the file
     for (int i = startC; i<endC+1; i++)       
     {
         // Print Celsius Temperature to the file
         outfile.print("        " + i);
         
         // Convert Temperature
         fheit = i*CONVERSION_FACTOR+BASE;
         
         // Print Fahrenheit Temperature to the file
         outfile.println("                   " + fheit);

     }

     // Close the file.
     outfile.close();
     
     // Status message printed
     System.out.println("Results posted to TempTable.txt.");
     
   }
}