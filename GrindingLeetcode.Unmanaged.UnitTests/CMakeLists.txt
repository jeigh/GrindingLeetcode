cmake_minimum_required(VERSION 3.14)

# Fetch Google Test
include(FetchContent)
FetchContent_Declare(
    googletest
    GIT_REPOSITORY https://github.com/google/googletest.git
    GIT_TAG v1.14.0
)
# For Windows: Prevent overriding the parent project's compiler/linker settings
set(gtest_force_shared_crt ON CACHE BOOL "" FORCE)
FetchContent_MakeAvailable(googletest)

# Enable testing
enable_testing()

# Collect all header and source files
file(GLOB HEADER_FILES "${CMAKE_CURRENT_SOURCE_DIR}/*.h")
file(GLOB SOURCE_FILES "${CMAKE_CURRENT_SOURCE_DIR}/*.cpp")

# Create test executable
add_executable(GrindingLeetcode.Unmanaged.UnitTests
    ${HEADER_FILES}
    ${SOURCE_FILES}
)

# Link libraries
target_link_libraries(GrindingLeetcode.Unmanaged.UnitTests PRIVATE
    LeetCodeProblems.UnmanagedCpp
    GTest::gtest
    GTest::gtest_main
)

# Include directories
target_include_directories(GrindingLeetcode.Unmanaged.UnitTests PRIVATE
    ${CMAKE_CURRENT_SOURCE_DIR}/../LeetCodeProblems.UnmanagedCpp
)

# Set C++ standard
target_compile_features(GrindingLeetcode.Unmanaged.UnitTests PRIVATE cxx_std_20)

# Platform-specific settings
if(MSVC)
    target_compile_options(GrindingLeetcode.Unmanaged.UnitTests PRIVATE /W3)
    target_compile_definitions(GrindingLeetcode.Unmanaged.UnitTests PRIVATE
        _DEBUG
        _CONSOLE
    )
else()
    target_compile_options(GrindingLeetcode.Unmanaged.UnitTests PRIVATE -Wall -Wextra)
endif()

# Discover tests for CTest
include(GoogleTest)
gtest_discover_tests(GrindingLeetcode.Unmanaged.UnitTests)
