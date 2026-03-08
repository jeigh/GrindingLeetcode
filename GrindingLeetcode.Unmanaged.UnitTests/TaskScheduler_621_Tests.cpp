#include "gtest/gtest.h"
#include "TaskScheduler_Math_621.h"
#include "TaskScheduler_Greedy_621.h"
#include "TaskScheduler_TwoQueues_621.h"

// Test fixture for TaskScheduler_Math_621
class TaskScheduler_Math_621_Tests : public ::testing::Test {
protected:
    TaskScheduler_Math_621 solution;
};

// Test fixture for TaskScheduler_Greedy_621
class TaskScheduler_Greedy_621_Tests : public ::testing::Test {
protected:
    TaskScheduler_Greedy_621 solution;
};

// Test fixture for TaskScheduler_TwoQueues_621
class TaskScheduler_TwoQueues_621_Tests : public ::testing::Test {
protected:
    TaskScheduler_TwoQueues_621 solution;
};

#pragma region LeetCode Examples - Math

// Example 1: tasks = ["A","A","A","B","B","B"], n = 2 -> 8
TEST_F(TaskScheduler_Math_621_Tests, LeastInterval_Example1_Returns8) {
    std::vector<char> tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
    ASSERT_EQ(8, solution.leastInterval(tasks, 2));
}

// Example 2: tasks = ["A","C","A","B","D","B"], n = 1 -> 6
TEST_F(TaskScheduler_Math_621_Tests, LeastInterval_Example2_Returns6) {
    std::vector<char> tasks = { 'A', 'C', 'A', 'B', 'D', 'B' };
    ASSERT_EQ(6, solution.leastInterval(tasks, 1));
}

// Example 3: tasks = ["A","A","A","B","B","B"], n = 0 -> 6
TEST_F(TaskScheduler_Math_621_Tests, LeastInterval_Example3_NoCooldown_Returns6) {
    std::vector<char> tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
    ASSERT_EQ(6, solution.leastInterval(tasks, 0));
}

TEST_F(TaskScheduler_Math_621_Tests, LeastInterval_SingleTask_Returns1) {
    std::vector<char> tasks = { 'A' };
    ASSERT_EQ(1, solution.leastInterval(tasks, 2));
}

TEST_F(TaskScheduler_Math_621_Tests, LeastInterval_AllSameTask_ReturnsWithIdleSlots) {
    // A _ _ A _ _ A -> 7
    std::vector<char> tasks = { 'A', 'A', 'A' };
    ASSERT_EQ(7, solution.leastInterval(tasks, 2));
}

TEST_F(TaskScheduler_Math_621_Tests, LeastInterval_AllDistinctTasks_ReturnsTaskCount) {
    std::vector<char> tasks = { 'A', 'B', 'C', 'D', 'E' };
    ASSERT_EQ(5, solution.leastInterval(tasks, 3));
}

TEST_F(TaskScheduler_Math_621_Tests, LeastInterval_MultipleMaxFrequencyTasks_ReturnsCorrectly) {
    // A B _ A B _ A B -> 8
    std::vector<char> tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
    ASSERT_EQ(8, solution.leastInterval(tasks, 2));
}

TEST_F(TaskScheduler_Math_621_Tests, LeastInterval_HighCooldownFewTasks_ReturnsWithIdle) {
    // A _ _ _ _ A -> 6
    std::vector<char> tasks = { 'A', 'A' };
    ASSERT_EQ(6, solution.leastInterval(tasks, 4));
}

#pragma endregion

#pragma region LeetCode Examples - Greedy

TEST_F(TaskScheduler_Greedy_621_Tests, LeastInterval_Example1_Returns8) {
    std::vector<char> tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
    ASSERT_EQ(8, solution.leastInterval(tasks, 2));
}

TEST_F(TaskScheduler_Greedy_621_Tests, LeastInterval_Example2_Returns6) {
    std::vector<char> tasks = { 'A', 'C', 'A', 'B', 'D', 'B' };
    ASSERT_EQ(6, solution.leastInterval(tasks, 1));
}

