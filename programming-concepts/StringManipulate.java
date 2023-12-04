/** 

* I pledge my Honor that I have not cheated, and will not cheat, on this test.

* Ernesto Diaz

*/

import java.util.Scanner;

public class StringManipulate {

  public static void main(String[] args) {   
  
     String concatenated;
     int stringLength;
     
     String firstHalf;
     String secondHalf;
     
     String literal1;
     String literal2;
     
     Scanner scan = new Scanner(System.in);
         
     // Get first String from user
     System.out.println("Please type in the first string literal."); 
     literal1 = scan.nextLine();
     
     // Get second String from user
     System.out.println("Please type in the second string literal."); 
     literal2 = scan.nextLine();
     
     // Concatenate these two strings, and add an empty space between them.
     concatenated = literal1 + " " + literal2;   
     
     // Convert all characters in Concatenated string to uppercase. Output this result.
     concatenated = concatenated.toUpperCase();
     System.out.println("The concatenated string is: " + concatenated);
     
     // Output the first character, the middle character and last character 
     // of the concatenated String. 
     stringLength = concatenated.length();
     
     System.out.println("The first character of the string is: " + concatenated.substring(0,1));
     System.out.println("The mid character of the string is: " + concatenated.substring(stringLength/2-1, stringLength/2));
     System.out.println("The last character of the string is: " + concatenated.substring(stringLength-1));         
     
     // Replace the second half of the string with the string literal “firstLabExam”.
     secondHalf = concatenated.substring(stringLength/2, stringLength);
     concatenated = concatenated.replace(secondHalf, "firstLabExam");
     System.out.println("After replacing the second half, the string is: " + concatenated);
     
     
     // Permute the string by switching the first half and second half of the string
     stringLength = concatenated.length();
     firstHalf = concatenated.substring(0, stringLength/2);
     secondHalf = concatenated.substring(stringLength/2, stringLength);
     concatenated = secondHalf + firstHalf;
     System.out.println("The string after switching the 1st and 2nd half is: " + concatenated);
     
     // If the length of the string is large or equal than 15, 
     // then print “this string is long” to the screen, otherwise
     // print “this string is short” to the screen.
     if (stringLength == 15 || stringLength > 15) {
         System.out.println("This string is long.");
     } 
     
     else {
         System.out.println("This string is short");
     }  
     
   }
     
}