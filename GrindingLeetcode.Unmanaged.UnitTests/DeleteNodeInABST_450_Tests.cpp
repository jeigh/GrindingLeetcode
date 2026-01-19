#include "gtest/gtest.h"
#include "TreeNode.h"
#include "DeleteNodeInABST_RecursiveSuccessorDeletion_450.h"
#include "DeleteNodeInABST_DirectSuccessorPromotion_450.h"
#include <queue>
#include <vector>
#include <DeleteNodeInABST_LeftTreeDemotion_450.h>

// Tree-specific helper functions
namespace BSTreeHelpers {
    /// <summary>
    /// Creates a binary tree from a level-order array (with nulls represented as special values)
    /// Use -10001 to represent null nodes (outside typical LeetCode constraint range)
    /// </summary>
    inline TreeNode* CreateBST(std::initializer_list<int> values) {
        if (values.size() == 0) return nullptr;
        
        std::vector<int> vec(values);
        if (vec[0] == -10001) return nullptr;
        
        TreeNode* root = new TreeNode(vec[0]);
        std::queue<TreeNode*> queue;
        queue.push(root);
        int index = 1;
        
        while (!queue.empty() && index < vec.size()) {
            TreeNode* current = queue.front();
            queue.pop();
            
            // Left child
            if (index < vec.size() && vec[index] != -10001) {
                current->left = new TreeNode(vec[index]);
                queue.push(current->left);
            }
            index++;
            
            // Right child
            if (index < vec.size() && vec[index] != -10001) {
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
    /// Converts tree to inorder array for easy comparison
    /// </summary>
    inline std::vector<int> ToInorderArray(TreeNode* root) {
        std::vector<int> result;
        if (root == nullptr) return result;
        
        auto left = ToInorderArray(root->left);
        result.insert(result.end(), left.begin(), left.end());
        result.push_back(root->val);
        auto right = ToInorderArray(root->right);
        result.insert(result.end(), right.begin(), right.end());
        
        return result;
    }

    /// <summary>
    /// Validates BST property
    /// </summary>
    inline bool IsValidBST(TreeNode* root, long long minVal = LLONG_MIN, long long maxVal = LLONG_MAX) {
        if (root == nullptr) return true;
        if (root->val <= minVal || root->val >= maxVal) return false;
        return IsValidBST(root->left, minVal, root->val) && IsValidBST(root->right, root->val, maxVal);
    }

    /// <summary>
    /// Searches for a value in BST
    /// </summary>
    inline bool SearchBST(TreeNode* root, int val) {
        if (root == nullptr) return false;
        if (root->val == val) return true;
        if (val < root->val) return SearchBST(root->left, val);
        return SearchBST(root->right, val);
    }

    /// <summary>
    /// Counts nodes in tree
    /// </summary>
    inline int CountNodes(TreeNode* root) {
        if (root == nullptr) return 0;
        return 1 + CountNodes(root->left) + CountNodes(root->right);
    }
}

using namespace BSTreeHelpers;

class DeleteNodeInABST_RecursiveSuccessorDeletion_450_Tests : public ::testing::Test {
protected:
    DeleteNodeInABST_RecursiveSuccessorDeletion_450 solution;
};

class DeleteNodeInABST_DirectSuccessorPromotion_450_Tests : public ::testing::Test {
protected:
    DeleteNodeInABST_DirectSuccessorPromotion_450 solution;
};

class DeleteNodeInABST_LeftTreeDemotion_450_Tests : public ::testing::Test {
protected:
    DeleteNodeInABST_LeftTreeDemotion_450 solution;
};

// Macro to define the same test for both implementations
#define DEFINE_TEST_FOR_BOTH(TestName, TestBody) \
    TEST_F(DeleteNodeInABST_DirectSuccessorPromotion_450_Tests, TestName) TestBody \
    TEST_F(DeleteNodeInABST_RecursiveSuccessorDeletion_450_Tests, TestName) TestBody \
    TEST_F(DeleteNodeInABST_LeftTreeDemotion_450_Tests, TestName) TestBody
           

#pragma region LeetCode Examples

DEFINE_TEST_FOR_BOTH(DeleteNode_Example1_DeletesNodeCorrectly, {
    // Input: root = [5,3,6,2,4,null,7], key = 3
    //        5
    //       / \
    //      3   6
    //     / \   \
    //    2   4   7
    // Output: [5,4,6,2,null,null,7] or [5,2,6,null,4,null,7]
    // Explanation: Node with value 3 is deleted

    // Arrange
    TreeNode* root = CreateBST({ 5, 3, 6, 2, 4, -10001, 7 });

    // Act
    TreeNode* result = solution.deleteNode(root, 3);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 3));
    ASSERT_TRUE(SearchBST(result, 2));
    ASSERT_TRUE(SearchBST(result, 4));
    ASSERT_TRUE(SearchBST(result, 5));
    ASSERT_TRUE(SearchBST(result, 6));
    ASSERT_TRUE(SearchBST(result, 7));
    ASSERT_EQ(5, CountNodes(result));

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_Example2_DeletesRootWithOneChild, {
    // Input: root = [5,3,6,2,4,null,7], key = 0
    // Output: [5,3,6,2,4,null,7]
    // Explanation: Key not found, tree unchanged

    // Arrange
    TreeNode* root = CreateBST({ 5, 3, 6, 2, 4, -10001, 7 });

    // Act
    TreeNode* result = solution.deleteNode(root, 0);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_EQ(6, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 2, 3, 4, 5, 6, 7 }), inorder);

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_Example3_EmptyTree, {
    // Input: root = [], key = 0
    // Output: []

    // Arrange
    TreeNode* root = nullptr;

    // Act
    TreeNode* result = solution.deleteNode(root, 0);

    // Assert
    ASSERT_EQ(nullptr, result);
})

#pragma endregion

#pragma region Delete Leaf Nodes

DEFINE_TEST_FOR_BOTH(DeleteNode_DeleteLeafLeftChild_RemovesLeaf, {
    // Tree:    5
    //         / \
    //        3   7
    //       /
    //      2
    // Delete 2 (leaf, left child)
    // Result: [5,3,7]

    // Arrange
    TreeNode* root = CreateBST({ 5, 3, 7, 2 });

    // Act
    TreeNode* result = solution.deleteNode(root, 2);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 2));
    ASSERT_EQ(3, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 3, 5, 7 }), inorder);

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_DeleteLeafRightChild_RemovesLeaf, {
    // Tree:    5
    //         / \
    //        3   7
    //             \
    //              9
    // Delete 9 (leaf, right child)
    // Result: [5,3,7]

    // Arrange
    TreeNode* root = CreateBST({ 5, 3, 7, -10001, -10001, -10001, 9 });

    // Act
    TreeNode* result = solution.deleteNode(root, 9);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 9));
    ASSERT_EQ(3, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 3, 5, 7 }), inorder);

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_SingleNodeTree_ReturnsNull, {
    // Tree: [5]
    // Delete 5
    // Result: []

    // Arrange
    TreeNode* root = new TreeNode(5);

    // Act
    TreeNode* result = solution.deleteNode(root, 5);

    // Assert
    ASSERT_EQ(nullptr, result);
})