TEST_F(TaskScheduler_Greedy_621_Tests, LeastInterval_Example3_NoCooldown_Returns6) {
    std::vector<char> tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
    ASSERT_EQ(6, solution.leastInterval(tasks, 0));
}

TEST_F(TaskScheduler_Greedy_621_Tests, LeastInterval_SingleTask_Returns1) {
    std::vector<char> tasks = { 'A' };
    ASSERT_EQ(1, solution.leastInterval(tasks, 2));
}

TEST_F(TaskScheduler_Greedy_621_Tests, LeastInterval_AllSameTask_ReturnsWithIdleSlots) {
    std::vector<char> tasks = { 'A', 'A', 'A' };
    ASSERT_EQ(7, solution.leastInterval(tasks, 2));
}

TEST_F(TaskScheduler_Greedy_621_Tests, LeastInterval_AllDistinctTasks_ReturnsTaskCount) {
    std::vector<char> tasks = { 'A', 'B', 'C', 'D', 'E' };
    ASSERT_EQ(5, solution.leastInterval(tasks, 3));
}

TEST_F(TaskScheduler_Greedy_621_Tests, LeastInterval_MultipleMaxFrequencyTasks_ReturnsCorrectly) {
    std::vector<char> tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
    ASSERT_EQ(8, solution.leastInterval(tasks, 2));
}

TEST_F(TaskScheduler_Greedy_621_Tests, LeastInterval_HighCooldownFewTasks_ReturnsWithIdle) {
    std::vector<char> tasks = { 'A', 'A' };
    ASSERT_EQ(6, solution.leastInterval(tasks, 4));
}

#pragma endregion

#pragma region LeetCode Examples - TwoQueues

TEST_F(TaskScheduler_TwoQueues_621_Tests, LeastInterval_Example1_Returns8) {
    std::vector<char> tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
    ASSERT_EQ(8, solution.leastInterval(tasks, 2));
}

TEST_F(TaskScheduler_TwoQueues_621_Tests, LeastInterval_Example2_Returns6) {
    std::vector<char> tasks = { 'A', 'C', 'A', 'B', 'D', 'B' };
    ASSERT_EQ(6, solution.leastInterval(tasks, 1));
}

TEST_F(TaskScheduler_TwoQueues_621_Tests, LeastInterval_Example3_NoCooldown_Returns6) {
    std::vector<char> tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
    ASSERT_EQ(6, solution.leastInterval(tasks, 0));
}

TEST_F(TaskScheduler_TwoQueues_621_Tests, LeastInterval_SingleTask_Returns1) {
    std::vector<char> tasks = { 'A' };
    ASSERT_EQ(1, solution.leastInterval(tasks, 2));
}

TEST_F(TaskScheduler_TwoQueues_621_Tests, LeastInterval_AllSameTask_ReturnsWithIdleSlots) {
    std::vector<char> tasks = { 'A', 'A', 'A' };
    ASSERT_EQ(7, solution.leastInterval(tasks, 2));
}

TEST_F(TaskScheduler_TwoQueues_621_Tests, LeastInterval_AllDistinctTasks_ReturnsTaskCount) {
    std::vector<char> tasks = { 'A', 'B', 'C', 'D', 'E' };
    ASSERT_EQ(5, solution.leastInterval(tasks, 3));
}

TEST_F(TaskScheduler_TwoQueues_621_Tests, LeastInterval_MultipleMaxFrequencyTasks_ReturnsCorrectly) {
    std::vector<char> tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
    ASSERT_EQ(8, solution.leastInterval(tasks, 2));
}

TEST_F(TaskScheduler_TwoQueues_621_Tests, LeastInterval_HighCooldownFewTasks_ReturnsWithIdle) {
    std::vector<char> tasks = { 'A', 'A' };
    ASSERT_EQ(6, solution.leastInterval(tasks, 4));
}

#pragma endregion
