/*
 * even_odd_pointer.c
 * Written by Ernesto Diaz.
 *
 * This program takes an array of integers as input and
 * determines which are even.
 */

#include <stdio.h>

void is_even(int * numbers, int n, int * result);

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

/* is_even()                                           */
/* Determines if the elements of array numbers         */
/* are even or odd and stores results in array result. */
void is_even(int * numbers, int n, int * result) {
    int * res_ptr = result;
    int * num_ptr;
    for(num_ptr = numbers; num_ptr < numbers + n; num_ptr++, res_ptr++) {
        *res_ptr = *num_ptr % 2 == 0 ? 1 : 0;
    }
}