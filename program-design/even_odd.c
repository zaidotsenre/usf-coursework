/*
 * even_odd.c
 * Written by Ernesto Diaz.
 *
 * This program takes an array of integers as input and
 * determines which are even.
 */

#include <stdio.h>

void is_even(int numbers[], int n, int result[]);

int main () {
    
    // Loop control
    int i;
    
    // Request number of integers
    printf("Enter the number of integers: ");    
    int n;
    scanf("%d", &n);
    
    // Request array elements
    printf("Enter the array elements: ");
    int numbers[n];
    for (i = 0; i < n; i++) {
        scanf("%d", &numbers[i]);
    }
    
    // Determine which are even
    int result[n];
    is_even(numbers, n, result);
    
    // Display results
    printf("\nOutput:\n");
    for(i = 0; i < n; i++) {
        printf("%d ", result[i]);
    }
    printf("\n");
    
    return 0;
    
}

/* Determines even or odd and stores results. */
void is_even(int numbers[], int n, int result[]) {
    int i;
    for(i = 0; i < n; i++) {
        result[i] = numbers[i] % 2 == 0 ? 1 : 0;
    }
}