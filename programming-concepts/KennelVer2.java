//*********************************************************
// KennelVer2.java       
//
// This is the driver program for the Dog class
//
// I pledge my Honor that I have not cheated, and will not cheat, on this assignment.
// Ernesto Diaz
//*********************************************************

import java.util.Scanner;

public class KennelVer2
{
   //------------------------------------------------------
   // Creates and exercises some Dog objects.
   //------------------------------------------------------
   public static void main (String[] args)
   {
     // Create objects - test constructor 
     DogVer2 d1 = new DogVer2("Cooper", 1);
     DogVer2 d2 = new DogVer2("Pico", 2);
     DogVer2 d3 = new DogVer2("Remi", 7);
     DogVer2 d4 = new DogVer2("Kroogs", 3);
     DogVer2 d5 = new DogVer2();
     
     // Get values from user
     Scanner scan = new Scanner(System.in);
     System.out.print("Enter the name of the new dog: ");
     d5.setName(scan.nextLine());
     
     System.out.println();
     
     System.out.print("Enter the age of the new dog: ");
     d5.setAge(scan.nextInt());
     
     System.out.println();
Sir Fluffington
     // Test toString
     System.out.println(d1.toString()); 
     System.out.println(d2.toString());
     System.out.println(d3.toString());
     System.out.println(d4.toString());
     System.out.println(d5.toString());
     
     System.out.println();

     // Retrieve a name: call getName from an output
     // statement
     System.out.print(d4.getName() + 
                       " also answers to the name ");

     // Update a name
     String newname = "Kruger";

     // call setName here
     d4.setName(newname);
     
     // Print updated name
     System.out.println(d4.getName() + "."); 
     
     System.out.println();
     
     // Retreive and update an age
     int newage;
     newage = d3.getAge() + 1;
       
     // call setAge here
     d3.setAge(newage);

     System.out.println("Happy Birthday, " + d3.getName() + "!");
     
     // Print new age for the dog. Call personYears here
     System.out.println("You are now " + d3.getAge() + ", which is " + d3.personYears() + " years old in person-years.");
     
     System.out.println();
     
     // Print count
     System.out.println("This code provided info on " + DogVer2.getCount() + " dogs.");

   }
}