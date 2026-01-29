#include "gtest/gtest.h"
#include "QuadNode.h"
#include "ConstructQuadTree_Recursive_427.h"
#include "ConstructQuadTree_Recursive_Optimized_427.h"
#include <vector>
#include <set>

// QuadTree-specific helper functions
namespace QuadTreeHelpers {
    // Forward declaration of helper function
    void FreeQuadTreeHelper(QuadNode* node, std::set<QuadNode*>& visited);

    /// <summary>
    /// Frees all nodes in a quad tree (post-order traversal)
    /// Tracks visited nodes to avoid double-free of shared nodes
    /// </summary>
    inline void FreeQuadTree(QuadNode* root) {
        if (root == nullptr) return;
        
        std::set<QuadNode*> visited;
        FreeQuadTreeHelper(root, visited);
    }
    
    inline void FreeQuadTreeHelper(QuadNode* node, std::set<QuadNode*>& visited) {
        if (node == nullptr || visited.count(node) > 0) return;
        
        visited.insert(node);
        
        if (!node->isLeaf) {
            FreeQuadTreeHelper(node->topLeft, visited);
            FreeQuadTreeHelper(node->topRight, visited);
            FreeQuadTreeHelper(node->bottomLeft, visited);
            FreeQuadTreeHelper(node->bottomRight, visited);
        }
        
        delete node;
    }

    /// <summary>
    /// Verifies that a quad tree node matches expected structure
    /// </summary>
    inline void AssertNodeEquals(bool expectedVal, bool expectedIsLeaf, QuadNode* actual) {
        ASSERT_NE(nullptr, actual);
        ASSERT_EQ(expectedIsLeaf, actual->isLeaf);
        if (expectedIsLeaf) {
            ASSERT_EQ(expectedVal, actual->val);
        }
    }

    /// <summary>
    /// Creates a 2D grid from initializer list
    /// </summary>
    inline std::vector<std::vector<int>> CreateGrid(std::initializer_list<std::initializer_list<int>> rows) {
        std::vector<std::vector<int>> grid;
        for (const auto& row : rows) {
            grid.push_back(std::vector<int>(row));
        }
        return grid;
    }
}

using namespace QuadTreeHelpers;

// Test fixture for ConstructQuadTree_Recursive_427
class ConstructQuadTree_Recursive_427_Tests : public ::testing::Test {
protected:
    ConstructQuadTree_Recursive_427 solution;
};

// Test fixture for ConstructQuadTree_Recursive_Optimized_427
class ConstructQuadTree_Recursive_Optimized_427_Tests : public ::testing::Test {
protected:
    ConstructQuadTree_Recursive_Optimized_427 solution;
};

// Macro to define the same test for both implementations
#define DEFINE_TEST_FOR_BOTH(TestName, TestBody) \
    TEST_F(ConstructQuadTree_Recursive_427_Tests, TestName) TestBody \
    TEST_F(ConstructQuadTree_Recursive_Optimized_427_Tests, TestName) TestBody

#pragma region LeetCode Examples

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_Example1_4x4Grid_ReturnsCorrectTree, {
    // Input: grid = [[0,1],[1,0]]
    // Output: [[0,1],[1,0],[1,1],[1,1],[1,0]]
    // Explanation: The grid is divided into 4 sub-grids
    // topLeft = [0] -> leaf node with value 0
    // topRight = [1] -> leaf node with value 1
    // bottomLeft = [1] -> leaf node with value 1
    // bottomRight = [0] -> leaf node with value 0

    // Arrange
    auto grid = CreateGrid({{0, 1}, {1, 0}});

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);
    AssertNodeEquals(false, true, result->topLeft);
    AssertNodeEquals(true, true, result->topRight);
    AssertNodeEquals(true, true, result->bottomLeft);
    AssertNodeEquals(false, true, result->bottomRight);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_Example2_8x8ComplexGrid_ReturnsCorrectTree, {
    // Input: grid = [[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,1],
    //                [1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0]]
    // This should create a complex nested structure

    // Arrange
    auto grid = CreateGrid({
        {1,1,1,1,0,0,0,0},
        {1,1,1,1,0,0,0,0},
        {1,1,1,1,1,1,1,1},
        {1,1,1,1,1,1,1,1},
        {1,1,1,1,0,0,0,0},
        {1,1,1,1,0,0,0,0},
        {1,1,1,1,0,0,0,0},
        {1,1,1,1,0,0,0,0}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);
    
    // Top left should be all 1s
    AssertNodeEquals(true, true, result->topLeft);
    
    // Top right should be subdivided
    ASSERT_NE(nullptr, result->topRight);
    ASSERT_FALSE(result->topRight->isLeaf);

    // Cleanup
    FreeQuadTree(result);
})

