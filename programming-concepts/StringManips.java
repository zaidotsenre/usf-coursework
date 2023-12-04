/**

* I pledge my Honor that I have not cheated, and will not cheat, on this assignment.

* @ author Ernesto Diaz

* StringManips.java Test several methods for manipulating String objects

*/

import java.util.Scanner;

class StringManips {

   public static void main(String[] args) {

       String phrase;

    int phraseLength;  // number of characters in the phrase String

    int middleIndex;   // index of the middle character in the String

    String firstHalf;   // first half of the phrase String

    String secondHalf; // second half of the phrase String

    String switchedPhrase; // a new phrase with original halves switched
    
    String middle3;
    
    String city;
    
    String state;
 

    // read in a phrase

    Scanner scan = new Scanner(System.in);

    System.out.println("Please enter a phrase:");

    phrase = scan.nextLine();
 

    // compute the length and middle index of the phrase

    phraseLength = phrase.length();

    middleIndex = phraseLength / 2;

 

    // get the substring for each half of the phrase

    firstHalf = phrase.substring(0, middleIndex);
    
    secondHalf = phrase.substring(middleIndex);
    
    
    // get the substring for middle 3
    
    middle3 = phrase.substring(middleIndex-1, middleIndex+2);

    // concatenate the firstHalf at the end of the secondHalf 
    // and replace blanks with asterisks

    switchedPhrase = secondHalf + firstHalf;
    switchedPhrase = switchedPhrase.replace(" ", "*");
    

    // print information about the phrase

    System.out.println("Switched phrase: " + switchedPhrase);

    System.out.println("Original phrase: " + phrase);

    System.out.println("Length of the phrase: " + phraseLength + " characters");

    System.out.println("Index of the middle: " + middleIndex);

    System.out.println("Character at the middle index: " + phrase.charAt(middleIndex));

    System.out.println("Middle three: " + middle3);
    
    
    // read city and state
    
    System.out.println("Please enter your city:");
    
    city = scan.nextLine();
    
    System.out.println("Please enter your state:");
    
    state = scan.nextLine();
    
    
    // modify and print city and state
    
    state = state.toUpperCase();
    city = city.toLowerCase();
    
    System.out.println(state + city + state);

   }

}