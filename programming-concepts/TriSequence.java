// I pledge my Honor that I have not cheated, and will not cheat, on this test.
// Ernesto Diaz

 

//*********************************************************
//  TriSequence.java       
//
//  This program generates and stores the first 100 numbers 
//  of the Triangular number sequence. It then prompts the  
//  users to enter a value corresponding to an ordered 
//  number in the sequence and returns that number.
//*********************************************************

import java.util.Scanner;

public class TriSequence
{
   public static void main(String [] args)
   {
      final int SIZE = 100;
      
      Scanner scan = new Scanner (System.in);
      
      int sum = 0;   // Accumulator
      int number;    // to store user input
     

 //Add your code here

      int [] triangle = new int[100];  // array
      
      // populate array
      for(int i = 0; i<100; i++) {
      
         triangle[i] = sum + i + 1;
         sum = sum + i + 1;
      }
      
      // get number from user
      System.out.println("Enter a value between 1-100 and I will give you the corresponding number in the Triangular sequence.");
      System.out.print("Which number would you like? ");
      number = scan.nextInt();
      
      // input validation
      while(number<1 || number>100){
      
          System.out.println("The value you entered is not between 1-100.");
          System.out.print("Enter a value between 1-100: ");
          number = scan.nextInt();
        
      }

      // print the value    
         System.out.print("The " + number);
         
         switch (number%10) {
         
            case 1 :
               System.out.print("st");
               break;
               
            case 2 :
               System.out.print("nd");
               break;
               
            case 3 :
               System.out.print("rd");
               break;
               
            default :
               System.out.print("th");
               break;
               
         }
         System.out.print(" number in the triangular sequence is ");
         System.out.println(triangle[number-1]);
      
      
      

   }
}