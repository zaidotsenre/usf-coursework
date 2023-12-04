//*********************************************************
// Kennel.java       
//
// This is the driver program for the Dog class
//
// I pledge my Honor that I have not cheated, and will not cheat, on this assignment.
// Ernesto Diaz
//*********************************************************

public class Kennel
{
   //------------------------------------------------------
   // Creates and exercises some Dog objects.
   //------------------------------------------------------
   public static void main (String[] args)
   {
     // Create objects - test constructor 
     Dog d1 = new Dog("Cooper", 1);
     Dog d2 = new Dog("Pico", 2);
     Dog d3 = new Dog("Remi", 7);
     Dog d4 = new Dog("Kroogs", 3);


     // Test toString
     System.out.println(d1.toString()); 
     System.out.println(d2.toString());
     System.out.println(d3.toString());
     System.out.println(d4.toString());
     
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

   }
}