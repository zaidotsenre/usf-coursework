// ********************************************************
// Salary.java
//
// Computes the amount of a raise and the new salary for
// one or more employees. If the employee sells 100 or
// more cars, the employee receives a higher raise
//
// I pledge my Honor that I have not cheated, and will not cheat, on this assignment.
// Ernesto Diaz
// ********************************************************

import java.util.Scanner;
import java.text.NumberFormat;

public class Salary
{
   public static void main (String[] args)
   {
       final int CARS = 100; // car threshold
       String employeeName;   // name of employee
       double currentSalary; // employee's current salary
       double raise;         // amount of the raise
       double newSalary;     // new salary for the employee
       String response;       // response
       int carsSold;         // number of cars sold
       
       NumberFormat nf = NumberFormat.getCurrencyInstance();
       Scanner scan = new Scanner (System.in);

       //Begin do while
       do
       {
         //Get the employee's name
         System.out.print("Enter the employee's name: ");
         employeeName = scan.nextLine();

         //Get the employee's salary
         System.out.print("Enter the current salary: ");
         currentSalary = scan.nextDouble();

         //Input validation for salary
         while (currentSalary<=10000){
         
            System.out.println("Salary cannot be less than " + nf.format(10000) + ".");
            System.out.print("Re-enter the current salary: ");
            currentSalary = scan.nextDouble();
            
         }
         
         //Get the number of cars sold by the employee
         System.out.print("Enter the number of cars " + employeeName + " sold this year: ");
         carsSold = scan.nextInt();


         //Input validation for number of cars sold
         while (carsSold<=0) {
         
            System.out.println("That's clearly invalid.");
            System.out.print("Re-enter the number of cars Bobby Knox sold this year: ");
            carsSold = scan.nextInt();
          
         }
        
        
         // Compute the raise using conditional operator
         if (carsSold >=CARS) {
            
            raise = currentSalary*6/100;
         
         } else {
           
            raise = currentSalary*1.5/100;
            
         } 

         // Compute the new salary
         newSalary = currentSalary + raise;

   
         // Print the results
        
         
         System.out.println();
         System.out.println("Name:            " + employeeName);
         System.out.println("Current salary:  " + nf.format(currentSalary));
         System.out.println("Amount of raise: " + nf.format(raise));
         System.out.println("New salary:      " + nf.format(newSalary));

         //Run the program again?
         System.out.println();
         System.out.print("Process next employee salary and raise? Enter yes or no: ");
         response = scan.next();

         scan.nextLine();   //Reads extra newline character
       
     } while (response.equals("yes")); //end do while
}

}