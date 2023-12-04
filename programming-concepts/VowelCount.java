//*********************************************************
// VowelCount.java       
//
// This program counts the number of vowels in a string
//
// I pledge my Honor that I have not cheated, and will not cheat, on this assignment.
// Ernesto Diaz
//*********************************************************

import java.util.Scanner;

public class VowelCount
{
   public static void main(String[] args)
   {
   
      String userInput;
   
     /*declare variables to store the number 
     of each type of vowel*/
     int aCount=0, eCount=0, iCount=0, oCount=0, uCount=0;

     Scanner scan = new Scanner(System.in);

     //Get the string from the user (prompt and input)
     System.out.println("Enter a string of characters:");
     userInput = scan.nextLine();
     userInput = userInput.toLowerCase();
     
         for (int i=0; i<userInput.length(); i++){
             
             switch (userInput.charAt(i)){
                 case 'a': 
                  aCount++;
                  break;
                 
                 case 'e':
                  eCount++;
                  break;
                  
                 case 'i':
                  iCount++;
                  break;
                  
                 case 'o':
                  oCount++;
                  break;
                  
                 case 'u':
                  uCount++;
                  break;
             
             }
             
         }    

     //Output results
     System.out.println("Number of each vowel in the string:");
     System.out.println("a: " + aCount);
     System.out.println("e: " + eCount);
     System.out.println("i: " + iCount);
     System.out.println("o: " + oCount);
     System.out.println("u: " + uCount);
   }
}