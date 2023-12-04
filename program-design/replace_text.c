// Written By Ernesto Diaz
// This program takes a string as input.
// The program replaces each letter in the string with letters provided by the key: "mkrewyugptiaqdfhlnvosbzcxj"
// Lastly, the program prints the resulting string.

#include <stdio.h>
#include <string.h>
#include <ctype.h>

#define MAX_CHARACTERS 50


int read_line (char *str, int n);
void replace(char *s1, char *s2);

int main () {

    // request and read input
    printf ("Input: ");
    char s1[MAX_CHARACTERS];
    read_line (s1, MAX_CHARACTERS);
    
    // call replace and print results
    char s2[MAX_CHARACTERS];
    replace(s1, s2);
    printf("Output: %s\n", s2);

    return 0;
}



// reads up to the new line character
int read_line (char *str, int n) {
    int ch, i = 0;
    while ((ch = getchar()) != '\n') {
        if (i < n) {
            *str++ = ch;
            i++;        
        }
    }
    *str = '\0';   /* terminates string */
    return i;      /* number of characters stored */
}


// replaces each letter of string s1
// with the corresponding character of array key
// stores the result in string s2
void replace (char *s1, char *s2) {
    
    // set up
    char key[27] = "mkrewyugptiaqdfhlnvosbzcxj";
    strcpy(s2, s1);
    
    // apply key
    char *character;
    for (character = s2; *character != '\0'; character++) {
        if (*character >= 'a' && *character <= 'z') {
            *character = key[*character - 'a'];
        } else if (*character >= 'A' && *character <= 'Z') {
            *character = key[*character - 'A'];
            *character = toupper(*character);
        }
    }
}
