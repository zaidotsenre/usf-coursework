/************
 
 Team 27
 Members:
 - Rebekah Pho
 - Spencer Missbach
 - Ernesto Diaz

 To compile this file use:
    g++ -std=c++11 Decrypt.cpp -o Decrypt -lgmp -lgmpxx

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
    std::string d_string;
    std::string n_string;
    std::ifstream file ("priv.key", std::ifstream::in);
    file >> d_string;
    file >> n_string;
    file.close ();
    
    // Init big int variables
    mpz_t d;
    mpz_init_set_str (d, d_string.c_str(), BASE);
    mpz_t n;
    mpz_init_set_str (n, n_string.c_str(), BASE);
    
    // Get a ciphertext from the user and decrypt
    std::cout << "Please, enter the ciphertext you received from the Encrypt program: " << std::flush;
    std::string C_string;
    std::cin >> C_string;
    mpz_t C;
    mpz_init_set_str (C, C_string.c_str(), BASE);
    mpz_t M;
    mpz_init (M);
    mpz_powm (M, C, d, n);
    
    // Output the encrypted message
    std::cout << "Decrypted message: " << mpz_get_str(NULL, 10, M) << std::endl;
}
