#include <iostream>
#include "Message.h"

int main() {
    
    // user interaction strings
    const std::string welcome = "Enter ciphertext: ";
    const std::string valid = "Decrypting...\n";
    const std::string invalid = "Invalid input. Please make sure you entered valid ciphertext.";
    const std::string success = "Decryption complete. \nMessage: ";

    int input{-1};  // stores input (initialized to -1 for validation purposes)
    int output;     // stores output of the program
    
    Message msg;    // instantiate a Message object
    
    while (input < 1) {                                             // loop until valid input is provided
        std::cout << welcome << std::flush;                         // request input from the user
        std::cin >> input;                                          // store input
        std::cout << std::endl;                                     // skip to next line
        std::cout << (input < 1 ? invalid : valid) << std::endl;    // validate input and provide feedback to user
    }
    
    output = msg.decrypt(input);                      // decrypt 
    std::cout << success << output << std::endl;      // print output
    
    return 0; // end of program
}