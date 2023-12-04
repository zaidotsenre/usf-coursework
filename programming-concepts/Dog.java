//*********************************************************
// Dog.java       
//
// This class contains data and methods related to the
// names and ages of dogs.
//
// I pledge my Honor that I have not cheated, and will not cheat, on this assignment.
// Ernesto Diaz
//*********************************************************

public class Dog
{
   // declare variables to store the name/age of the dog
   // Tip: This should be private!
   private String name;
   private int age;


   //Methods are below. They should be public

   //------------------------------------------------------
   // Constructor: Sets up Dog object with specified data.
   //------------------------------------------------------
   public Dog(String n, int a)     {
   
      name = n;
      age = a;

   }

   //------------------------------------------------------
   // Name accessor – declare getName here
   //------------------------------------------------------
   public String getName()  {
   
      return name;
      
   }

   //------------------------------------------------------
   // Name mutator – declare setName here
   //------------------------------------------------------
   public void setName(String n)  {
   
      name = n;
      
   }

   //------------------------------------------------------
   // Age accessor – declare getAge here
   //------------------------------------------------------
   public int getAge()  {
   
      return age;
      
   }

   //------------------------------------------------------
   // Age mutator – declare setAge here
   //------------------------------------------------------
   public void setAge(int a)  {
   
      age = a;
      
   }

   //------------------------------------------------------

   // Declare personYears here
   // Computes & returns this dog's age in "person-years".
   //------------------------------------------------------
   public int personYears()  {
   
      return age*7;
      
   }

   //------------------------------------------------------
   // declare toString here

   // Returns a string representation of this dog.
   //------------------------------------------------------
   public String toString()  {
   
      return "Dog: " + name + "  Age: " + age + "  Person-Years: " + personYears();
      
   }

}
