#include "gtest/gtest.h"
#include "TreeNode.h"
#include "BinaryTreeInorderTraversal_Recursion_94.h"
#include "BinaryTreeInorderTraversal_Stack_94.h"
#include <queue>

// Tree-specific helper functions (defined here to avoid header ordering issues)
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

    /// <summary>
    /// Asserts that a vector matches expected values
    /// </summary>
    inline void AssertVectorEquals(std::initializer_list<int> expected, const std::vector<int>& actual) {
        std::vector<int> expectedVec(expected);
        ASSERT_EQ(expectedVec, actual);
    }
}

using namespace TreeHelpers;

// Test fixture for BinaryTreeInorderTraversal_Recursion_94
class BinaryTreeInorderTraversal_Recursion_94_Tests : public ::testing::Test {
protected:
    BinaryTreeInorderTraversal_Recursion_94 solution;

    void TearDown() override {
        // Cleanup is handled by FreeTree in each test
    }
};

// Test fixture for BinaryTreeInorderTraversal_Stack_94
class BinaryTreeInorderTraversal_Stack_94_Tests : public ::testing::Test {
protected:
    BinaryTreeInorderTraversal_Stack_94 solution;

    void TearDown() override {
        // Cleanup is handled by FreeTree in each test
    }
};

// Macro to define the same test for both implementations
#define DEFINE_TEST_FOR_BOTH(TestName, TestBody) \
    TEST_F(BinaryTreeInorderTraversal_Recursion_94_Tests, TestName) TestBody \
    TEST_F(BinaryTreeInorderTraversal_Stack_94_Tests, TestName) TestBody

#pragma region LeetCode Examples

