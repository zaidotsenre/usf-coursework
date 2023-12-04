/*
 * sale.c
 * Written by Ernesto Diaz.
 *
 * This program takes the sale amount by 7 empoyees as input.
 * The program then finds the total and the max sale amount
 * and prints it to the console.
 */

#include <stdio.h>

#define SALESPEOPLE 7

void total_max(double sale[], int n, double * total,
       double * max, int * max_id);
       
int main () {
    
    // Read user input into sale[]
    double sale[SALESPEOPLE] = {0};
    int i;
    for (i = 0; i < SALESPEOPLE; i++){
        printf("Enter sales for salesperson %d: ", i + 1);
        scanf("%lf", &sale[i]);
    }
    
    // Call total_max
    double total, max;
    double * total_ptr = &total;
    double * max_ptr = &max;
    int max_id;
    int * max_id_ptr = &max_id;
    
    total_max(sale, SALESPEOPLE, total_ptr, max_ptr, max_id_ptr);
    
    // Print results
    printf("\nTotal sales: %.2f", *total_ptr);
    printf("\nSalesperson %d has the highest sale: %.2f \n", *max_id_ptr, *max_ptr);
    
    return 0;

}
     
/* total_max()                                       */
/* Finds the max and total of the elements in sale[] */
/* and stores them in *total and *max                */
/* The id of the salesperson who recorded the max    */
/* id stores in *max_id                              */
void total_max(double sale[], int n, double * total,
       double * max, int * max_id) {
    
    *max = 0;
    *total = 0;
    
    int i;
    for(i = 0; i < n; i++) {
        
        // Update total
        *total += sale[i];
        
        // Update max
        if(sale[i] > *max) {
            *max = sale[i];
            *max_id = i + 1;
        }
    }
    
}