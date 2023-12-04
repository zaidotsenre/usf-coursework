//********************************************************************
//  Digits.java       
//
//  Determine the number of odd, even and zero digits in an
//  integer number
//
//  I pledge my Honor that I have not cheated, and will not cheat, on this assignment.
//  Ernesto Diaz
//********************************************************************

import java.util.Scanner;
import java.lang.Math;

public class Digits
{
   public static void main(String[] args)
   {
      int oddCount = 0, evenCount = 0, zeroCount = 0; //digit counters
      int value, digit;    //stores input value and digit respectively
      int copy;            //stores copy of entry  

      Scanner scan = new Scanner(System.in);

      //Get value from user
      System.out.println("Enter an integer value:");
      value = scan.nextInt();
      copy = value;

      //Make the value positive
      value = Math.abs(value);
 

      //What if the value is actually zero? 
     if (value == 0) {
         zeroCount++;
     }


      //Get each digit – begin while
      while (value > 0)
         
      {
         //Start with the right most digit
         digit = value % 10;

         //Keep tabs of the types of digit – begin if-else
         if (digit == 0) {
         
            zeroCount++;
         
         } else if (digit % 2 == 0){
         
            evenCount++;
         
         } else {
         
            oddCount++;
          
         }   

         //Update the value (this will help us get the next digit)
         value = value / 10;
      }


      //Output results
      System.out.println("The number " + copy + " consists of: ");
      System.out.println("Zero digits: " + zeroCount);
      System.out.println("Even digits: " + evenCount);
      System.out.println("Odd degits: " + oddCount);  

   }

}