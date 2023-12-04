#include <iostream>
#include <iomanip>
#include <array>
#include "Road.h"

int main () {

    // Init random seed
    srand (time(NULL));

    // Array of roads
    std::array<Road, 4> roads{
        Road("Top"), 
        Road ("Left"), 
        Road ("Bottom"), 
        Road("Right")
    };

    // Time tracking variables
    double busyTime{0};
    double totalTime{0};

    // Run simulation
    while (totalTime < 1000000) {
        for (Road& road : roads) {

            if (road.green()){
                busyTime += 2;
                totalTime += 3;
            }
       
            for (Road& r : roads) {
                r.randAdd(4,4);
            }
        }
    }

    // Print report
    std::cout << std::fixed << std::setprecision(2)
        << "\n***** Report (sim-2) *****\n" << std::endl     
        << "Utilization: " << busyTime / totalTime * 100 << std::endl
        << "Average queues:" << std::endl;
    for (Road road : roads) {
        std::cout << std::setw(10) << road.getName() << ": "; 
        std::cout << road.getAvgQueue() << std::endl;
    }
}