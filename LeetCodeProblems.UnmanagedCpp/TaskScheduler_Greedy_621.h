#pragma once

#include <vector>
#include "AbstractTaskScheduler_621.h"
#include <algorithm> 

class TaskScheduler_Greedy_621 : AbstractTaskScheduler_621 {
public:
    inline int leastInterval(std::vector<char>& tasks, int n) {
        std::vector<int> taskFrequencies(26, 0);
        for (const auto & task : tasks) {
            taskFrequencies[task - 'A']++;
        }

        std::sort(taskFrequencies.begin(), taskFrequencies.end());
        auto maxFrequency = taskFrequencies[25];
        auto idle = (maxFrequency * n) - n;

        for (int i = 24; i >= 0; i--) {
            idle -= std::min(maxFrequency - 1, taskFrequencies[i]);
        }
        return std::max(0, idle) + tasks.size();
    }
};
