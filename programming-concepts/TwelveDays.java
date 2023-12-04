//********************************************************************
//  TwelveDays.java       
//
//  This code prints out the verses to 
//  "The Twelve days of Christmas."
//
//  I pledge my Honor that I have not cheated, and will not cheat, on this assignment.
//  Ernesto Diaz
//********************************************************************

import java.util.Scanner;

public class TwelveDays
{
   public static void main(String[] args)
   {
      final int MAX = 12;
      int lastDay = 0;  //last day for the song, user will update
      Scanner scan = new Scanner(System.in);

      //Get the last day and use input validation
      System.out.println("How many days (1 to 12)?");
      lastDay = scan.nextInt();
      

//Begin 1st while
      while (lastDay > MAX || lastDay < 1)
      {
         System.out.println("How many days (1 to 12)?");
         lastDay = scan.nextInt();
      
      }
      
      
      int day = 1;      //loop control variable for song verses
     

//Begin 2nd while
      while (day <= lastDay)
      {
         //Output: "On the" + day 
         System.out.print("On the " + day);

         //Output the suffix for the day

         //Begin 1st switch
         switch (day)
         {
            case 1: 
               System.out.print("st");
               break;
            case 2: 
               System.out.print("nd");
               break;
            case 3: 
               System.out.print("rd");
               break;
            default: 
               System.out.print("th");      
         }

         //Output " day of Christmas my true love gave to me "
         System.out.print(" day of Christmas my true love gave to me \n" );

         //Output the gift

         //Begin 2nd switch
         switch (day)
         {
         case 12: 
            System.out.println("Twelve drummers drumming,");
         case 11: 
            System.out.println("Eleven pipers piping,");
         case 10: 
            System.out.println("Ten lords a-leaping,");
         case 9: 
            System.out.println("Nine ladies dancing,");
         case 8: 
            System.out.println("Eight maids a-milking,");
         case 7: 
            System.out.println("Seven swans a-swimming,");
         case 6: 
            System.out.println("Six geese a-laying,");
         case 5: 
            System.out.println("Five golden rings,");
         case 4: 
            System.out.println("Four calling birds,");
         case 3: 
            System.out.println("Three French hens,");
         case 2: 
            System.out.println("Two turtle doves, and");
         case 1:
            System.out.println("A partridge in a pear tree. \n");
         }

         //Increment the loop control variable
         day++;
    }
}

}

