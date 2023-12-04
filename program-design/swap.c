/*
 * swap.c
 * Written by Ernesto Diaz.
 *
 * This program takes an array of integers as input and
 * swaps pairs of elements. If the array has odd length
 * the last element is left in its original position.
 */

#include <stdio.h>

int main () {
    
    // For loop control
    int i;
    
    // Request length of array
    printf("Enter the length of the array: ");
    int length;
    scanf("%d", &length);
    
    // Declare array of given length
    int numbers[length];
    
    // Request elements and fill array
    printf("Enter the elements of the array: ");
    for(i = 0; i < length; i++) {
        scanf("%d", &numbers[i]);
    }
    
    // Swap elements
    for(i = 1; i < length; i += 2) {
        int temp = numbers[i];
        numbers[i] = numbers[i - 1];
        numbers[i - 1] = temp;
    }
    
    // Display array
    printf("\nOutput: \n");
    for (i = 0; i < length; i++) {
        printf("%d ", numbers[i]);
    }
    printf("\n");
    
    return 0;
}