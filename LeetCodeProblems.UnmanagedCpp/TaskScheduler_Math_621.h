#pragma once

#include <vector>
#include <utility>
#include <unordered_map>
#include "AbstractTaskScheduler_621.h"

class TaskScheduler_Math_621 : AbstractTaskScheduler_621 {
public:
    inline int leastInterval(std::vector<char>& tasks, int n) {
        auto [mostFrequentTaskCount, groupSize] = ComputeAggregates(tasks);

        auto completeCooldownCycleCount = mostFrequentTaskCount - 1;
        auto intervalLength = n + 1;
        int candidate = completeCooldownCycleCount * intervalLength + groupSize;

        return std::max(static_cast<int>(tasks.size()), candidate);
    }

private:
    inline std::pair<int, int> ComputeAggregates(std::vector<char>& tasks) {
        int mostFrequentTaskCount = 0;
        int groupSize = 0;

        std::vector<int> counts(26, 0);
        for (const auto& task : tasks) counts[task - 'A']++;

        for (const auto& count : counts) {
            if (count > mostFrequentTaskCount) { 
                mostFrequentTaskCount = count; 
                groupSize = 1;
            } else if (count == mostFrequentTaskCount && count > 0) {
                groupSize += 1;
            }
        }

        return std::make_pair(mostFrequentTaskCount, groupSize);
    }
};
