/// better to store the keys in two arrays pubkey and privkey
#include <iostream>
#include "Message.h"

int main() {
    
    // user interaction strings
    const std::string welcome = "Enter a message (integer between 1 and 50): ";
    const std::string invalid = "Invalid input.";
    const std::string valid = "Encrypting...\n";
    const std::string success = "Encryption complete. \nCiphertext: ";
    
    int input{-1};  // stores input (initialized to -1 for validation purposes) 
    int output;     // stores program output
    
    Message msg;   // instantiate a Message object
    
    while (input < 1 || input > 50) {                                           // loop until valid input is provided
        std::cout << welcome << std::flush;                                     // request input from the user
        std::cin >> input;                                                      // store input
        std::cout << std::endl;                                                 // skip a line
        std::cout << (input < 1 || input > 50 ? invalid : valid) << std::endl;  // validate input and provide feedback to user
    }
    
    output = msg.encrypt(input);                      // encrypt 
    std::cout << success << output << std::endl;      // print output
    
    return 0; // end of program
}