#pragma endregion

#pragma region Uniform Grids (Leaf Nodes)

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_UniformGrid_AllZeros_ReturnsLeafNode, {
    // Input: grid = [[0,0],[0,0]]
    // Output: Single leaf node with value false

    // Arrange
    auto grid = CreateGrid({{0, 0}, {0, 0}});

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    AssertNodeEquals(false, true, result);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_UniformGrid_AllOnes_ReturnsLeafNode, {
    // Input: grid = [[1,1],[1,1]]
    // Output: Single leaf node with value true

    // Arrange
    auto grid = CreateGrid({{1, 1}, {1, 1}});

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    AssertNodeEquals(true, true, result);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_UniformGrid_4x4AllZeros_ReturnsLeafNode, {
    // Input: grid = [[0,0,0,0],[0,0,0,0],[0,0,0,0],[0,0,0,0]]
    // Output: Single leaf node with value false

    // Arrange
    auto grid = CreateGrid({
        {0, 0, 0, 0},
        {0, 0, 0, 0},
        {0, 0, 0, 0},
        {0, 0, 0, 0}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    AssertNodeEquals(false, true, result);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_UniformGrid_4x4AllOnes_ReturnsLeafNode, {
    // Input: grid = [[1,1,1,1],[1,1,1,1],[1,1,1,1],[1,1,1,1]]
    // Output: Single leaf node with value true

    // Arrange
    auto grid = CreateGrid({
        {1, 1, 1, 1},
        {1, 1, 1, 1},
        {1, 1, 1, 1},
        {1, 1, 1, 1}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    AssertNodeEquals(true, true, result);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_UniformGrid_8x8AllOnes_ReturnsLeafNode, {
    // Input: 8x8 grid all 1s
    // Output: Single leaf node with value true

    // Arrange
    auto grid = CreateGrid({
        {1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    AssertNodeEquals(true, true, result);

    // Cleanup
    FreeQuadTree(result);
})

#pragma endregion

#pragma region Simple Subdivisions

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_2x2_CheckerboardPattern_ReturnsFourLeaves, {
    // Input: grid = [[0,1],[1,0]]
    // Output: Non-leaf with 4 leaf children

    // Arrange
    auto grid = CreateGrid({{0, 1}, {1, 0}});

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);
    AssertNodeEquals(false, true, result->topLeft);
    AssertNodeEquals(true, true, result->topRight);
    AssertNodeEquals(true, true, result->bottomLeft);
    AssertNodeEquals(false, true, result->bottomRight);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_2x2_ReverseCheckerboard_ReturnsFourLeaves, {
    // Input: grid = [[1,0],[0,1]]
    // Output: Non-leaf with 4 leaf children

    // Arrange
    auto grid = CreateGrid({{1, 0}, {0, 1}});

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);
    AssertNodeEquals(true, true, result->topLeft);
    AssertNodeEquals(false, true, result->topRight);
    AssertNodeEquals(false, true, result->bottomLeft);
    AssertNodeEquals(true, true, result->bottomRight);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_2x2_ThreeOnesOneZero_ReturnsFourLeaves, {
    // Input: grid = [[1,1],[1,0]]
    // Output: Non-leaf with 4 leaf children

    // Arrange
    auto grid = CreateGrid({{1, 1}, {1, 0}});

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);
    AssertNodeEquals(true, true, result->topLeft);
    AssertNodeEquals(true, true, result->topRight);
    AssertNodeEquals(true, true, result->bottomLeft);
    AssertNodeEquals(false, true, result->bottomRight);

    // Cleanup
    FreeQuadTree(result);
})

#pragma endregion

#pragma region 4x4 Grids

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_4x4_TopHalfOnes_BottomHalfZeros_ReturnsCorrectTree, {
    // Input: grid = [[1,1,1,1],[1,1,1,1],[0,0,0,0],[0,0,0,0]]
    // Output: Non-leaf with topLeft=1, topRight=1, bottomLeft=0, bottomRight=0

    // Arrange
    auto grid = CreateGrid({
        {1, 1, 1, 1},
        {1, 1, 1, 1},
        {0, 0, 0, 0},
        {0, 0, 0, 0}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);
    AssertNodeEquals(true, true, result->topLeft);
    AssertNodeEquals(true, true, result->topRight);
    AssertNodeEquals(false, true, result->bottomLeft);
    AssertNodeEquals(false, true, result->bottomRight);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_4x4_LeftHalfOnes_RightHalfZeros_ReturnsCorrectTree, {
    // Input: grid = [[1,1,0,0],[1,1,0,0],[1,1,0,0],[1,1,0,0]]
    // Output: Non-leaf with topLeft=1, topRight=0, bottomLeft=1, bottomRight=0

    // Arrange
    auto grid = CreateGrid({
        {1, 1, 0, 0},
        {1, 1, 0, 0},
        {1, 1, 0, 0},
        {1, 1, 0, 0}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);
    AssertNodeEquals(true, true, result->topLeft);
    AssertNodeEquals(false, true, result->topRight);
    AssertNodeEquals(true, true, result->bottomLeft);
    AssertNodeEquals(false, true, result->bottomRight);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_4x4_Checkerboard2x2Blocks_ReturnsCorrectTree, {
    // Input: grid = [[0,0,1,1],[0,0,1,1],[1,1,0,0],[1,1,0,0]]
    // Output: Non-leaf with topLeft=0, topRight=1, bottomLeft=1, bottomRight=0

    // Arrange
    auto grid = CreateGrid({
        {0, 0, 1, 1},
        {0, 0, 1, 1},
        {1, 1, 0, 0},
        {1, 1, 0, 0}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);
    AssertNodeEquals(false, true, result->topLeft);
    AssertNodeEquals(true, true, result->topRight);
    AssertNodeEquals(true, true, result->bottomLeft);
    AssertNodeEquals(false, true, result->bottomRight);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_4x4_ComplexPattern_ReturnsNestedTree, {
    // Input: grid = [[1,1,0,0],[1,0,0,0],[0,0,1,1],[0,0,1,1]]
    // Output: Nested tree structure

    // Arrange
    auto grid = CreateGrid({
        {1, 1, 0, 0},
        {1, 0, 0, 0},
        {0, 0, 1, 1},
        {0, 0, 1, 1}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);
    
    // Top left should be subdivided
    ASSERT_NE(nullptr, result->topLeft);
    ASSERT_FALSE(result->topLeft->isLeaf);
    
    // Top right should be uniform 0
    AssertNodeEquals(false, true, result->topRight);
    
    // Bottom left should be uniform 0
    AssertNodeEquals(false, true, result->bottomLeft);
    
    // Bottom right should be uniform 1
    AssertNodeEquals(true, true, result->bottomRight);

    // Cleanup
    FreeQuadTree(result);
})

#pragma endregion

#pragma region 8x8 Grids

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_8x8_AllQuadrantsUniform_ReturnsSimpleTree, {
    // Input: Each quadrant is uniform
    // Top-left: all 1s, Top-right: all 0s
    // Bottom-left: all 0s, Bottom-right: all 1s

    // Arrange
    auto grid = CreateGrid({
        {1, 1, 1, 1, 0, 0, 0, 0},
        {1, 1, 1, 1, 0, 0, 0, 0},
        {1, 1, 1, 1, 0, 0, 0, 0},
        {1, 1, 1, 1, 0, 0, 0, 0},
        {0, 0, 0, 0, 1, 1, 1, 1},
        {0, 0, 0, 0, 1, 1, 1, 1},
        {0, 0, 0, 0, 1, 1, 1, 1},
        {0, 0, 0, 0, 1, 1, 1, 1}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);
    AssertNodeEquals(true, true, result->topLeft);
    AssertNodeEquals(false, true, result->topRight);
    AssertNodeEquals(false, true, result->bottomLeft);
    AssertNodeEquals(true, true, result->bottomRight);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_8x8_NestedSubdivisions_ReturnsComplexTree, {
    // Input: Complex pattern requiring multiple levels of subdivision

    // Arrange
    auto grid = CreateGrid({
        {1, 1, 0, 0, 1, 1, 1, 1},
        {1, 1, 0, 0, 1, 1, 1, 1},
        {0, 0, 1, 1, 1, 1, 1, 1},
        {0, 0, 1, 1, 1, 1, 1, 1},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);
    
    // Top left should be subdivided
    ASSERT_NE(nullptr, result->topLeft);
    ASSERT_FALSE(result->topLeft->isLeaf);
    
    // Top right should be uniform 1
    AssertNodeEquals(true, true, result->topRight);
    
    // Bottom left should be uniform 0
    AssertNodeEquals(false, true, result->bottomLeft);
    
    // Bottom right should be uniform 0
    AssertNodeEquals(false, true, result->bottomRight);

    // Cleanup
    FreeQuadTree(result);
})

#pragma endregion

#pragma region Edge Cases

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_SingleCell_Zero_ReturnsLeafNode, {
    // Input: grid = [[0]]
    // Output: Single leaf node with value false

    // Arrange
    auto grid = CreateGrid({{0}});

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    AssertNodeEquals(false, true, result);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_SingleCell_One_ReturnsLeafNode, {
    // Input: grid = [[1]]
    // Output: Single leaf node with value true

    // Arrange
    auto grid = CreateGrid({{1}});

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    AssertNodeEquals(true, true, result);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_16x16_AllOnes_ReturnsLeafNode, {
    // Large uniform grid should still return a single leaf

    // Arrange
    std::vector<std::vector<int>> grid(16, std::vector<int>(16, 1));

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    AssertNodeEquals(true, true, result);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_16x16_ComplexPattern_ReturnsComplexTree, {
    // Large grid with complex pattern

    // Arrange
    std::vector<std::vector<int>> grid(16, std::vector<int>(16, 0));
    // Fill top-left 8x8 with 1s
    for (int i = 0; i < 8; i++) {
        for (int j = 0; j < 8; j++) {
            grid[i][j] = 1;
        }
    }
    // Fill bottom-right 8x8 with 1s
    for (int i = 8; i < 16; i++) {
        for (int j = 8; j < 16; j++) {
            grid[i][j] = 1;
        }
    }

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);
    AssertNodeEquals(true, true, result->topLeft);
    AssertNodeEquals(false, true, result->topRight);
    AssertNodeEquals(false, true, result->bottomLeft);
    AssertNodeEquals(true, true, result->bottomRight);

    // Cleanup
    FreeQuadTree(result);
})

#pragma endregion

#pragma region Border Patterns

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_4x4_BorderOnes_CenterZeros_ReturnsComplexTree, {
    // Input: Border is 1s, center is 0s
    // grid = [[1,1,1,1],[1,0,0,1],[1,0,0,1],[1,1,1,1]]

    // Arrange
    auto grid = CreateGrid({
        {1, 1, 1, 1},
        {1, 0, 0, 1},
        {1, 0, 0, 1},
        {1, 1, 1, 1}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_4x4_CornerOnes_RestZeros_ReturnsComplexTree, {
    // Input: Only corners are 1s
    // grid = [[1,0,0,1],[0,0,0,0],[0,0,0,0],[1,0,0,1]]

    // Arrange
    auto grid = CreateGrid({
        {1, 0, 0, 1},
        {0, 0, 0, 0},
        {0, 0, 0, 0},
        {1, 0, 0, 1}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);

    // Cleanup
    FreeQuadTree(result);
})

#pragma endregion

#pragma region Diagonal Patterns

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_4x4_DiagonalPattern_ReturnsComplexTree, {
    // Input: Diagonal pattern
    // grid = [[1,0,0,0],[0,1,0,0],[0,0,1,0],[0,0,0,1]]

    // Arrange
    auto grid = CreateGrid({
        {1, 0, 0, 0},
        {0, 1, 0, 0},
        {0, 0, 1, 0},
        {0, 0, 0, 1}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_8x8_AntiDiagonalPattern_ReturnsComplexTree, {
    // Input: Anti-diagonal pattern (top-right to bottom-left)

    // Arrange
    auto grid = CreateGrid({
        {0, 0, 0, 0, 0, 0, 0, 1},
        {0, 0, 0, 0, 0, 0, 1, 0},
        {0, 0, 0, 0, 0, 1, 0, 0},
        {0, 0, 0, 0, 1, 0, 0, 0},
        {0, 0, 0, 1, 0, 0, 0, 0},
        {0, 0, 1, 0, 0, 0, 0, 0},
        {0, 1, 0, 0, 0, 0, 0, 0},
        {1, 0, 0, 0, 0, 0, 0, 0}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);

    // Cleanup
    FreeQuadTree(result);
})

#pragma endregion

#pragma region Striped Patterns

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_4x4_HorizontalStripes_ReturnsComplexTree, {
    // Input: Horizontal stripes (alternating rows)
    // grid = [[1,1,1,1],[0,0,0,0],[1,1,1,1],[0,0,0,0]]

    // Arrange
    auto grid = CreateGrid({
        {1, 1, 1, 1},
        {0, 0, 0, 0},
        {1, 1, 1, 1},
        {0, 0, 0, 0}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);

    // Cleanup
    FreeQuadTree(result);
})

DEFINE_TEST_FOR_BOTH(ConstructQuadTree_4x4_VerticalStripes_ReturnsComplexTree, {
    // Input: Vertical stripes (alternating columns)
    // grid = [[1,0,1,0],[1,0,1,0],[1,0,1,0],[1,0,1,0]]

    // Arrange
    auto grid = CreateGrid({
        {1, 0, 1, 0},
        {1, 0, 1, 0},
        {1, 0, 1, 0},
        {1, 0, 1, 0}
    });

    // Act
    QuadNode* result = solution.construct(grid);

    // Assert
    ASSERT_NE(nullptr, result);
    ASSERT_FALSE(result->isLeaf);

    // Cleanup
    FreeQuadTree(result);
})

#pragma endregion
