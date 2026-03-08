#pragma once

#include <vector>
#include "AbstractTaskScheduler_621.h"
#include <unordered_map>
#include <queue>

class TaskScheduler_TwoQueues_621 : AbstractTaskScheduler_621 {
public:
    inline int leastInterval(std::vector<char>& tasks, int n) {
        std::vector<int> counts(26, 0);
        for (auto task : tasks) counts[task-'A']++;
        
        std::priority_queue<int> maxHeap;
        for (int i = 0; i < counts.size(); i++)  
            if (counts[i] > 0) maxHeap.emplace(counts[i]);

        int time = 0;
        std::queue<std::pair<int, int>> fifo;
        while (!maxHeap.empty() || !fifo.empty()) 
        {
            if (!fifo.empty() && time >= fifo.front().second) 
            {
                auto top = fifo.front();
                maxHeap.emplace(top.first);
                fifo.pop();
            }

            if (!maxHeap.empty())
            {
                int newCount = maxHeap.top() - 1;
                maxHeap.pop();
                if (newCount > 0) fifo.emplace(newCount, time + n + 1);
            }
            time++;
        }

        return time;
    }
};
