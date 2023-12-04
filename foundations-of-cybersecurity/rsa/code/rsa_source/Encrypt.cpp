/************
 
 Team 27
 Members:
 - Rebekah Pho
 - Spencer Missbach
 - Ernesto Diaz
 
 To compile this file use:
    g++ -std=c++11 Encrypt.cpp -o Encrypt -lgmp -lgmpxx

***********/
#include <iostream>
#include <fstream>
#include <gmp.h>
#include <gmpxx.h>

int main ()
{
    // The base used for GMP
    const int BASE = 16;
    
    // Read key
    std::string e_string;
    std::string n_string;
    std::ifstream file ("pub.key", std::ifstream::in);
    file >> e_string;
    file >> n_string;
    file.close ();
    
    // Init big int variables
    mpz_t e;
    mpz_init_set_str (e, e_string.c_str(), BASE);
    mpz_t n;
    mpz_init_set_str (n, n_string.c_str(), BASE);
    
    // Get a message from the user and encrypt
    std::cout << "Please, enter a test message (a positive integer): " << std::flush;
    std::string M_string;
    std::cin >> M_string;
    mpz_t M;
    mpz_init_set_str (M, M_string.c_str(), 10);
    mpz_t C;
    mpz_init (C);
    mpz_powm (C, M, e, n);
    
    // Output the encrypted message
    std::cout << "Encrypted message: " << mpz_get_str(NULL, BASE, C) << std::endl;
}