DEFINE_TEST_FOR_BOTH(InorderTraversal_Example1_ReturnsCorrectOrder, {
    // Input: root = [1,null,2,3]
    //    1
    //     \
    //      2
    //     /
    //    3
    // Output: [1,3,2]

    // Arrange
    TreeNode* root = CreateTree({ 1, -1001, 2, 3 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 3, 2 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_Example2_EmptyTree_ReturnsEmpty, {
    // Input: root = []
    // Output: []

    // Arrange
    TreeNode* root = nullptr;

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    ASSERT_EQ(0, result.size());
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_Example3_SingleNode_ReturnsSingleElement, {
    // Input: root = [1]
    // Output: [1]

    // Arrange
    TreeNode* root = new TreeNode(1);

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Basic Tree Structures

DEFINE_TEST_FOR_BOTH(InorderTraversal_SingleNode_ReturnsNode, {
    // Arrange
    TreeNode* root = new TreeNode(5);

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 5 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_TwoNodesLeftChild_ReturnsCorrectOrder, {
    // Tree:  2
    //       /
    //      1
    // Inorder: [1, 2]

    // Arrange
    TreeNode* root = CreateSimpleTree(2, 1);

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_TwoNodesRightChild_ReturnsCorrectOrder, {
    // Tree:  1
    //         \
    //          2
    // Inorder: [1, 2]

    // Arrange
    TreeNode* root = CreateSimpleTree(1, -1001, 2);

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_ThreeNodesComplete_ReturnsCorrectOrder, {
    // Tree:    2
    //         / \
    //        1   3
    // Inorder: [1, 2, 3]

    // Arrange
    TreeNode* root = CreateSimpleTree(2, 1, 3);

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2, 3 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Balanced Trees

DEFINE_TEST_FOR_BOTH(InorderTraversal_BalancedTree7Nodes_ReturnsCorrectOrder, {
    // Tree:       4
    //           /   \
    //          2     6
    //         / \   / \
    //        1   3 5   7
    // Inorder: [1, 2, 3, 4, 5, 6, 7]

    // Arrange
    TreeNode* root = CreateTree({ 4, 2, 6, 1, 3, 5, 7 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2, 3, 4, 5, 6, 7 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_BalancedTree15Nodes_ReturnsCorrectOrder, {
    // Tree:              8
    //                /       \
    //               4         12
    //             /   \      /   \
    //            2     6    10    14
    //           / \   / \   / \   / \
    //          1   3 5   7 9  11 13 15
    // Inorder: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]

    // Arrange
    TreeNode* root = CreateTree({ 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Left-Skewed Trees

DEFINE_TEST_FOR_BOTH(InorderTraversal_LeftSkewedTree3Nodes_ReturnsCorrectOrder, {
    // Tree:      3
    //           /
    //          2
    //         /
    //        1
    // Inorder: [1, 2, 3]

    // Arrange
    TreeNode* root = CreateTree({ 3, 2, -1001, 1 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2, 3 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_LeftSkewedTree5Nodes_ReturnsCorrectOrder, {
    // Tree:          5
    //               /
    //              4
    //             /
    //            3
    //           /
    //          2
    //         /
    //        1
    // Inorder: [1, 2, 3, 4, 5]

    // Arrange
    TreeNode* root = CreateTree({ 5, 4, -1001, 3, -1001, 2, -1001, 1 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2, 3, 4, 5 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Right-Skewed Trees

DEFINE_TEST_FOR_BOTH(InorderTraversal_RightSkewedTree3Nodes_ReturnsCorrectOrder, {
    // Tree:  1
    //         \
    //          2
    //           \
    //            3
    // Inorder: [1, 2, 3]

    // Arrange
    TreeNode* root = CreateTree({ 1, -1001, 2, -1001, 3 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2, 3 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_RightSkewedTree5Nodes_ReturnsCorrectOrder, {
    // Tree:  1
    //         \
    //          2
    //           \
    //            3
    //             \
    //              4
    //               \
    //                5
    // Inorder: [1, 2, 3, 4, 5]

    // Arrange
    TreeNode* root = CreateTree({ 1, -1001, 2, -1001, 3, -1001, 4, -1001, 5 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2, 3, 4, 5 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Unbalanced Trees

DEFINE_TEST_FOR_BOTH(InorderTraversal_UnbalancedLeftHeavy_ReturnsCorrectOrder, {
    // Tree:        5
    //            /   \
    //           3     6
    //          / \
    //         2   4
    //        /
    //       1
    // Inorder: [1, 2, 3, 4, 5, 6]

    // Arrange
    TreeNode* root = CreateTree({ 5, 3, 6, 2, 4, -1001, -1001, 1 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2, 3, 4, 5, 6 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_UnbalancedRightHeavy_ReturnsCorrectOrder, {
    // Tree:    1
    //         / \
    //        0   3
    //           / \
    //          2   4
    //               \
    //                5
    // Inorder: [0, 1, 2, 3, 4, 5]

    // Arrange
    TreeNode* root = CreateTree({ 1, 0, 3, -1001, -1001, 2, 4, -1001, -1001, -1001, 5 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 0, 1, 2, 3, 4, 5 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Edge Cases - Values

DEFINE_TEST_FOR_BOTH(InorderTraversal_NegativeValues_ReturnsCorrectOrder, {
    // Tree:      0
    //          /   \
    //        -2     2
    //        / \   / \
    //      -3 -1  1  3
    // Inorder: [-3, -2, -1, 0, 1, 2, 3]

    // Arrange
    TreeNode* root = CreateTree({ 0, -2, 2, -3, -1, 1, 3 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ -3, -2, -1, 0, 1, 2, 3 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_AllNegativeValues_ReturnsCorrectOrder, {
    // Tree:      -4
    //           /   \
    //         -6    -2
    //         / \   / \
    //       -7 -5 -3 -1
    // Inorder: [-7, -6, -5, -4, -3, -2, -1]

    // Arrange
    TreeNode* root = CreateTree({ -4, -6, -2, -7, -5, -3, -1 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ -7, -6, -5, -4, -3, -2, -1 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_DuplicateValues_ReturnsCorrectOrder, {
    // Tree:      2
    //           / \
    //          2   2
    //         / \
    //        1   2
    // Inorder: [1, 2, 2, 2, 2]

    // Arrange
    TreeNode* root = CreateTree({ 2, 2, 2, 1, 2 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2, 2, 2, 2 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_AllSameValues_ReturnsCorrectOrder, {
    // Tree:      5
    //           / \
    //          5   5
    //         / \
    //        5   5
    // Inorder: [5, 5, 5, 5, 5]

    // Arrange
    TreeNode* root = CreateTree({ 5, 5, 5, 5, 5 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 5, 5, 5, 5, 5 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_ZeroValue_ReturnsCorrectOrder, {
    // Tree:      0
    //           / \
    //          0   0
    // Inorder: [0, 0, 0]

    // Arrange
    TreeNode* root = CreateSimpleTree(0, 0, 0);

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 0, 0, 0 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_LargeValues_ReturnsCorrectOrder, {
    // Tree:      1000
    //           /     \
    //         100    10000
    // Inorder: [100, 1000, 10000]

    // Arrange
    TreeNode* root = CreateSimpleTree(1000, 100, 10000);

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 100, 1000, 10000 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Complex Trees

DEFINE_TEST_FOR_BOTH(InorderTraversal_ComplexTree_ReturnsCorrectOrder, {
    // Tree:           10
    //              /      \
    //             5        15
    //           /   \        \
    //          3     7       20
    //         / \     \
    //        1   4     9
    // Inorder: [1, 3, 4, 5, 7, 9, 10, 15, 20]

    // Arrange
    TreeNode* root = CreateTree({ 10, 5, 15, 3, 7, -1001, 20, 1, 4, -1001, 9 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 3, 4, 5, 7, 9, 10, 15, 20 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_SparseTree_ReturnsCorrectOrder, {
    // Tree:       8
    //           /   \
    //          4     12
    //           \   /
    //            6 10
    // Inorder: [4, 6, 8, 10, 12]

    // Arrange
    TreeNode* root = CreateTree({ 8, 4, 12, -1001, 6, 10 });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 4, 6, 8, 10, 12 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Larger Trees

DEFINE_TEST_FOR_BOTH(InorderTraversal_LargeBalancedTree_ReturnsCorrectOrder, {
    // Create a larger balanced tree with 31 nodes (5 levels)
    // Inorder should be: [1, 2, 3, ..., 31]

    // Arrange
    TreeNode* root = CreateTree({ 
        16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
        1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
    });

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert - Create expected vector [1, 2, 3, ..., 31]
    std::vector<int> expected;
    for (int i = 1; i <= 31; i++) {
        expected.push_back(i);
    }
    ASSERT_EQ(expected, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_DeepLeftSkewed_ReturnsCorrectOrder, {
    // Create a deep left-skewed tree (10 nodes)
    // Inorder: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

    // Arrange
    TreeNode* root = new TreeNode(10);
    TreeNode* current = root;
    for (int i = 9; i >= 1; i--) {
        current->left = new TreeNode(i);
        current = current->left;
    }

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    std::vector<int> expected;
    for (int i = 1; i <= 10; i++) {
        expected.push_back(i);
    }
    ASSERT_EQ(expected, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_DeepRightSkewed_ReturnsCorrectOrder, {
    // Create a deep right-skewed tree (10 nodes)
    // Inorder: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

    // Arrange
    TreeNode* root = new TreeNode(1);
    TreeNode* current = root;
    for (int i = 2; i <= 10; i++) {
        current->right = new TreeNode(i);
        current = current->right;
    }

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    std::vector<int> expected;
    for (int i = 1; i <= 10; i++) {
        expected.push_back(i);
    }
    ASSERT_EQ(expected, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Special Patterns

DEFINE_TEST_FOR_BOTH(InorderTraversal_ZigZagPattern_ReturnsCorrectOrder, {
    // Tree:    1
    //           \
    //            2
    //           /
    //          3
    //           \
    //            4
    //           /
    //          5
    // Inorder: [1, 3, 5, 4, 2]

    // Arrange
    TreeNode* root = new TreeNode(1);
    root->right = new TreeNode(2);
    root->right->left = new TreeNode(3);
    root->right->left->right = new TreeNode(4);
    root->right->left->right->left = new TreeNode(5);

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 3, 5, 4, 2 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_OnlyLeftChildren_ReturnsCorrectOrder, {
    // Tree:       10
    //            /
    //           9
    //          /
    //         8
    //        /
    //       7
    // Inorder: [7, 8, 9, 10]

    // Arrange
    TreeNode* root = new TreeNode(10);
    root->left = new TreeNode(9);
    root->left->left = new TreeNode(8);
    root->left->left->left = new TreeNode(7);

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 7, 8, 9, 10 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(InorderTraversal_OnlyRightChildren_ReturnsCorrectOrder, {
    // Tree:  7
    //         \
    //          8
    //           \
    //            9
    //             \
    //              10
    // Inorder: [7, 8, 9, 10]

    // Arrange
    TreeNode* root = new TreeNode(7);
    root->right = new TreeNode(8);
    root->right->right = new TreeNode(9);
    root->right->right->right = new TreeNode(10);

    // Act
    std::vector<int> result = solution.inorderTraversal(root);

    // Assert
    AssertVectorEquals({ 7, 8, 9, 10 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion
