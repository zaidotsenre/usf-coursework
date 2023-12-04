/**

* Salary.java

* Computes the distance between two points. Takes the x and y coordinates of said points from  

* the user then uses the Pythagorean theorem to calculate the distance.

* I pledge my Honor that I have not cheated, and will not cheat, on this assignment.

* @author: Ernesto Diaz

*/



import java.util.Scanner;

import java.text.DecimalFormat;

import java.lang.Math;

 

public class Distance {

   public static void main (String[] args) {

      double distance;
      
      // Point 1 coordinates
      double x1;  
      double y1;
      
      // Point 2 coordinates
      double x2;
      double y2;
      
      Scanner scan = new Scanner(System.in);
      DecimalFormat fmt = new DecimalFormat("0.###");
      
      // Requesting point 1 coordinates from user
      System.out.println("\nEnter the x coordinate of the first point:");
      x1 = scan.nextDouble();
      
      System.out.println("\nEnter the y coordinate of the first point:");
      y1 = scan.nextDouble();
      
      // Requesting point 2 coordinates from user
      System.out.println("\nEnter the x coordinate of the second point:");
      x2 = scan.nextDouble();
      
      System.out.println("\nEnter the y coordinate of the second point:");
      y2 = scan.nextDouble();
      
      // Computing distance
      distance = Math.sqrt(Math.pow(x1-x2,2)+Math.pow(y1-y2,2));
      
      // Printing result
      System.out.println("\n\nDistance: " + fmt.format(distance));
      
   }

}