#pragma endregion

#pragma region Delete Node with One Child

DEFINE_TEST_FOR_BOTH(DeleteNode_NodeWithOnlyLeftChild_PromotesChild, {
    // Tree:    5
    //         / \
    //        3   7
    //       /
    //      2
    // Delete 3 (has only left child)
    // Result: [5,2,7]

    // Arrange
    TreeNode* root = CreateBST({ 5, 3, 7, 2 });

    // Act
    TreeNode* result = solution.deleteNode(root, 3);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 3));
    ASSERT_TRUE(SearchBST(result, 2));
    ASSERT_EQ(3, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 2, 5, 7 }), inorder);

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_NodeWithOnlyRightChild_PromotesChild, {
    // Tree:    5
    //         / \
    //        3   7
    //             \
    //              9
    // Delete 7 (has only right child)
    // Result: [5,3,9]

    // Arrange
    TreeNode* root = CreateBST({ 5, 3, 7, -10001, -10001, -10001, 9 });

    // Act
    TreeNode* result = solution.deleteNode(root, 7);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 7));
    ASSERT_TRUE(SearchBST(result, 9));
    ASSERT_EQ(3, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 3, 5, 9 }), inorder);

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_RootWithOnlyLeftChild_PromotesChild, {
    // Tree:  5
    //       /
    //      3
    // Delete 5 (root with only left child)
    // Result: [3]

    // Arrange
    TreeNode* root = CreateBST({ 5, 3 });

    // Act
    TreeNode* result = solution.deleteNode(root, 5);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_NE(nullptr, result);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(1, CountNodes(result));

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_RootWithOnlyRightChild_PromotesChild, {
    // Tree:  5
    //         \
    //          7
    // Delete 5 (root with only right child)
    // Result: [7]

    // Arrange
    TreeNode* root = CreateBST({ 5, -10001, 7 });

    // Act
    TreeNode* result = solution.deleteNode(root, 5);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_NE(nullptr, result);
    ASSERT_EQ(7, result->val);
    ASSERT_EQ(1, CountNodes(result));

    // Cleanup
    FreeTree(result);
})

