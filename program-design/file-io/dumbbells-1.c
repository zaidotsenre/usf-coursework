// Written by Ernesto Diaz
// This program reads from file dumbbells.txt in the same directory weight, color, and quantity data
// It sorts the data in ascending order by wieght and outputs to a file named ordered_dumbbells.txt in the same directory

#include <stdio.h>

#define MAX_DUMBBELLS 100
#define MAX_LENGTH 100

// Define struct type dumbbell
typedef struct {
    int weight;
    char color[MAX_LENGTH];
    int quantity;
} dumbbell;

void selection_sort(dumbbell array_dumbbells[], int n);

int main () {
    
    // Array to store the data
    dumbbell inventory[MAX_DUMBBELLS];

    // Read from input file
    FILE *input_file = fopen("dumbbells.txt", "r");
    int read_count = 0;
    while (fscanf(input_file, "%d %s %d", &inventory[read_count].weight, inventory[read_count].color, &inventory[read_count].quantity) == 3 && read_count < MAX_DUMBBELLS) {
        read_count++;
    }

    // Sort the array
    selection_sort (inventory, read_count);

    // Write to output file
    FILE *output_file = fopen("ordered_dumbbells.txt", "w");
    int i;
    for (i = 0; i < read_count; i++) {
        fprintf (output_file, "%d %s %d\n", inventory[i].weight, inventory[i].color, inventory[i].quantity);
    }
    printf("Done!\n");

    return 0;
}


// Takes an array of struct dumbbels and the amount of elements as input
// Sorts the array by weight in ascending order
void selection_sort(dumbbell array_dumbbells[], int n)
{
  int i, largest = 0; 
  dumbbell temp;

  if (n == 1)
    return;

  for (i = 1; i < n; i++)
    if (array_dumbbells[i].weight > array_dumbbells[largest].weight)
      largest = i;

  if (largest < n - 1) {
    temp = array_dumbbells[n-1];
    array_dumbbells[n-1] = array_dumbbells[largest];
    array_dumbbells[largest] = temp;
  }

  selection_sort(array_dumbbells, n - 1);
}