// I pledge my Honor that I have not cheated, and will not cheat, on this test.
// Ernesto Diaz

//*********************************************************
//  StarsPattern2.java       
//
//  This program creates a pattern of stars 
//  (flipped horizontally and vertically) 
//*********************************************************

import java.util.Scanner;

public class StarPattern2
{
   public static void main(String[] args)
   {
      int numrows;
      int counter = 0;
      
      Scanner scan = new Scanner(System.in);
      System.out.print("Enter the number of rows: ");
      numrows = scan.nextInt();

      //Add your code here 
      
      // get rows from user 
      
      while(numrows<1 || numrows>10){
      
         System.out.print("Please enter a number between 1-10: ");
         numrows = scan.nextInt();
         
      }
      
      // print stars (most to least 10-1)
      for(int i = 0; i<numrows; i++){
          
          for (int z = 0; z<i; z++){
            System.out.print(" ");
            
         }
          for (int x = 10-i; x>0; x--){
            System.out.print("*");
            
         }
         System.out.println();
      } 

}
}