#pragma endregion

#pragma region Delete Node with Two Children

DEFINE_TEST_FOR_BOTH(DeleteNode_NodeWithTwoChildren_ReplacesCorrectly, {
    // Tree:      5
    //          /   \
    //         3     7
    //        / \   / \
    //       2   4 6   8
    // Delete 5 (root with two children)
    // Result: Should maintain BST property

    // Arrange
    TreeNode* root = CreateBST({ 5, 3, 7, 2, 4, 6, 8 });

    // Act
    TreeNode* result = solution.deleteNode(root, 5);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 5));
    ASSERT_EQ(6, CountNodes(result));
    // All other nodes should still be present
    ASSERT_TRUE(SearchBST(result, 2));
    ASSERT_TRUE(SearchBST(result, 3));
    ASSERT_TRUE(SearchBST(result, 4));
    ASSERT_TRUE(SearchBST(result, 6));
    ASSERT_TRUE(SearchBST(result, 7));
    ASSERT_TRUE(SearchBST(result, 8));

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_InternalNodeWithTwoChildren_ReplacesCorrectly, {
    // Tree:        10
    //            /    \
    //           5      15
    //          / \    /  \
    //         3   7  12   20
    // Delete 5 (internal node with two children)
    // Result: Should maintain BST property

    // Arrange
    TreeNode* root = CreateBST({ 10, 5, 15, 3, 7, 12, 20 });

    // Act
    TreeNode* result = solution.deleteNode(root, 5);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 5));
    ASSERT_EQ(6, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 3, 7, 10, 12, 15, 20 }), inorder);

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_NodeWithTwoChildrenDeepTree_ReplacesCorrectly, {
    // Tree:           20
    //              /      \
    //            10        30
    //           /  \      /  \
    //          5   15    25   35
    //         / \  / \   / \  / \
    //        3  7 12 18 22 27 33 37
    // Delete 10 (node with two children)

    // Arrange
    TreeNode* root = CreateBST({ 20, 10, 30, 5, 15, 25, 35, 3, 7, 12, 18, 22, 27, 33, 37 });

    // Act
    TreeNode* result = solution.deleteNode(root, 10);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 10));
    ASSERT_EQ(14, CountNodes(result));

    // Cleanup
    FreeTree(result);
})

#pragma endregion

#pragma region Delete Root Node

DEFINE_TEST_FOR_BOTH(DeleteNode_DeleteRootWithTwoChildren_ReplacesCorrectly, {
    // Tree:    5
    //         / \
    //        3   7
    // Delete 5 (root)
    // Result: Should be either [7,3] or [3,null,7]

    // Arrange
    TreeNode* root = CreateBST({ 5, 3, 7 });

    // Act
    TreeNode* result = solution.deleteNode(root, 5);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 5));
    ASSERT_TRUE(SearchBST(result, 3));
    ASSERT_TRUE(SearchBST(result, 7));
    ASSERT_EQ(2, CountNodes(result));

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_DeleteRootComplexTree_ReplacesCorrectly, {
    // Tree:        8
    //            /   \
    //           4     12
    //          / \   /  \
    //         2   6 10  14
    // Delete 8 (root)

    // Arrange
    TreeNode* root = CreateBST({ 8, 4, 12, 2, 6, 10, 14 });

    // Act
    TreeNode* result = solution.deleteNode(root, 8);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 8));
    ASSERT_EQ(6, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 2, 4, 6, 10, 12, 14 }), inorder);

    // Cleanup
    FreeTree(result);
})

#pragma endregion

#pragma region Key Not Found

