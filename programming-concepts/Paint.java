/**

* Paint.java Determine how much paint is needed to paint the walls of a room

* given its length, width, and height

* I pledge my Honor that I have not cheated, and will not cheat, on this assignment

* @author Ernesto Diaz

*/

import java.util.Scanner;

public class Paint {

    public static void main(String[] args) {

       final int COVERAGE = 350; // paint covers 350 sq ft/gal
       final int DOOR = 20;      // area of a door (20 sq ft)
       final int WINDOW = 15;    //area of a window (15 sq ft)

       // declare integers length, width, height, numDoors, and numWindows;
       int length;
       int width;
       int height;
       int numDoors;
       int numWindows;

       // declare double totalSqFt and totalSqFtDW;
       double totalSqFt;

       // declare double paintNeeded; 
       double paintNeeded;

       // declare and initialize Scanner object
       Scanner scanner = new Scanner(System.in);

       // Prompt for and read in the length of the room
       System.out.println("Enter the length of the room in feet:");
       length = scanner.nextInt();

       // Prompt for and read in the width of the room
       System.out.println("Enter the width of the room in feet:");
       width = scanner.nextInt();

       // Prompt for and read in the height of the room
       System.out.println("Enter the height of the room in feet:");
       height = scanner.nextInt();
       
       // Prompt for and read the number of doors
       System.out.println("Enter the number of doors the room has:");
       numDoors = scanner.nextInt();
       
       // Prompt for and read the number of windows
       System.out.println("Enter the number of windows the room has:");
       numWindows = scanner.nextInt();

       // Compute the total square feet to be painted
       totalSqFt = (height*width*2+height*length*2)-(numDoors*DOOR+numWindows*WINDOW);

       // Compute the amount of paint needed
       paintNeeded = totalSqFt/COVERAGE;

       // Print the length, width, and height of the room and the
       // number of gallons of paint needed.
       System.out.println("Length: " + length + " ft");
       System.out.println("Width: " + width + " ft");
       System.out.println("Height: " + height + " ft");
       System.out.println("Doors: " + numDoors);
       System.out.println("Windows: " + numWindows);
       System.out.println("Gallons needed: " + paintNeeded);

    }

}

