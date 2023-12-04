/************
 
 Team 27
 Members:
 - Rebekah Pho
 - Spencer Missbach
 - Ernesto Diaz

 Compile with: 
 g++ -std=c++11 Createkey.cpp -o CreateKey -lgmp -lgmpxx
 
 ********/

#include <iostream>
#include <fstream>
#include <gmp.h>
#include <gmpxx.h>
#include "rsa.h"

int main () 
{
    const int BASE = 16;
    srand(time(NULL));
    const unsigned int key_length = 667;
    std::cout << "This program generates a 667-bit RSA key pair." << std::endl;

    // Declare and init variables
    mpz_t p, q, t, e, d, n;
    mpz_inits (p, q, t, e, d, n, NULL);
    
    // Find primes p and q
    std::cout << "Generating primes... " << std::flush;
    group27::gen_prime_length (p, key_length/2);
    group27::gen_prime_length (q, key_length/2);
    std::cout << "done." << std::endl;

    // Calculate totient t
    std::cout << "Calculating totient... " << std::flush;
    mpz_t temp;
    mpz_init (temp);
    mpz_sub_ui (t, p, 1);
    mpz_sub_ui (temp, q, 1);
    mpz_lcm (t, t, temp);
    mpz_clear (temp);
    std::cout << "done." << std::endl;
    
    // Calculate the modulus: n = p * q
    std::cout << "Calculating modulus... " << std::flush;
    mpz_mul (n, p, q);
    std::cout << "done." << std::endl;

    // Calculate the exponents e and d
    std::cout << "Calculating exponents... " << std::flush;
    group27::choose_e (e, t);
    mpz_invert (d, e, t);
    std::cout << "done." << std::endl;
    
    // Output keys
    std::cout << "Writing to files... " <<  std::flush;
    std::ofstream file ("pub.key", std::ofstream::trunc);
    file << mpz_get_str (NULL, BASE, e) << " " << mpz_get_str (NULL, BASE, n);
    file.close ();

    file.open ("priv.key", std::ofstream::trunc);
    file << mpz_get_str (NULL, BASE, d) << " " << mpz_get_str (NULL, BASE, n);
    file.close ();
    std::cout << "done." << std::endl;
    
    std::cout << "Key created successfully. Goodbye!" << std::endl;
}