DEFINE_TEST_FOR_BOTH(DeleteNode_KeyNotInTree_TreeUnchanged, {
    // Tree:    5
    //         / \
    //        3   7
    // Delete 10 (not in tree)
    // Result: [5,3,7] (unchanged)

    // Arrange
    TreeNode* root = CreateBST({ 5, 3, 7 });

    // Act
    TreeNode* result = solution.deleteNode(root, 10);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_EQ(3, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 3, 5, 7 }), inorder);

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_KeySmallerThanAll_TreeUnchanged, {
    // Tree:    5
    //         / \
    //        3   7
    // Delete 1 (smaller than all)

    // Arrange
    TreeNode* root = CreateBST({ 5, 3, 7 });

    // Act
    TreeNode* result = solution.deleteNode(root, 1);

    // Assert
    ASSERT_EQ(3, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 3, 5, 7 }), inorder);

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_KeyLargerThanAll_TreeUnchanged, {
    // Tree:    5
    //         / \
    //        3   7
    // Delete 10 (larger than all)

    // Arrange
    TreeNode* root = CreateBST({ 5, 3, 7 });

    // Act
    TreeNode* result = solution.deleteNode(root, 10);

    // Assert
    ASSERT_EQ(3, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 3, 5, 7 }), inorder);

    // Cleanup
    FreeTree(result);
})

#pragma endregion

#pragma region Skewed Trees

DEFINE_TEST_FOR_BOTH(DeleteNode_LeftSkewedTree_DeleteRoot, {
    // Tree:      5
    //           /
    //          4
    //         /
    //        3
    //       /
    //      2
    // Delete 5 (root)

    // Arrange
    TreeNode* root = CreateBST({ 5, 4, -10001, 3, -10001, 2 });

    // Act
    TreeNode* result = solution.deleteNode(root, 5);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 5));
    ASSERT_EQ(3, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 2, 3, 4 }), inorder);

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_LeftSkewedTree_DeleteMiddle, {
    // Tree:      5
    //           /
    //          4
    //         /
    //        3
    //       /
    //      2
    // Delete 3 (middle)

    // Arrange
    TreeNode* root = CreateBST({ 5, 4, -10001, 3, -10001, 2 });

    // Act
    TreeNode* result = solution.deleteNode(root, 3);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 3));
    ASSERT_EQ(3, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 2, 4, 5 }), inorder);

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_RightSkewedTree_DeleteRoot, {
    // Tree:  2
    //         \
    //          3
    //           \
    //            4
    //             \
    //              5
    // Delete 2 (root)

    // Arrange
    TreeNode* root = CreateBST({ 2, -10001, 3, -10001, 4, -10001, 5 });

    // Act
    TreeNode* result = solution.deleteNode(root, 2);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 2));
    ASSERT_EQ(3, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 3, 4, 5 }), inorder);

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_RightSkewedTree_DeleteMiddle, {
    // Tree:  2
    //         \
    //          3
    //           \
    //            4
    //             \
    //              5
    // Delete 4 (middle)

    // Arrange
    TreeNode* root = CreateBST({ 2, -10001, 3, -10001, 4, -10001, 5 });

    // Act
    TreeNode* result = solution.deleteNode(root, 4);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 4));
    ASSERT_EQ(3, CountNodes(result));
    auto inorder = ToInorderArray(result);
    ASSERT_EQ(std::vector<int>({ 2, 3, 5 }), inorder);

    // Cleanup
    FreeTree(result);
})

#pragma endregion

#pragma region Sequential Deletions

