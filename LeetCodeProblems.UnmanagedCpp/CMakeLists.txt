cmake_minimum_required(VERSION 3.31)
project(LeetCodeProblems_UnmanagedCpp)

set(CMAKE_CXX_STANDARD 14)

include_directories(.)
include_directories(x64)
include_directories(x64/Debug)

add_executable(LeetCodeProblems_UnmanagedCpp
        x64/Debug/LeetCodeProblems.UnmanagedCpp.pch
        dllmain.cpp
        framework.h
        ListNode.h
        pch.cpp
        pch.h
        ReverseList.cpp
        ReverseList.h)
