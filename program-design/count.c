// By Ernesto Diaz
// This program takes a string as input and counts the amount of times whitespaces and the following characters appear:
// , . ! ? ;

#include <stdio.h>

int main () {

	printf("Enter a sentence: ");
	
	// Count spaces and character 
	int spaceCounter = 0;
	int punctCounter = 0;
	char character;
	while ((character = getchar()) && character != '\n') {
		switch (character) {
			case ' ':
				spaceCounter++;
				break;
			case ',':
			case '.':
			case '!':
			case '?':
			case ';':
				punctCounter++;
				break;
			default:
				break;
		}
	}

	// Report results to users
	printf("There are %d white spaces and %d punctuation marks.\n", 
		spaceCounter, punctCounter);

	return 0;
}
