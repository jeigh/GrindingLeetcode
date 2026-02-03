cmake_minimum_required(VERSION 3.14)

# Collect all header and source files
file(GLOB HEADER_FILES "${CMAKE_CURRENT_SOURCE_DIR}/*.h")
file(GLOB SOURCE_FILES "${CMAKE_CURRENT_SOURCE_DIR}/*.cpp")

# Create static library
add_library(LeetCodeProblems.UnmanagedCpp STATIC
    ${HEADER_FILES}
    ${SOURCE_FILES}
)

# Set as header-only library
set_target_properties(LeetCodeProblems.UnmanagedCpp PROPERTIES LINKER_LANGUAGE CXX)

# Include directories
target_include_directories(LeetCodeProblems.UnmanagedCpp PUBLIC
    ${CMAKE_CURRENT_SOURCE_DIR}
)

# Set C++ standard
target_compile_features(LeetCodeProblems.UnmanagedCpp PUBLIC cxx_std_20)

# Platform-specific settings
if(MSVC)
    target_compile_options(LeetCodeProblems.UnmanagedCpp PRIVATE /W3)
else()
    target_compile_options(LeetCodeProblems.UnmanagedCpp PRIVATE -Wall -Wextra)
endif()
