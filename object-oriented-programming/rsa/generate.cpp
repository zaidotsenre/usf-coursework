#include <iostream>
#include <fstream>

class Key {

    public:
        
        // constructor
        // initializes most variables
        explicit Key () {
            
            // choose two random prime numbers p and q between 2 and 100
            std::srand(time(NULL)); // initialize random seed
            p = {primes[std::rand() % 24]};  // stores first prime
            q = {primes[std::rand() % 24]};  // sotres second prime
            
            // calculate n = p * q
            n = {p * q};
            
            // calculate totient t
            t = {((p - 1) * (q - 1))};
            
            // compute public (encrypt) exponent e
            e = {chooseE()};
            
            // compute private (decrypt) exponent d
            d = {chooseD()};
        }
        
        // creates .key files and outputs the keys
        void gen () {
            
            std::ofstream file;                     // instantiate ofstream
            file.open("pub.key", std::ios::trunc);  // open pub.key
            file << e << " " << n << std::endl;     // output key to file
            file.close();                           // close file
            
            file.open("priv.key", std::ios::trunc); // open priv.key
            file << d << " " << n << std::endl;     // output key to file
            file.close();                           // close file
        }
    
    private:
        
        // method that finds the Greatest Common Divisor (GDC) of two integers
        // follows the Euclidean algorithm for finding GDC
        int gcd (int a, int b){
            
            int remainder;             // stores the result of a mod b
            
            while (a != 0 && b != 0){
                remainder = a % b;     // compute a mod b
                a = b;                 // take b as our new a 
                b = remainder;         // take remainder as our new b
            }
            
            // check for zero values and return the GDC
            return (a == 0 ? b : a);
        }
        
        // method that computes the value of e
        // uses the gcd () function
        int chooseE () {
            
            int value{2};                   // stores the current value being tested
            
            while (value < t){              // loop through all possible values of e
                if(gcd(t, value) == 1){     // if gcd (t, value) == 1, then e = value
                    break;                  // so, break loop
                }
                value++;                    // increment to the next value to be tested
            }
            
            return value;                   // return the result
        }
        
        // method that computes the value of d
        int chooseD() {
        
            int value{0};                   // stores the value being tested
            
            while (value < t) {             // loop through the possible values             
                if((value * e) % t == 1){   // test for d*e congruent 1 (mod t)
                    break;                  // stop after finding the first value that satisfies the congruence 
                }
                value++;                    // increment to the next value to be tested
            }
            
            return value;                   // return the value of d
        }

        
        /* VARIABLES */

        int p; // first prime
        int q; // second prime
        int n; // n = p * q 
        int t; // totient t = (p-1)(q-1)
        int e; // public exponent (encrypt)
        int d; // private exponent (decrypt)
        
        // array of all prime numbers less than 100
        int primes[25]{2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97}; 
        
// end of class Key
};


int main () {

    Key key;   // instantiate a key object
    key.gen(); // generate .key files

}