#include "gtest/gtest.h"
#include "TreeNode.h"
#include "BinaryTreePostOrderTraversal_Reversal_145.h"
#include "BinaryTreePostOrderTraversal_TwoVisit_145.h"
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
    /// Creates a binary tree from a level-order vector
    /// </summary>
    inline TreeNode* CreateTree(const std::vector<int>& vec) {
        if (vec.size() == 0) return nullptr;
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

class BinaryTreePostOrderTraversal_Reversal_145_Tests : public ::testing::Test {
protected:
    BinaryTreePostOrderTraversal_Reversal_145 solution;

    void TearDown() override {
        // Cleanup is handled by FreeTree in each test
    }
};

class BinaryTreePostOrderTraversal_TwoVisit_145_Tests : public ::testing::Test {
protected:
    BinaryTreePostOrderTraversal_TwoVisit_145 solution;

    void TearDown() override {
        // Cleanup is handled by FreeTree in each test
    }
};

// Macro to define the same test for both implementations
#define DEFINE_TEST_FOR_BOTH(TestName, TestBody) \
    TEST_F(BinaryTreePostOrderTraversal_Reversal_145_Tests, TestName) TestBody \
    TEST_F(BinaryTreePostOrderTraversal_TwoVisit_145_Tests, TestName) TestBody

#pragma region LeetCode Examples

DEFINE_TEST_FOR_BOTH(PostorderTraversal_Example1_ReturnsCorrectOrder, {
    // Input: root = [1,null,2,3]
    //    1
    //     \
    //      2
    //     /
    //    3
    // Output: [3,2,1]

    // Arrange
    TreeNode* root = CreateTree({ 1, -1001, 2, 3 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 3, 2, 1 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_Example2_EmptyTree_ReturnsEmpty, {
    // Input: root = []
    // Output: []

    // Arrange
    TreeNode* root = nullptr;

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    ASSERT_EQ(0, result.size());
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_Example3_SingleNode_ReturnsSingleElement, {
    // Input: root = [1]
    // Output: [1]

    // Arrange
    TreeNode* root = new TreeNode(1);

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Basic Tree Structures

DEFINE_TEST_FOR_BOTH(PostorderTraversal_SingleNode_ReturnsNode, {
    // Arrange
    TreeNode* root = new TreeNode(5);

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 5 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_TwoNodesLeftChild_ReturnsCorrectOrder, {
    // Tree:  2
    //       /
    //      1
    // Postorder: [1, 2]

    // Arrange
    TreeNode* root = CreateSimpleTree(2, 1);

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_TwoNodesRightChild_ReturnsCorrectOrder, {
    // Tree:  1
    //         \
    //          2
    // Postorder: [2, 1]

    // Arrange
    TreeNode* root = CreateSimpleTree(1, -1001, 2);

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 2, 1 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_ThreeNodesComplete_ReturnsCorrectOrder, {
    // Tree:    2
    //         / \
    //        1   3
    // Postorder: [1, 3, 2]

    // Arrange
    TreeNode* root = CreateSimpleTree(2, 1, 3);

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 3, 2 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Balanced Trees

DEFINE_TEST_FOR_BOTH(PostorderTraversal_BalancedTree7Nodes_ReturnsCorrectOrder, {
    // Tree:       4
    //           /   \
    //          2     6
    //         / \   / \
    //        1   3 5   7
    // Postorder: [1, 3, 2, 5, 7, 6, 4]

    // Arrange
    TreeNode* root = CreateTree({ 4, 2, 6, 1, 3, 5, 7 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 3, 2, 5, 7, 6, 4 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_BalancedTree15Nodes_ReturnsCorrectOrder, {
    // Tree:              8
    //                /       \
    //               4         12
    //             /   \      /   \
    //            2     6    10    14
    //           / \   / \   / \   / \
    //          1   3 5   7 9  11 13 15
    // Postorder: [1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8]

    // Arrange
    TreeNode* root = CreateTree({ 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Left-Skewed Trees

DEFINE_TEST_FOR_BOTH(PostorderTraversal_LeftSkewedTree3Nodes_ReturnsCorrectOrder, {
    // Tree:      3
    //           /
    //          2
    //         /
    //        1
    // Postorder: [1, 2, 3]

    // Arrange
    TreeNode* root = CreateTree({ 3, 2, -1001, 1 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2, 3 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_LeftSkewedTree5Nodes_ReturnsCorrectOrder, {
    // Tree:          5
    //               /
    //              4
    //             /
    //            3
    //           /
    //          2
    //         /
    //        1
    // Postorder: [1, 2, 3, 4, 5]

    // Arrange
    TreeNode* root = CreateTree({ 5, 4, -1001, 3, -1001, 2, -1001, 1 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2, 3, 4, 5 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Right-Skewed Trees

DEFINE_TEST_FOR_BOTH(PostorderTraversal_RightSkewedTree3Nodes_ReturnsCorrectOrder, {
    // Tree:  1
    //         \
    //          2
    //           \
    //            3
    // Postorder: [3, 2, 1]

    // Arrange
    TreeNode* root = CreateTree({ 1, -1001, 2, -1001, 3 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 3, 2, 1 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_RightSkewedTree5Nodes_ReturnsCorrectOrder, {
    // Tree:  1
    //         \
    //          2
    //           \
    //            3
    //             \
    //              4
    //               \
    //                5
    // Postorder: [5, 4, 3, 2, 1]

    // Arrange
    TreeNode* root = CreateTree({ 1, -1001, 2, -1001, 3, -1001, 4, -1001, 5 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 5, 4, 3, 2, 1 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Unbalanced Trees

DEFINE_TEST_FOR_BOTH(PostorderTraversal_UnbalancedLeftHeavy_ReturnsCorrectOrder, {
    // Tree:        5
    //            /   \
    //           3     6
    //          / \
    //         2   4
    //        /
    //       1
    // Postorder: [1, 2, 4, 3, 6, 5]

    // Arrange
    TreeNode* root = CreateTree({ 5, 3, 6, 2, 4, -1001, -1001, 1 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2, 4, 3, 6, 5 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_UnbalancedRightHeavy_ReturnsCorrectOrder, {
    // Tree:    1
    //         / \
    //        0   3
    //           / \
    //          2   4
    //               \
    //                5
    // Postorder: [0, 2, 5, 4, 3, 1]

    // Arrange
    TreeNode* root = CreateTree({ 1, 0, 3, -1001, -1001, 2, 4, -1001, -1001, -1001, 5 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 0, 2, 5, 4, 3, 1 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Edge Cases - Values

DEFINE_TEST_FOR_BOTH(PostorderTraversal_NegativeValues_ReturnsCorrectOrder, {
    // Tree:      0
    //          /   \
    //        -2     2
    //        / \   / \
    //      -3 -1  1  3
    // Postorder: [-3, -1, -2, 1, 3, 2, 0]

    // Arrange
    TreeNode* root = CreateTree({ 0, -2, 2, -3, -1, 1, 3 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ -3, -1, -2, 1, 3, 2, 0 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_AllNegativeValues_ReturnsCorrectOrder, {
    // Tree:      -4
    //           /   \
    //         -6    -2
    //         / \   / \
    //       -7 -5 -3 -1
    // Postorder: [-7, -5, -6, -3, -1, -2, -4]

    // Arrange
    TreeNode* root = CreateTree({ -4, -6, -2, -7, -5, -3, -1 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ -7, -5, -6, -3, -1, -2, -4 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_DuplicateValues_ReturnsCorrectOrder, {
    // Tree:      2
    //           / \
    //          2   2
    //         / \
    //        1   2
    // Postorder: [1, 2, 2, 2, 2]

    // Arrange
    TreeNode* root = CreateTree({ 2, 2, 2, 1, 2 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 2, 2, 2, 2 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_AllSameValues_ReturnsCorrectOrder, {
    // Tree:      5
    //           / \
    //          5   5
    //         / \
    //        5   5
    // Postorder: [5, 5, 5, 5, 5]

    // Arrange
    TreeNode* root = CreateTree({ 5, 5, 5, 5, 5 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 5, 5, 5, 5, 5 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_ZeroValue_ReturnsCorrectOrder, {
    // Tree:      0
    //           / \
    //          0   0
    // Postorder: [0, 0, 0]

    // Arrange
    TreeNode* root = CreateSimpleTree(0, 0, 0);

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 0, 0, 0 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_LargeValues_ReturnsCorrectOrder, {
    // Tree:      1000
    //           /     \
    //         100    10000
    // Postorder: [100, 10000, 1000]

    // Arrange
    TreeNode* root = CreateSimpleTree(1000, 100, 10000);

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 100, 10000, 1000 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Complex Trees

DEFINE_TEST_FOR_BOTH(PostorderTraversal_ComplexTree_ReturnsCorrectOrder, {
    // Tree:           10
    //              /      \
    //             5        15
    //           /   \        \
    //          3     7       20
    //         / \     \
    //        1   4     9
    // Postorder: [1, 4, 3, 9, 7, 5, 20, 15, 10]

    // Arrange
    TreeNode* root = CreateTree({ 10, 5, 15, 3, 7, -1001, 20, 1, 4, -1001, 9 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 1, 4, 3, 9, 7, 5, 20, 15, 10 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_SparseTree_ReturnsCorrectOrder, {
    // Tree:       8
    //           /   \
    //          4     12
    //           \   /
    //            6 10
    // Postorder: [6, 4, 10, 12, 8]

    // Arrange
    TreeNode* root = CreateTree({ 8, 4, 12, -1001, 6, 10 });

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 6, 4, 10, 12, 8 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion

#pragma region Larger Trees

DEFINE_TEST_FOR_BOTH(PostorderTraversal_LargeBalancedTree_ReturnsCorrectOrder, {
    // Create a larger balanced tree with 31 nodes (5 levels)
    // Postorder should visit left subtree then right subtree then root

    // Arrange
    std::vector<int> treeValues;
    treeValues.push_back(16); treeValues.push_back(8); treeValues.push_back(24); 
    treeValues.push_back(4); treeValues.push_back(12); treeValues.push_back(20); treeValues.push_back(28);
    treeValues.push_back(2); treeValues.push_back(6); treeValues.push_back(10); treeValues.push_back(14);
    treeValues.push_back(18); treeValues.push_back(22); treeValues.push_back(26); treeValues.push_back(30);
    treeValues.push_back(1); treeValues.push_back(3); treeValues.push_back(5); treeValues.push_back(7);
    treeValues.push_back(9); treeValues.push_back(11); treeValues.push_back(13); treeValues.push_back(15);
    treeValues.push_back(17); treeValues.push_back(19); treeValues.push_back(21); treeValues.push_back(23);
    treeValues.push_back(25); treeValues.push_back(27); treeValues.push_back(29); treeValues.push_back(31);
    TreeNode* root = CreateTree(treeValues);

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert - Postorder for this balanced tree
    std::vector<int> expected;
    expected.push_back(1); expected.push_back(3); expected.push_back(2);
    expected.push_back(5); expected.push_back(7); expected.push_back(6); expected.push_back(4);
    expected.push_back(9); expected.push_back(11); expected.push_back(10);
    expected.push_back(13); expected.push_back(15); expected.push_back(14); expected.push_back(12); expected.push_back(8);
    expected.push_back(17); expected.push_back(19); expected.push_back(18);
    expected.push_back(21); expected.push_back(23); expected.push_back(22); expected.push_back(20);
    expected.push_back(25); expected.push_back(27); expected.push_back(26);
    expected.push_back(29); expected.push_back(31); expected.push_back(30); expected.push_back(28); expected.push_back(24); expected.push_back(16);
    ASSERT_EQ(expected, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_DeepLeftSkewed_ReturnsCorrectOrder, {
    // Create a deep left-skewed tree (10 nodes)
    // Postorder: [1 2 3 4 5 6 7 8 9 10]

    // Arrange
    TreeNode* root = new TreeNode(10);
    TreeNode* current = root;
    int i;
    for (i = 9; i >= 1; i--) {
        current->left = new TreeNode(i);
        current = current->left;
    }

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    std::vector<int> expected;
    for (i = 1; i <= 10; i++) {
        expected.push_back(i);
    }
    ASSERT_EQ(expected, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_DeepRightSkewed_ReturnsCorrectOrder, {
    // Create a deep right-skewed tree (10 nodes)
    // Postorder: [10 9 8 7 6 5 4 3 2 1]

    // Arrange
    TreeNode* root = new TreeNode(1);
    TreeNode* current = root;
    int i;
    for (i = 2; i <= 10; i++) {
        current->right = new TreeNode(i);
        current = current->right;
    }

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    std::vector<int> expected;
    for (i = 10; i >= 1; i--) {
        expected.push_back(i);
    }
    ASSERT_EQ(expected, result);

    // Cleanup
    FreeTree(root);
})


#pragma endregion

#pragma region Special Patterns

DEFINE_TEST_FOR_BOTH(PostorderTraversal_ZigZagPattern_ReturnsCorrectOrder, {
    // Tree:    1
    //           \
    //            2
    //           /
    //          3
    //           \
    //            4
    //           /
    //          5
    // Postorder: [5, 4, 3, 2, 1]

    // Arrange
    TreeNode* root = new TreeNode(1);
    root->right = new TreeNode(2);
    root->right->left = new TreeNode(3);
    root->right->left->right = new TreeNode(4);
    root->right->left->right->left = new TreeNode(5);

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 5, 4, 3, 2, 1 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_OnlyLeftChildren_ReturnsCorrectOrder, {
    // Tree:       10
    //            /
    //           9
    //          /
    //         8
    //        /
    //       7
    // Postorder: [7, 8, 9, 10]

    // Arrange
    TreeNode* root = new TreeNode(10);
    root->left = new TreeNode(9);
    root->left->left = new TreeNode(8);
    root->left->left->left = new TreeNode(7);

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 7, 8, 9, 10 }, result);

    // Cleanup
    FreeTree(root);
})

DEFINE_TEST_FOR_BOTH(PostorderTraversal_OnlyRightChildren_ReturnsCorrectOrder, {
    // Tree:  7
    //         \
    //          8
    //           \
    //            9
    //             \
    //              10
    // Postorder: [10, 9, 8, 7]

    // Arrange
    TreeNode* root = new TreeNode(7);
    root->right = new TreeNode(8);
    root->right->right = new TreeNode(9);
    root->right->right->right = new TreeNode(10);

    // Act
    std::vector<int> result = solution.postorderTraversal(root);

    // Assert
    AssertVectorEquals({ 10, 9, 8, 7 }, result);

    // Cleanup
    FreeTree(root);
})

#pragma endregion
