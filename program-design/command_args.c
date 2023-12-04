// Written By Ernesto Diaz
// This program takes multiple strings as command line input
// The program finds and prints the longest of the strings.

#include <stdio.h>
#include <string.h>

#define MAX_CHARACTERS 20

int main (int argc, char **argv) {

    // find index of the longest string
    int longest = 1;
    int i;
    for (i = 1; i < argc; i++) {
        if (strlen(argv[i]) > strlen(argv[longest])) {
            longest = i;
        }
    }
    
    // print the longest string
    printf ("output: The longest string is %s\n", argv[longest]);
    
    return 0;
}

