cmake_minimum_required(VERSION 3.14)
project(GrindingLeetcode LANGUAGES CXX)

# Set C++ standard
set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# Add subdirectories
add_subdirectory(LeetCodeProblems.UnmanagedCpp)
add_subdirectory(GrindingLeetcode.Unmanaged.UnitTests)
