//*********************************************************
// WordCount.java 
//
// This program asks the user for a word and checks to see
// the number of times it appears in 'The Raven'.
//
// I pledge my Honor that I have not cheated, and will not cheat, on this assignment.
// Ernesto Diaz
//*********************************************************
import java.util.Scanner; // Needed for the Scanner class
import java.io.*;         // Needed for the File class

public class WordCount
{
   public static void main(String[] args) throws IOException
   {
     int wcount = 0; // keeps track of word
     String word, entry;
     
     System.out.println("This code lets a user enter a word " 
         + " and checks \'The Raven\' to see how many times "
         + "it appears.");
     
     // Open the file.
     File inputfile = new File ("TheRaven.txt");
     Scanner sc = new Scanner(inputfile);

     // Read from the keyboard too!
     Scanner scan = new Scanner(System.in);
     
     // Ask the user for a word and store it in entry
     System.out.print("Enter a word to look for: ");
     entry = scan.nextLine();
     entry = entry.toLowerCase();

     // Read lines from the file until no more are left.
     while (sc.hasNext())
     {
         // Use the word variable to read the file
         word = sc.next();
         word = word.toLowerCase();
         
         if (word.equals(entry)) // if word is equal to entry
            wcount++;
     }

     // Close the file.
     sc.close();

     // Print the number of times the word appears
     System.out.print("The word " + entry + " appears " + wcount + " times.");
          
   }
}
