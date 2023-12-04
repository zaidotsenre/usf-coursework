/************
 
 Team 27
 Members:
 - Rebekah Pho
 - Spencer Missbach
 - Ernesto Diaz
 
 ***********/
#include <vector>

namespace group27 {
    
#ifndef BOUNDS_H
#define BOUNDS_H
    
    /* Optimal B1 values for integers <70 digits long */
    /* Pairs are of the format {digit count, optimal B1 value} */
    const std::vector <std::vector <double>> BOUNDS
    {
        {15, 2000},
        {20, 11000},
        {25, 50000},
        {30, 250000},
        {35, 1000000},
        {40, 3000000},
        {45, 11000000},
        {50, 43000000},
        {55, 110000000},
        {60, 260000000},
        {65, 850000000},
        {70, 2900000000}
    };
    
    
    double optimal_B1 (int digits)
    {
        for (const std::vector <double>& b : BOUNDS)
        {
            if (digits < b[0])
                return b[1];
        }
        return -1;
    }
    
#endif
    
}
