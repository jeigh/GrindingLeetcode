#include "gtest/gtest.h"
#include "TreeNode.h"
#include "DiameterOfBinaryTree_Recursive_543.h"
#include "DiameterOfBinaryTree_Stack_543.h"
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

class DiameterOfBinaryTree_Recursive_543_Tests : public ::testing::Test {
protected:
    DiameterOfBinaryTree_Recursive_543 solution;

    void TearDown() override {
        // Cleanup is handled by FreeTree in each test
    }
};

class DiameterOfBinaryTree_Stack_543_Tests : public ::testing::Test {
protected:
    DiameterOfBinaryTree_Stack_543 solution;

    void TearDown() override {
        // Cleanup is handled by FreeTree in each test
    }
};

// Macro to define the same test for both implementations
#define DEFINE_TEST_FOR_BOTH(TestName, TestBody) \
    TEST_F(DiameterOfBinaryTree_Recursive_543_Tests, TestName) TestBody \
    TEST_F(DiameterOfBinaryTree_Stack_543_Tests, TestName) TestBody

#pragma region LeetCode Examples

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_Example1_Returns3, {
    // Input: root = [1,2,3,4,5]
    //       1
    //      / \
    //     2   3
    //    / \
    //   4   5
    // Output: 3
    // Explanation: The diameter is the path [4,2,1,3] or [5,2,1,3] (3 edges)

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3, 4, 5 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(3, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_Example2_Returns1, {
    // Input: root = [1,2]
    //   1
    //  /
    // 2
    // Output: 1

    // Arrange
    TreeNode* root = CreateTree({ 1, 2 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(1, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Basic Tree Structures

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_NullTree_Returns0, {
    // Input: root = []
    // Output: 0

    // Arrange
    TreeNode* root = nullptr;

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(0, result);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_SingleNode_Returns0, {
    // Input: root = [1]
    // Output: 0
    // Explanation: No edges exist

    // Arrange
    TreeNode* root = new TreeNode(1);

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(0, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_TwoNodesLeftChild_Returns1, {
    // Tree:  2
    //       /
    //      1
    // Output: 1

    // Arrange
    TreeNode* root = CreateSimpleTree(2, 1);

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(1, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_TwoNodesRightChild_Returns1, {
    // Tree:  1
    //         \
    //          2
    // Output: 1

    // Arrange
    TreeNode* root = CreateSimpleTree(1, -1001, 2);

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(1, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_ThreeNodesComplete_Returns2, {
    // Tree:    2
    //         / \
    //        1   3
    // Output: 2
    // Explanation: Path is [1,2,3] (2 edges)

    // Arrange
    TreeNode* root = CreateSimpleTree(2, 1, 3);

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(2, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Balanced Trees

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_BalancedTree7Nodes_Returns4, {
    // Tree:       4
    //           /   \
    //          2     6
    //         / \   / \
    //        1   3 5   7
    // Output: 4
    // Explanation: Path could be [1,2,4,6,7] or [3,2,4,6,5] etc. (4 edges)

    // Arrange
    TreeNode* root = CreateTree({ 4, 2, 6, 1, 3, 5, 7 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_BalancedTree15Nodes_Returns6, {
    // Tree:              8
    //                /       \
    //               4         12
    //             /   \      /   \
    //            2     6    10    14
    //           / \   / \   / \   / \
    //          1   3 5   7 9  11 13 15
    // Output: 6
    // Explanation: Longest path goes through 3 levels on each side (6 edges)

    // Arrange
    TreeNode* root = CreateTree({ 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(6, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_PerfectTree31Nodes_Returns8, {
    // Perfect binary tree with 5 levels (31 nodes)
    // Output: 8
    // Explanation: Diameter is depth of left subtree + depth of right subtree

    // Arrange
    TreeNode* root = CreateTree({ 
        16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
        1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
    });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(8, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Left-Skewed Trees

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_LeftSkewed3Nodes_Returns2, {
    // Tree:      3
    //           /
    //          2
    //         /
    //        1
    // Output: 2

    // Arrange
    TreeNode* root = CreateTree({ 3, 2, -1001, 1 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(2, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_LeftSkewed5Nodes_Returns4, {
    // Tree:          5
    //               /
    //              4
    //             /
    //            3
    //           /
    //          2
    //         /
    //        1
    // Output: 4

    // Arrange
    TreeNode* root = CreateTree({ 5, 4, -1001, 3, -1001, 2, -1001, 1 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_LeftSkewed10Nodes_Returns9, {
    // Deep left-skewed tree
    // Output: 9

    // Arrange
    TreeNode* root = new TreeNode(10);
    TreeNode* current = root;
    for (int i = 9; i >= 1; i--)
    {
        current->left = new TreeNode(i);
        current = current->left;
    }

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(9, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Right-Skewed Trees

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_RightSkewed3Nodes_Returns2, {
    // Tree:  1
    //         \
    //          2
    //           \
    //            3
    // Output: 2

    // Arrange
    TreeNode* root = CreateTree({ 1, -1001, 2, -1001, 3 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(2, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_RightSkewed5Nodes_Returns4, {
    // Tree:  1
    //         \
    //          2
    //           \
    //            3
    //             \
    //              4
    //               \
    //                5
    // Output: 4

    // Arrange
    TreeNode* root = CreateTree({ 1, -1001, 2, -1001, 3, -1001, 4, -1001, 5 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_RightSkewed10Nodes_Returns9, {
    // Deep right-skewed tree
    // Output: 9

    // Arrange
    TreeNode* root = new TreeNode(1);
    TreeNode* current = root;
    for (int i = 2; i <= 10; i++)
    {
        current->right = new TreeNode(i);
        current = current->right;
    }

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(9, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Unbalanced Trees - Diameter Not Through Root

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_DiameterInLeftSubtree_Returns4, {
    // Tree:        1
    //            /   \
    //           2     3
    //          / \
    //         4   5
    //        / \
    //       6   7
    // Output: 4
    // Explanation: Diameter is [6,4,2,5] or [7,4,2,5] (doesn't go through root)

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3, 4, 5, -1001, -1001, 6, 7 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_DiameterInRightSubtree_Returns4, {
    // Tree:        1
    //            /   \
    //           2     3
    //                / \
    //               4   5
    //              / \
    //             6   7
    // Output: 4
    // Explanation: Diameter is [6,4,3,5] or [7,4,3,5] (doesn't go through root)

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3, -1001, -1001, 4, 5, 6, 7 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_DeepLeftSubtreeShallowRight_Returns5, {
    // Tree:            1
    //                /   \
    //               2     3
    //              / \
    //             4   5
    //            /
    //           6
    //          /
    //         7
    // Output: 5
    // Explanation: Diameter is [7,6,4,2,5] (5 edges)

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3, 4, 5, -1001, -1001, 6, -1001, -1001, -1001, 7 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(5, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_UnbalancedMixed_ReturnsCorrectDiameter, {
    // Tree:          1
    //              /   \
    //             2     3
    //            / \     \
    //           4   5     6
    //          /           \
    //         7             8
    //        /               \
    //       9                 10
    // Output: 8
    // Explanation: Path from [9,7,4,2,1,3,6,8,10]

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3, 4, 5, -1001, 6, 7, -1001, -1001, -1001, -1001, 8, 9, -1001, -1001, 10 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(8, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Edge Cases - Values

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_NegativeValues_ReturnsCorrectDiameter, {
    // Tree:       0
    //           /   \
    //         -2     2
    //         / \   / \
    //       -3 -1  1  3
    // Output: 4

    // Arrange
    TreeNode* root = CreateTree({ 0, -2, 2, -3, -1, 1, 3 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_AllNegativeValues_ReturnsCorrectDiameter, {
    // Tree:       -4
    //           /    \
    //         -6     -2
    //         / \    / \
    //       -7 -5  -3 -1
    // Output: 4

    // Arrange
    TreeNode* root = CreateTree({ -4, -6, -2, -7, -5, -3, -1 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_DuplicateValues_ReturnsCorrectDiameter, {
    // Tree:      5
    //           / \
    //          5   5
    //         / \
    //        5   5
    // Output: 3

    // Arrange
    TreeNode* root = CreateTree({ 5, 5, 5, 5, 5 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(3, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_ZeroValues_ReturnsCorrectDiameter, {
    // Tree:      0
    //           / \
    //          0   0
    // Output: 2

    // Arrange
    TreeNode* root = CreateSimpleTree(0, 0, 0);

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(2, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_LargeValues_ReturnsCorrectDiameter, {
    // Tree:      10000
    //           /     \
    //       -10000   10000
    // Output: 2

    // Arrange
    TreeNode* root = CreateSimpleTree(10000, -10000, 10000);

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(2, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Complex Trees

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_ComplexAsymmetric_ReturnsCorrectDiameter, {
    // Tree:           10
    //              /      \
    //             5        15
    //           /   \        \
    //          3     7       20
    //         / \     \
    //        1   4     9
    // Output: 5
    // Explanation: Path [1,3,5,7,9] (5 edges)

    // Arrange
    TreeNode* root = CreateTree({ 10, 5, 15, 3, 7, -1001, 20, 1, 4, -1001, 9 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(5, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_SparseTree_ReturnsCorrectDiameter, {
    // Tree:       8
    //           /   \
    //          4     12
    //           \   /
    //            6 10
    // Output: 4
    // Explanation: Path [6,4,8,12,10] (4 edges)

    // Arrange
    TreeNode* root = CreateTree({ 8, 4, 12, -1001, 6, 10 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_OnlyLeftSubtreeDeep_ReturnsCorrectDiameter, {
    // Tree:        10
    //             /
    //            5
    //           / \
    //          3   7
    //         /     \
    //        1       9
    // Output: 4
    // Explanation: Path [1,3,5,7,9] (4 edges)

    // Arrange
    TreeNode* root = CreateTree({ 10, 5, -1001, 3, 7, 1, -1001, -1001, 9 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_OnlyRightSubtreeDeep_ReturnsCorrectDiameter, {
    // Tree:     5
    //            \
    //             15
    //            /  \
    //           12  20
    //          /      \
    //         10       25
    // Output: 4
    // Explanation: Path [10,12,15,20,25] (4 edges)

    // Arrange
    TreeNode* root = CreateTree({ 5, -1001, 15, 12, 20, 10, -1001, -1001, 25 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Special Patterns

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_ZigZagPattern_ReturnsCorrectDiameter, {
    // Tree:    1
    //           \
    //            2
    //           /
    //          3
    //           \
    //            4
    //           /
    //          5
    // Output: 4

    // Arrange
    TreeNode* root = new TreeNode(1);
    root->right = new TreeNode(2);
    root->right->left = new TreeNode(3);
    root->right->left->right = new TreeNode(4);
    root->right->left->right->left = new TreeNode(5);

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_SymmetricTree_ReturnsCorrectDiameter, {
    // Tree:      1
    //           / \
    //          2   2
    //         / \ / \
    //        3  4 4  3
    // Output: 4
    // Explanation: Path goes through root, 2 edges on each side

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 2, 3, 4, 4, 3 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_VShape_ReturnsCorrectDiameter, {
    // Tree:       4
    //           /   \
    //          2     6
    //         /       \
    //        1         7
    // Output: 4
    // Explanation: Path [1,2,4,6,7] (4 edges)

    // Arrange
    TreeNode* root = CreateTree({ 4, 2, 6, 1, -1001, -1001, 7 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Larger Trees

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_VeryDeepLeftSkewed_ReturnsCorrectDiameter, {
    // Deep left-skewed tree (20 nodes)
    // Output: 19

    // Arrange
    TreeNode* root = new TreeNode(20);
    TreeNode* current = root;
    for (int i = 19; i >= 1; i--)
    {
        current->left = new TreeNode(i);
        current = current->left;
    }

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(19, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_VeryDeepRightSkewed_ReturnsCorrectDiameter, {
    // Deep right-skewed tree (20 nodes)
    // Output: 19

    // Arrange
    TreeNode* root = new TreeNode(1);
    TreeNode* current = root;
    for (int i = 2; i <= 20; i++)
    {
        current->right = new TreeNode(i);
        current = current->right;
    }

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(19, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_LargeBalancedTree_ReturnsCorrectDiameter, {
    // Perfect binary tree with 6 levels (63 nodes)
    // Output: 10
    // Explanation: 5 edges from left + 5 edges from right

    // Arrange
    std::vector<int> values;
    for (int i = 1; i <= 63; i++)
    {
        values.push_back(i);
    }
    
    TreeNode* root = nullptr;
    if (values.size() > 0) {
        root = new TreeNode(values[0]);
        std::queue<TreeNode*> queue;
        queue.push(root);
        int index = 1;
        
        while (!queue.empty() && index < values.size()) {
            TreeNode* current = queue.front();
            queue.pop();
            
            if (index < values.size()) {
                current->left = new TreeNode(values[index]);
                queue.push(current->left);
            }
            index++;
            
            if (index < values.size()) {
                current->right = new TreeNode(values[index]);
                queue.push(current->right);
            }
            index++;
        }
    }

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(10, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Boundary Cases

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_OneChildPerNode_LeftThenRight_ReturnsCorrectDiameter, {
    // Tree:     1
    //          /
    //         2
    //          \
    //           3
    //          /
    //         4
    // Output: 3

    // Arrange
    TreeNode* root = new TreeNode(1);
    root->left = new TreeNode(2);
    root->left->right = new TreeNode(3);
    root->left->right->left = new TreeNode(4);

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(3, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_LongLeftBranchShortRightBranch_ReturnsCorrectDiameter, {
    // Tree:       1
    //           /   \
    //          2     3
    //         /
    //        4
    //       /
    //      5
    // Output: 4
    // Explanation: Path [5,4,2,1,3] (4 edges)

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3, 4, -1001, -1001, -1001, 5 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_ShortLeftBranchLongRightBranch_ReturnsCorrectDiameter, {
    // Tree:     1
    //          / \
    //         2   3
    //              \
    //               4
    //                \
    //                 5
    // Output: 4
    // Explanation: Path [2,1,3,4,5] (4 edges)

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3, -1001, -1001, -1001, 4, -1001, 5 });

    // Act
    int result = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_EQ(4, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Property Tests

TEST_F(DiameterOfBinaryTree_Recursive_543_Tests, DiameterOfBinaryTree_SingleNodeDifferentValues_AlwaysReturns0) {
    // Any single node should have diameter 0

    // Arrange
    std::vector<int> testValues = { -10000, -1, 0, 1, 42, 1000, 10000 };

    for (int value : testValues)
    {
        TreeNode* root = new TreeNode(value);

        // Act
        int result = solution.diameterOfBinaryTree(root);

        // Assert
        ASSERT_EQ(0, result);

        // Cleanup
        FreeTree(root);
    }
}

TEST_F(DiameterOfBinaryTree_Stack_543_Tests, DiameterOfBinaryTree_SingleNodeDifferentValues_AlwaysReturns0) {
    // Any single node should have diameter 0

    // Arrange
    std::vector<int> testValues = { -10000, -1, 0, 1, 42, 1000, 10000 };

    for (int value : testValues)
    {
        TreeNode* root = new TreeNode(value);

        // Act
        int result = solution.diameterOfBinaryTree(root);

        // Assert
        ASSERT_EQ(0, result);

        // Cleanup
        FreeTree(root);
    }
}

TEST_F(DiameterOfBinaryTree_Recursive_543_Tests, DiameterOfBinaryTree_SkewedTreesComparison_SameDiameter) {
    // Left-skewed and right-skewed trees of same height should have same diameter

    // Arrange
    TreeNode* leftSkewed = new TreeNode(5);
    TreeNode* currentLeft = leftSkewed;
    for (int i = 4; i >= 1; i--)
    {
        currentLeft->left = new TreeNode(i);
        currentLeft = currentLeft->left;
    }

    TreeNode* rightSkewed = new TreeNode(1);
    TreeNode* currentRight = rightSkewed;
    for (int i = 2; i <= 5; i++)
    {
        currentRight->right = new TreeNode(i);
        currentRight = currentRight->right;
    }

    // Act
    int leftDiameter = solution.diameterOfBinaryTree(leftSkewed);
    int rightDiameter = solution.diameterOfBinaryTree(rightSkewed);

    // Assert
    ASSERT_EQ(leftDiameter, rightDiameter);
    ASSERT_EQ(4, leftDiameter);

    // Cleanup
    FreeTree(leftSkewed);
    FreeTree(rightSkewed);
}

TEST_F(DiameterOfBinaryTree_Stack_543_Tests, DiameterOfBinaryTree_SkewedTreesComparison_SameDiameter) {
    // Left-skewed and right-skewed trees of same height should have same diameter

    // Arrange
    TreeNode* leftSkewed = new TreeNode(5);
    TreeNode* currentLeft = leftSkewed;
    for (int i = 4; i >= 1; i--)
    {
        currentLeft->left = new TreeNode(i);
        currentLeft = currentLeft->left;
    }

    TreeNode* rightSkewed = new TreeNode(1);
    TreeNode* currentRight = rightSkewed;
    for (int i = 2; i <= 5; i++)
    {
        currentRight->right = new TreeNode(i);
        currentRight = currentRight->right;
    }

    // Act
    int leftDiameter = solution.diameterOfBinaryTree(leftSkewed);
    int rightDiameter = solution.diameterOfBinaryTree(rightSkewed);

    // Assert
    ASSERT_EQ(leftDiameter, rightDiameter);
    ASSERT_EQ(4, leftDiameter);

    // Cleanup
    FreeTree(leftSkewed);
    FreeTree(rightSkewed);
}

DEFINE_TEST_FOR_BOTH(DiameterOfBinaryTree_DiameterLessThanOrEqualTwiceHeight, {
    // Property: diameter <= 2 * (height - 1)
    // For a balanced tree with 7 nodes, height is 3, diameter should be <= 4

    // Arrange
    TreeNode* root = CreateTree({ 4, 2, 6, 1, 3, 5, 7 });

    // Act
    int diameter = solution.diameterOfBinaryTree(root);

    // Assert
    ASSERT_TRUE(diameter <= 4);
    ASSERT_EQ(4, diameter);

    // Cleanup
    FreeTree(root);
})

#pragma endregion
