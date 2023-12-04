//*********************************************************
//  StarPattern.java 
//
//  This is a modified version of the Stars.java program
//
//  from Listing 6.4 in the text.
//
//  I pledge my Honor that I have not cheated, and will not cheat, on this assignment. 
//  Ernesto Diaz
//*********************************************************


import java.util.Scanner;


public class StarPattern1
{
   //------------------------------------------------------
   //  Prints a triangle shape using asterisk (star)     

   //  characters.
   //------------------------------------------------------
   public static void main(String[] args)
   {
     
      Scanner scan = new Scanner(System.in);

      int rows;  
               
      System.out.println("Enter number of rows: ");
      rows = scan.nextInt();  
      System.out.println(rows);
        

      for (int row = 1; row <= rows; row++) 
      {
        
         for (int space = rows-row; space > 0; space--) {
            System.out.print(" ");
         }

         for (int star = 1; star <= row; star++) {
               System.out.print("*");
         }
         
         System.out.println();
      }
   }
}
