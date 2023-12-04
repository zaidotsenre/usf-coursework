/************
 
 Team 27
 Members:
 - Rebekah Pho
 - Spencer Missbach
 - Ernesto Diaz

 Functions for the rsa key generation process.
 
 ****************/

namespace group27
{
    #ifndef RSA_H
    #define RSA_H
    
    #include <gmp.h>
    #include <gmpxx.h>
    
    /* Prototypes */
    
    void gen_prime_length (mpz_t& rop, unsigned int bits);
    void choose_e (mpz_t& rop, const mpz_t& totient);
    bool coprime (const mpz_t& number1, const mpz_t& number2);
    
    /* Definitions */
    
    // Generates a prime number of the given length (bits)
    void gen_prime_length (mpz_t& rop, unsigned int bits)
    {
        std::string base = "1";
        
        for (unsigned int i = 1; i < bits; i++)
            base += std::to_string(rand () % 2);
        
        mpz_set_str (rop, base.c_str(), 2);
        mpz_nextprime (rop, rop);
    }
    
    // Chooses a valid public exponent (e) for rsa
    void choose_e (mpz_t& rop, const mpz_t& totient)
    {
        mpz_t e;
        mpz_init_set_ui (e, 2);
        while (!coprime (e, totient))
            mpz_add_ui (e, e, 1);
        mpz_set (rop, e);
    }
    
    // Checks if the two parameters are coprime
    bool coprime (const mpz_t& number1, const mpz_t& number2)
    {
        mpz_t res;
        mpz_init (res);
        mpz_gcd (res, number1, number2);
        return ((mpz_cmp_ui (res, 1) == 0) ? true : false);
    }
    
    #endif
}
