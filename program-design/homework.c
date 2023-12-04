// Written By Ernesto Diaz
// This program takes a number of days to work on an assignment  and the current day as input.
// The program calculates what weekday the assignment is due on and the amount of days until the assignment is due.
// If the due day is a weekend, the program will move the due date to the next Monday.

#include <stdio.h>

#define DAYS_IN_WEEK 7

int main () {

	printf("Enter today's day of the week: ");
	int today;
	scanf("%d", &today);
	if (today < 0 || today > 6) {
		printf("ERROR: Invalid input. Input must be 0 - 6.\n");
		printf("Program will now exit.");
		return 1;
	}
	
	printf("Enter the number of days for doing the work: ");
	int time;
	scanf("%d", &time);
	
	// Adjust so it's not due on a weekend
	int dueday = (today + time) % DAYS_IN_WEEK;
	while (dueday == 0 || dueday == 5 || dueday == 6) {
		time++;
		dueday = (today + time) % DAYS_IN_WEEK;
	}

	const char *weekdays[4];
        weekdays[0] = "Monday";
        weekdays[1] = "Tuesday";
        weekdays[2] = "Wenesday";
        weekdays[3] = "Thursday";

	// subtract 1 to get correct result from array
	printf("The due date is %s. ", weekdays[dueday - 1]);
	printf("The number of days until due date is %d.\n", time);

	return 0;
}
