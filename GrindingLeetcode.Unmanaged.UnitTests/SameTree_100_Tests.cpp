#include "gtest/gtest.h"
#include "TreeNode.h"
#include "SameTree_Stack_100.h"
#include <queue>

// Tree-specific helper functions
namespace TreeHelpers {
    /// <summary>
    /// Creates a binary tree from a level-order array (with nulls represented as special values)
    /// Use -1001 to represent null nodes (outside typical LeetCode constraint range)
    /// </summary>
    inline TreeNode* CreateTree(std::initializer_list<int> values) {
        if (values.size() == 0) return nullptr;
        
        std::vector<int> vec(values);
        if (vec[0] == -1001) return nullptr;
        
        TreeNode* root = new TreeNode(vec[0]);
        std::queue<TreeNode*> queue;
        queue.push(root);
        int index = 1;
        
        while (!queue.empty() && index < vec.size()) {
            TreeNode* current = queue.front();
            queue.pop();
            
            // Left child
            if (index < vec.size() && vec[index] != -1001) {
                current->left = new TreeNode(vec[index]);
                queue.push(current->left);
            }
            index++;
            
            // Right child
            if (index < vec.size() && vec[index] != -1001) {
                current->right = new TreeNode(vec[index]);
                queue.push(current->right);
            }
            index++;
        }
        
        return root;
    }

    /// <summary>
    /// Frees all nodes in a binary tree (post-order traversal)
    /// </summary>
    inline void FreeTree(TreeNode* root) {
        if (root == nullptr) return;
        FreeTree(root->left);
        FreeTree(root->right);
        delete root;
    }

    /// <summary>
    /// Creates a simple tree with root and optional left/right children
    /// </summary>
    inline TreeNode* CreateSimpleTree(int rootVal, int leftVal = -1001, int rightVal = -1001) {
        TreeNode* root = new TreeNode(rootVal);
        if (leftVal != -1001) {
            root->left = new TreeNode(leftVal);
        }
        if (rightVal != -1001) {
            root->right = new TreeNode(rightVal);
        }
        return root;
    }
}

using namespace TreeHelpers;

// Test fixture for SameTree_Stack_100
class SameTree_Stack_100_Tests : public ::testing::Test {
protected:
    SameTree_Stack_100 solution;

    void TearDown() override {
        // Cleanup is handled by FreeTree in each test
    }
};

#pragma region LeetCode Examples