DEFINE_TEST_FOR_BOTH(DeleteNode_MultipleSequentialDeletions_MaintainsBST, {
    // Tree:      5
    //          /   \
    //         3     7
    //        / \   / \
    //       2   4 6   8
    // Delete 3, then 7

    // Arrange
    TreeNode* root = CreateBST({ 5, 3, 7, 2, 4, 6, 8 });

    // Act
    TreeNode* result1 = solution.deleteNode(root, 3);
    ASSERT_TRUE(IsValidBST(result1));
    
    TreeNode* result2 = solution.deleteNode(result1, 7);

    // Assert
    ASSERT_TRUE(IsValidBST(result2));
    ASSERT_FALSE(SearchBST(result2, 3));
    ASSERT_FALSE(SearchBST(result2, 7));
    ASSERT_EQ(5, CountNodes(result2));
    auto inorder = ToInorderArray(result2);
    ASSERT_EQ(std::vector<int>({ 2, 4, 5, 6, 8 }), inorder);

    // Cleanup
    FreeTree(result2);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_DeleteAllNodes_ReturnsNull, {
    // Tree:  2
    //       / \
    //      1   3
    // Delete all nodes

    // Arrange
    TreeNode* root = CreateBST({ 2, 1, 3 });

    // Act
    TreeNode* result1 = solution.deleteNode(root, 1);
    TreeNode* result2 = solution.deleteNode(result1, 3);
    TreeNode* result3 = solution.deleteNode(result2, 2);

    // Assert
    ASSERT_EQ(nullptr, result3);
})

#pragma endregion

#pragma region Edge Cases with Values

DEFINE_TEST_FOR_BOTH(DeleteNode_NegativeValues_DeletesCorrectly, {
    // Tree:      0
    //          /   \
    //        -2     2
    //        / \   / \
    //      -3 -1  1  3
    // Delete -2

    // Arrange
    TreeNode* root = CreateBST({ 0, -2, 2, -3, -1, 1, 3 });

    // Act
    TreeNode* result = solution.deleteNode(root, -2);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, -2));
    ASSERT_EQ(6, CountNodes(result));

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_LargeValues_DeletesCorrectly, {
    // Tree:      5000
    //          /      \
    //       1000      10000
    // Delete 5000

    // Arrange
    TreeNode* root = CreateBST({ 5000, 1000, 10000 });

    // Act
    TreeNode* result = solution.deleteNode(root, 5000);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 5000));
    ASSERT_EQ(2, CountNodes(result));

    // Cleanup
    FreeTree(result);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_ZeroValue_DeletesCorrectly, {
    // Tree:      0
    //          /   \
    //        -1     1
    // Delete 0

    // Arrange
    TreeNode* root = CreateBST({ 0, -1, 1 });

    // Act
    TreeNode* result = solution.deleteNode(root, 0);

    // Assert
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 0));
    ASSERT_EQ(2, CountNodes(result));

    // Cleanup
    FreeTree(result);
})

#pragma endregion

#pragma region Complex Scenarios

DEFINE_TEST_FOR_BOTH(DeleteNode_LargeBalancedTree_DeletesMultipleNodes, {
    // Tree:              8
    //                /       \
    //               4         12
    //             /   \      /   \
    //            2     6    10    14
    //           / \   / \   / \   / \
    //          1   3 5   7 9  11 13 15
    // Delete 4, then 12

    // Arrange
    TreeNode* root = CreateBST({ 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });

    // Act
    TreeNode* result1 = solution.deleteNode(root, 4);
    ASSERT_TRUE(IsValidBST(result1));
    
    TreeNode* result2 = solution.deleteNode(result1, 12);

    // Assert
    ASSERT_TRUE(IsValidBST(result2));
    ASSERT_FALSE(SearchBST(result2, 4));
    ASSERT_FALSE(SearchBST(result2, 12));
    ASSERT_EQ(13, CountNodes(result2));

    // Cleanup
    FreeTree(result2);
})

DEFINE_TEST_FOR_BOTH(DeleteNode_DeleteRootRepeatedly_MaintainsBST, {
    // Build tree, delete root, verify, repeat
    // Tree:    5
    //         / \
    //        3   7
    //       / \ / \
    //      2  4 6  8

    // Arrange
    TreeNode* root = CreateBST({ 5, 3, 7, 2, 4, 6, 8 });

    // Act & Assert - Delete root multiple times
    TreeNode* result = solution.deleteNode(root, 5);
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_EQ(6, CountNodes(result));

    // Get current root value and delete it
    int newRootVal = result->val;
    result = solution.deleteNode(result, newRootVal);
    ASSERT_TRUE(IsValidBST(result));
    ASSERT_EQ(5, CountNodes(result));

    // Cleanup
    FreeTree(result);
})

TEST_F(DeleteNodeInABST_DirectSuccessorPromotion_450_Tests, DeleteNode_SimpleRightChildOnly) {
    // Tree:    10
    //            \
    //            15
    //              \
    //              20
    // Delete 15

    TreeNode* root = new TreeNode(10);
    root->right = new TreeNode(15);
    root->right->right = new TreeNode(20);

    TreeNode* result = solution.deleteNode(root, 15);

    ASSERT_TRUE(IsValidBST(result));
    ASSERT_FALSE(SearchBST(result, 15));
    ASSERT_TRUE(SearchBST(result, 10));
    ASSERT_TRUE(SearchBST(result, 20));
    ASSERT_EQ(2, CountNodes(result));

    FreeTree(result);
}

DEFINE_TEST_FOR_BOTH(DeleteNode_UnbalancedTree_DeleteNodeCausesRebalancing, {

})
