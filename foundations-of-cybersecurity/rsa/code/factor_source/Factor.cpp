/************
 
 Team 27: Factor
 Members:
    - Rebekah Pho
    - Spencer Missbach
    - Ernesto Diaz
 
 Compile with:
 g++ -std=c++11 Factor.cpp -o Factor -lecm -lgmp -lgmpxx
 
 ***********/

#include <iostream>
#include <gmp.h>
#include "ecm-7.0.4/ecm.h"
#include "bounds.h"

int main ()
{
    /* Read input to be factored */
    std::cout  << "Enter a number to factor: " << std::flush;
    std::string input;
    getline (std::cin, input);
    
    
    /* Validation. Check that input has 70 digits or less */
    while (input.size () > 70)
    {
        std::cout << "The number you entered is too large." << std::endl;
        std::cout << "Please, enter a number with 70 digits or less: " << std::flush;
        getline (std::cin, input);
    }
    
    /* Set up for factoring */
    mpz_t n;
    mpz_init_set_str (n, input.c_str(), 10);
    double B1 = group27::optimal_B1 (mpz_sizeinbase (n, 10));
    int feedback;
    mpz_t factor;
    mpz_init (factor);
    
    
    /* Validation. Check that the number is not prime. */
    const int reps = 50;
    int primecheck = mpz_probab_prime_p (n, reps);
    
    /* Perform factorization if the input number is not prime  */
    /* If number is small, perform Pollard's Rho               */
    /* else, perform ECM with different seeds until successful */
    if (primecheck !=2)
    {
        std::cout << "Factoring... \n(This could take a few minutes)" << std::endl;

        do
            feedback = ecm_factor (factor, n, B1, NULL);
        while (!(mpz_cmp (factor, n) < 0));
    }
    else
        std::cout << "The number you entered cannot be factored because it is prime." << std::endl;

    /* Report results to the user */
    const std::string success = "\nSuccess! Factors: ";
    const std::string failure = "\nSorry, no factors were found.";
    const std::string error = "\nError! Unable to complete this factorization. ";
    
    std::cout << (feedback > 0 ? success : (feedback == 0 ? failure : error)) << std::endl;
    if (feedback > 0)  std::cout << factor << std::endl;
}
