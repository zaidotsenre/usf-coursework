class Road {
    
    public:
        
        // Constructor - initialize counters
        explicit Road (std::string roadName) {
            queue = 0;
            totalQueue = 0;
            cycleCount = 0;
            name = roadName;
        }
        
        // Returns true if there are cars waiting
        // Updates counters
        bool green () {
            if (queue > 0) {
                cycleCount++;
                totalQueue += queue;
                queue--;
                return true;
            }
            else {
                cycleCount++;
                return false;
            }
        }
        
        // Roll a dice, if we roll target, add a car to queue
        void randAdd (int faces, int target) {
            if (rand() % faces + 1 == target)
                queue++;
        }

        // Calculates the average queue size per cycle
        double getAvgQueue () {
            return totalQueue/cycleCount;
        }

        // Returns name of the Road
        std::string getName () {
            return name;
        }
    
    private:
        
        int queue;             // Cars waiting to pass through
        double totalQueue;     // Sum of all queues
        double cycleCount;     // Total number of cycles run
        std::string name;      // Name of the road
};