TEST_F(SameTree_Stack_100_Tests, IsSameTree_Example1_ReturnsTrue) {
    // Input: p = [1,2,3], q = [1,2,3]
    //    1         1
    //   / \       / \
    //  2   3     2   3
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ 1, 2, 3 });
    TreeNode* q = CreateTree({ 1, 2, 3 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_Example2_ReturnsFalse) {
    // Input: p = [1,2], q = [1,null,2]
    //    1         1
    //   /           \
    //  2             2
    // Output: false

    // Arrange
    TreeNode* p = CreateTree({ 1, 2 });
    TreeNode* q = CreateTree({ 1, -1001, 2 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_Example3_ReturnsFalse) {
    // Input: p = [1,2,1], q = [1,1,2]
    //    1         1
    //   / \       / \
    //  2   1     1   2
    // Output: false

    // Arrange
    TreeNode* p = CreateTree({ 1, 2, 1 });
    TreeNode* q = CreateTree({ 1, 1, 2 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

#pragma endregion

#pragma region Basic Tree Structures

TEST_F(SameTree_Stack_100_Tests, IsSameTree_BothNull_ReturnsTrue) {
    // Input: p = [], q = []
    // Output: true

    // Arrange
    TreeNode* p = nullptr;
    TreeNode* q = nullptr;

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_OneNullOneNot_ReturnsFalse) {
    // Input: p = [], q = [1]
    // Output: false

    // Arrange
    TreeNode* p = nullptr;
    TreeNode* q = new TreeNode(1);

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_SecondNullFirstNot_ReturnsFalse) {
    // Input: p = [1], q = []
    // Output: false

    // Arrange
    TreeNode* p = new TreeNode(1);
    TreeNode* q = nullptr;

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_SingleNodeSame_ReturnsTrue) {
    // Input: p = [1], q = [1]
    // Output: true

    // Arrange
    TreeNode* p = new TreeNode(1);
    TreeNode* q = new TreeNode(1);

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_SingleNodeDifferent_ReturnsFalse) {
    // Input: p = [1], q = [2]
    // Output: false

    // Arrange
    TreeNode* p = new TreeNode(1);
    TreeNode* q = new TreeNode(2);

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_TwoNodesSame_ReturnsTrue) {
    // Input: p = [1,2], q = [1,2]
    //    1         1
    //   /         /
    //  2         2
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ 1, 2 });
    TreeNode* q = CreateTree({ 1, 2 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_ThreeNodesSame_ReturnsTrue) {
    // Input: p = [2,1,3], q = [2,1,3]
    //    2         2
    //   / \       / \
    //  1   3     1   3
    // Output: true

    // Arrange
    TreeNode* p = CreateSimpleTree(2, 1, 3);
    TreeNode* q = CreateSimpleTree(2, 1, 3);

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

#pragma endregion

#pragma region Different Structures

TEST_F(SameTree_Stack_100_Tests, IsSameTree_DifferentStructure_LeftVsRight_ReturnsFalse) {
    // Input: p = [1,2,null], q = [1,null,2]
    //    1         1
    //   /           \
    //  2             2
    // Output: false

    // Arrange
    TreeNode* p = CreateTree({ 1, 2, -1001 });
    TreeNode* q = CreateTree({ 1, -1001, 2 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_DifferentHeight_ReturnsFalse) {
    // Input: p = [1,2,3], q = [1,2,3,4]
    //    1           1
    //   / \         / \
    //  2   3       2   3
    //             /
    //            4
    // Output: false

    // Arrange
    TreeNode* p = CreateTree({ 1, 2, 3 });
    TreeNode* q = CreateTree({ 1, 2, 3, 4 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_MissingLeftChild_ReturnsFalse) {
    // Input: p = [1,null,2], q = [1,2,2]
    //    1         1
    //     \       / \
    //      2     2   2
    // Output: false

    // Arrange
    TreeNode* p = CreateTree({ 1, -1001, 2 });
    TreeNode* q = CreateTree({ 1, 2, 2 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_MissingRightChild_ReturnsFalse) {
    // Input: p = [1,2,null], q = [1,2,2]
    //    1         1
    //   /         / \
    //  2         2   2
    // Output: false

    // Arrange
    TreeNode* p = CreateTree({ 1, 2, -1001 });
    TreeNode* q = CreateTree({ 1, 2, 2 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

#pragma endregion

#pragma region Different Values - Same Structure

TEST_F(SameTree_Stack_100_Tests, IsSameTree_DifferentRootValues_ReturnsFalse) {
    // Input: p = [1,2,3], q = [2,2,3]
    //    1         2
    //   / \       / \
    //  2   3     2   3
    // Output: false

    // Arrange
    TreeNode* p = CreateSimpleTree(1, 2, 3);
    TreeNode* q = CreateSimpleTree(2, 2, 3);

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_DifferentLeftChildValue_ReturnsFalse) {
    // Input: p = [1,2,3], q = [1,4,3]
    //    1         1
    //   / \       / \
    //  2   3     4   3
    // Output: false

    // Arrange
    TreeNode* p = CreateSimpleTree(1, 2, 3);
    TreeNode* q = CreateSimpleTree(1, 4, 3);

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_DifferentRightChildValue_ReturnsFalse) {
    // Input: p = [1,2,3], q = [1,2,5]
    //    1         1
    //   / \       / \
    //  2   3     2   5
    // Output: false

    // Arrange
    TreeNode* p = CreateSimpleTree(1, 2, 3);
    TreeNode* q = CreateSimpleTree(1, 2, 5);

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_DifferentDeepValue_ReturnsFalse) {
    // Input: p = [1,2,3,4,5,6,7], q = [1,2,3,4,5,6,8]
    //        1                 1
    //       / \               / \
    //      2   3             2   3
    //     / \ / \           / \ / \
    //    4  5 6  7         4  5 6  8
    // Output: false (different value at rightmost leaf)

    // Arrange
    TreeNode* p = CreateTree({ 1, 2, 3, 4, 5, 6, 7 });
    TreeNode* q = CreateTree({ 1, 2, 3, 4, 5, 6, 8 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

#pragma endregion

#pragma region Identical Trees - Various Structures

TEST_F(SameTree_Stack_100_Tests, IsSameTree_IdenticalBalanced7Nodes_ReturnsTrue) {
    // Input: p = [4,2,6,1,3,5,7], q = [4,2,6,1,3,5,7]
    //        4                 4
    //       / \               / \
    //      2   6             2   6
    //     / \ / \           / \ / \
    //    1  3 5  7         1  3 5  7
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ 4, 2, 6, 1, 3, 5, 7 });
    TreeNode* q = CreateTree({ 4, 2, 6, 1, 3, 5, 7 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_IdenticalBalanced15Nodes_ReturnsTrue) {
    // Perfect binary tree with 15 nodes
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
    TreeNode* q = CreateTree({ 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_IdenticalLeftSkewed_ReturnsTrue) {
    // Input: p = [5,4,null,3,null,2,null,1], q = [5,4,null,3,null,2,null,1]
    //      5            5
    //     /            /
    //    4            4
    //   /            /
    //  3            3
    // /            /
    //2            2
    ///            /
    //1            1
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ 5, 4, -1001, 3, -1001, 2, -1001, 1 });
    TreeNode* q = CreateTree({ 5, 4, -1001, 3, -1001, 2, -1001, 1 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_IdenticalRightSkewed_ReturnsTrue) {
    // Input: p = [1,null,2,null,3,null,4,null,5], q = [1,null,2,null,3,null,4,null,5]
    // 1            1
    //  \            \
    //   2            2
    //    \            \
    //     3            3
    //      \            \
    //       4            4
    //        \            \
    //         5            5
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ 1, -1001, 2, -1001, 3, -1001, 4, -1001, 5 });
    TreeNode* q = CreateTree({ 1, -1001, 2, -1001, 3, -1001, 4, -1001, 5 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_IdenticalSparseTree_ReturnsTrue) {
    // Input: p = [8,4,12,null,6,10], q = [8,4,12,null,6,10]
    //     8            8
    //    / \          / \
    //   4   12       4   12
    //    \ /          \ /
    //     6 10         6 10
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ 8, 4, 12, -1001, 6, 10 });
    TreeNode* q = CreateTree({ 8, 4, 12, -1001, 6, 10 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

#pragma endregion

#pragma region Edge Cases - Values

TEST_F(SameTree_Stack_100_Tests, IsSameTree_NegativeValues_ReturnsTrue) {
    // Input: p = [0,-2,2,-3,-1,1,3], q = [0,-2,2,-3,-1,1,3]
    //        0                 0
    //       / \               / \
    //     -2   2            -2   2
    //     / \ / \           / \ / \
    //   -3 -1 1  3        -3 -1 1  3
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ 0, -2, 2, -3, -1, 1, 3 });
    TreeNode* q = CreateTree({ 0, -2, 2, -3, -1, 1, 3 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_AllNegativeValues_ReturnsTrue) {
    // Input: p = [-4,-6,-2,-7,-5,-3,-1], q = [-4,-6,-2,-7,-5,-3,-1]
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ -4, -6, -2, -7, -5, -3, -1 });
    TreeNode* q = CreateTree({ -4, -6, -2, -7, -5, -3, -1 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_DuplicateValues_ReturnsTrue) {
    // Input: p = [5,5,5,5,5], q = [5,5,5,5,5]
    //      5            5
    //     / \          / \
    //    5   5        5   5
    //   / \          / \
    //  5   5        5   5
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ 5, 5, 5, 5, 5 });
    TreeNode* q = CreateTree({ 5, 5, 5, 5, 5 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_AllZeros_ReturnsTrue) {
    // Input: p = [0,0,0], q = [0,0,0]
    //      0            0
    //     / \          / \
    //    0   0        0   0
    // Output: true

    // Arrange
    TreeNode* p = CreateSimpleTree(0, 0, 0);
    TreeNode* q = CreateSimpleTree(0, 0, 0);

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_LargeValues_ReturnsTrue) {
    // Input: p = [10000,-10000,10000], q = [10000,-10000,10000]
    // Output: true

    // Arrange
    TreeNode* p = CreateSimpleTree(10000, -10000, 10000);
    TreeNode* q = CreateSimpleTree(10000, -10000, 10000);

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_DifferentNegativeValues_ReturnsFalse) {
    // Input: p = [-1,-2,-3], q = [-1,-2,-4]
    // Output: false

    // Arrange
    TreeNode* p = CreateSimpleTree(-1, -2, -3);
    TreeNode* q = CreateSimpleTree(-1, -2, -4);

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

#pragma endregion

#pragma region Complex Trees

TEST_F(SameTree_Stack_100_Tests, IsSameTree_ComplexIdentical_ReturnsTrue) {
    // Input: p = [10,5,15,3,7,null,20,1,4,null,9], q = [10,5,15,3,7,null,20,1,4,null,9]
    //           10                     10
    //          /  \                   /  \
    //         5    15                5    15
    //        / \     \              / \     \
    //       3   7     20           3   7     20
    //      / \   \                / \   \
    //     1   4   9              1   4   9
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ 10, 5, 15, 3, 7, -1001, 20, 1, 4, -1001, 9 });
    TreeNode* q = CreateTree({ 10, 5, 15, 3, 7, -1001, 20, 1, 4, -1001, 9 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_ComplexDifferent_ReturnsFalse) {
    // Input: p = [10,5,15,3,7,null,20,1,4,null,9], q = [10,5,15,3,7,null,20,1,4,null,8]
    // Output: false (different deepest value: 9 vs 8)

    // Arrange
    TreeNode* p = CreateTree({ 10, 5, 15, 3, 7, -1001, 20, 1, 4, -1001, 9 });
    TreeNode* q = CreateTree({ 10, 5, 15, 3, 7, -1001, 20, 1, 4, -1001, 8 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_ZigZagPattern_ReturnsFalse) {
    // Input: p = [1,null,2,3], q = [1,2,null,null,3]
    //    1            1
    //     \          /
    //      2        2
    //     /          \
    //    3            3
    // Output: false (different structure)

    // Arrange
    TreeNode* p = CreateTree({ 1, -1001, 2, 3 });
    TreeNode* q = CreateTree({ 1, 2, -1001, -1001, 3 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

#pragma endregion

#pragma region Larger Trees

TEST_F(SameTree_Stack_100_Tests, IsSameTree_LargeIdentical31Nodes_ReturnsTrue) {
    // Perfect binary tree with 5 levels (31 nodes)
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ 
        16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
        1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
    });
    TreeNode* q = CreateTree({ 
        16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
        1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
    });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_LargeDifferent31Nodes_ReturnsFalse) {
    // Perfect binary tree with 5 levels, one node different
    // Output: false

    // Arrange
    TreeNode* p = CreateTree({ 
        16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
        1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
    });
    TreeNode* q = CreateTree({ 
        16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
        1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 32  // Last node different
    });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_VeryDeepIdentical_ReturnsTrue) {
    // Deep left-skewed tree (20 nodes)
    // Output: true

    // Arrange
    TreeNode* p = new TreeNode(20);
    TreeNode* currentP = p;
    for (int i = 19; i >= 1; i--) {
        currentP->left = new TreeNode(i);
        currentP = currentP->left;
    }

    TreeNode* q = new TreeNode(20);
    TreeNode* currentQ = q;
    for (int i = 19; i >= 1; i--) {
        currentQ->left = new TreeNode(i);
        currentQ = currentQ->left;
    }

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_VeryDeepDifferent_ReturnsFalse) {
    // Deep left-skewed tree, one deep node different
    // Output: false

    // Arrange
    TreeNode* p = new TreeNode(20);
    TreeNode* currentP = p;
    for (int i = 19; i >= 1; i--) {
        currentP->left = new TreeNode(i);
        currentP = currentP->left;
    }

    TreeNode* q = new TreeNode(20);
    TreeNode* currentQ = q;
    for (int i = 19; i >= 2; i--) {
        currentQ->left = new TreeNode(i);
        currentQ = currentQ->left;
    }
    currentQ->left = new TreeNode(999);  // Different value at deepest node

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

#pragma endregion

#pragma region Boundary Cases

TEST_F(SameTree_Stack_100_Tests, IsSameTree_SymmetricTreesIdentical_ReturnsTrue) {
    // Input: p = [1,2,2,3,4,4,3], q = [1,2,2,3,4,4,3]
    //        1                 1
    //       / \               / \
    //      2   2             2   2
    //     / \ / \           / \ / \
    //    3  4 4  3         3  4 4  3
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ 1, 2, 2, 3, 4, 4, 3 });
    TreeNode* q = CreateTree({ 1, 2, 2, 3, 4, 4, 3 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_OneMissingNullNode_ReturnsFalse) {
    // Input: p = [1,2,3,4,null,5,6], q = [1,2,3,null,null,5,6]
    //        1                 1
    //       / \               / \
    //      2   3             2   3
    //     /   / \               / \
    //    4   5   6             5   6
    // Output: false

    // Arrange
    TreeNode* p = CreateTree({ 1, 2, 3, 4, -1001, 5, 6 });
    TreeNode* q = CreateTree({ 1, 2, 3, -1001, -1001, 5, 6 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_SameStructureAllNulls_ReturnsFalse) {
    // Input: p = [1,null,null], q = [2,null,null]
    // Both have same structure (just root), but different values
    // Output: false

    // Arrange
    TreeNode* p = new TreeNode(1);
    TreeNode* q = new TreeNode(2);

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

#pragma endregion

#pragma region Property Tests

TEST_F(SameTree_Stack_100_Tests, IsSameTree_TreeComparedWithItself_ReturnsTrue) {
    // A tree compared with itself should always be true
    // Note: This creates two separate instances with same structure

    // Arrange
    TreeNode* p = CreateTree({ 1, 2, 3, 4, 5, 6, 7 });
    TreeNode* q = CreateTree({ 1, 2, 3, 4, 5, 6, 7 });

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_Reflexive_SameReference_ReturnsTrue) {
    // A tree compared with literally the same reference
    // Output: true

    // Arrange
    TreeNode* p = CreateTree({ 1, 2, 3 });
    TreeNode* q = p;  // Same reference

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup - only free once since they're the same
    FreeTree(p);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_Symmetric_LeftRightSwapped_ReturnsFalse) {
    // Mirror images should not be considered same
    // Input: p = [1,2,3], q = [1,3,2]
    //    1         1
    //   / \       / \
    //  2   3     3   2
    // Output: false

    // Arrange
    TreeNode* p = CreateSimpleTree(1, 2, 3);
    TreeNode* q = CreateSimpleTree(1, 3, 2);

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_Transitive_IfPEqualQAndQEqualR_ThenPEqualR) {
    // If p == q and q == r, then p == r (transitivity)
    // Output: all comparisons should be true

    // Arrange
    TreeNode* p = CreateTree({ 1, 2, 3 });
    TreeNode* q = CreateTree({ 1, 2, 3 });
    TreeNode* r = CreateTree({ 1, 2, 3 });

    // Act
    bool pq = solution.isSameTree(p, q);
    bool qr = solution.isSameTree(q, r);
    bool pr = solution.isSameTree(p, r);

    // Assert
    ASSERT_TRUE(pq);
    ASSERT_TRUE(qr);
    ASSERT_TRUE(pr);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
    FreeTree(r);
}

#pragma endregion

#pragma region Stack-Specific Edge Cases

TEST_F(SameTree_Stack_100_Tests, IsSameTree_DeepRightSkewed_StressTest_ReturnsTrue) {
    // Deep right-skewed tree (30 nodes) - tests stack depth
    // Output: true

    // Arrange
    TreeNode* p = new TreeNode(1);
    TreeNode* currentP = p;
    for (int i = 2; i <= 30; i++) {
        currentP->right = new TreeNode(i);
        currentP = currentP->right;
    }

    TreeNode* q = new TreeNode(1);
    TreeNode* currentQ = q;
    for (int i = 2; i <= 30; i++) {
        currentQ->right = new TreeNode(i);
        currentQ = currentQ->right;
    }

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

TEST_F(SameTree_Stack_100_Tests, IsSameTree_AlternatingStructure_ReturnsTrue) {
    // Alternating left-right pattern
    //    1            1
    //     \            \
    //      2            2
    //     /            /
    //    3            3
    //     \            \
    //      4            4
    //     /            /
    //    5            5
    // Output: true

    // Arrange
    TreeNode* p = new TreeNode(1);
    p->right = new TreeNode(2);
    p->right->left = new TreeNode(3);
    p->right->left->right = new TreeNode(4);
    p->right->left->right->left = new TreeNode(5);

    TreeNode* q = new TreeNode(1);
    q->right = new TreeNode(2);
    q->right->left = new TreeNode(3);
    q->right->left->right = new TreeNode(4);
    q->right->left->right->left = new TreeNode(5);

    // Act
    bool result = solution.isSameTree(p, q);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(p);
    FreeTree(q);
}

#pragma endregion
