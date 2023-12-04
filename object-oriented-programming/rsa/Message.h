#include <iostream>
#include <fstream>
#include <cmath>

class Message {
    
    public:
        
        // takes plain text as input
        // returns encrypted message
        int encrypt (int m) {
            readKey(1);                // read public key from file
            return modexp (m, e, n);  // perform calculations and return result
        }
        
        // takes ciphertext as input
        // returns decrypted message
        int decrypt (int c) {
            readKey(0);                // read private key from file
            return modexp(c, d, n);    // perform calculations and return result
        }
        
        // function that calculates modular exponent
        // takes inputs base, exponet and modulus
        // returns the result of base^exponent (mod modulus)
        int modexp (int base, int exponent, int modulus) {
            
            int result = base;             // will store result - initialized to the base
            int counter = 1;               // counter initialized to one
            
            while (counter < exponent) {   // loop runs (exponent - 1) times
                result *= base;            // multiply by the base
                result %= modulus;         // calculate mod at every step
                counter++;                 // update counter
            }
            return result;                 // send result back to the user
        }
    
    private:
        
        // function that reads from .key files
        void readKey (int type) {
            
            // names of .key files
            const std::string pubfile {"pub.key"};
            const std::string privfile {"priv.key"};

            std::ifstream file;                         // instantiate ifstream
            file.open (type ? pubfile : privfile);      // open the appropriate file
            file >> (type ? e : d) >> n;                // read to the correct variables
            file.close();                               // close file
        }
        
        /*  VARIABLES */
        
        int e; // stores the public exponent e
        int d; // stores the private exponent d
        int n; // stores the modulus n
};