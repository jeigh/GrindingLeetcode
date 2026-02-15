#include "gtest/gtest.h"
#include "TreeNode.h"
#include "ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106.h"
#include "ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106.h"
#include <vector>
#include <climits>

// Tree-specific helper functions
namespace TreeHelpers106 {
    inline void FreeTree(TreeNode* root) {
        if (root == nullptr) return;
        FreeTree(root->left);
        FreeTree(root->right);
        delete root;
    }

    inline std::vector<int> InorderTraversal(TreeNode* root) {
        std::vector<int> result;
        if (root == nullptr) return result;
        
        std::vector<int> left = InorderTraversal(root->left);
        result.insert(result.end(), left.begin(), left.end());
        result.push_back(root->val);
        std::vector<int> right = InorderTraversal(root->right);
        result.insert(result.end(), right.begin(), right.end());
        
        return result;
    }

    inline std::vector<int> PostorderTraversal(TreeNode* root) {
        std::vector<int> result;
        if (root == nullptr) return result;
        
        std::vector<int> left = PostorderTraversal(root->left);
        std::vector<int> right = PostorderTraversal(root->right);
        result.insert(result.end(), left.begin(), left.end());
        result.insert(result.end(), right.begin(), right.end());
        result.push_back(root->val);
        
        return result;
    }

    inline int CountNodes(TreeNode* root) {
        if (root == nullptr) return 0;
        return 1 + CountNodes(root->left) + CountNodes(root->right);
    }

    inline void AssertTreeStructure(TreeNode* root, const std::vector<int>& expectedInorder, const std::vector<int>& expectedPostorder) {
        std::vector<int> actualInorder = InorderTraversal(root);
        std::vector<int> actualPostorder = PostorderTraversal(root);
        
        ASSERT_EQ(expectedInorder, actualInorder);
        ASSERT_EQ(expectedPostorder, actualPostorder);
    }
}

using namespace TreeHelpers106;

// Test fixture for RecursiveLimit implementation
class ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests : public ::testing::Test {
protected:
    ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106 solution;
};

// Test fixture for RecursiveHashmap implementation  
class ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests : public ::testing::Test {
protected:
    ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106 solution;
};

#pragma region LeetCode Examples - RecursiveLimit

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_Example1_ReturnsCorrectTree) {
    // Tree:      3
    //           / \
    //          9  20
    //            /  \
    //           15   7
    std::vector<int> inorder = { 9, 3, 15, 20, 7 };
    std::vector<int> postorder = { 9, 15, 7, 20, 3 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    ASSERT_NE(nullptr, result);
    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(9, result->left->val);
    ASSERT_EQ(20, result->right->val);
    ASSERT_EQ(nullptr, result->left->left);
    ASSERT_EQ(nullptr, result->left->right);
    ASSERT_EQ(15, result->right->left->val);
    ASSERT_EQ(7, result->right->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_Example2_SingleNode_ReturnsCorrectTree) {
    std::vector<int> inorder = { -1 };
    std::vector<int> postorder = { -1 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    ASSERT_NE(nullptr, result);
    ASSERT_EQ(-1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

#pragma endregion

#pragma region LeetCode Examples - RecursiveHashmap

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_Example1_ReturnsCorrectTree) {
    std::vector<int> inorder = { 9, 3, 15, 20, 7 };
    std::vector<int> postorder = { 9, 15, 7, 20, 3 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    ASSERT_NE(nullptr, result);
    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(9, result->left->val);
    ASSERT_EQ(20, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_Example2_SingleNode_ReturnsCorrectTree) {
    std::vector<int> inorder = { -1 };
    std::vector<int> postorder = { -1 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    ASSERT_NE(nullptr, result);
    ASSERT_EQ(-1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

#pragma endregion

#pragma region Single Node Trees - RecursiveLimit

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_SingleNodePositive_ReturnsCorrectTree) {
    std::vector<int> inorder = { 5 };
    std::vector<int> postorder = { 5 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    ASSERT_NE(nullptr, result);
    ASSERT_EQ(5, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_SingleNodeZero_ReturnsCorrectTree) {
    std::vector<int> inorder = { 0 };
    std::vector<int> postorder = { 0 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    ASSERT_NE(nullptr, result);
    ASSERT_EQ(0, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Single Node Trees - RecursiveHashmap

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_SingleNodePositive_ReturnsCorrectTree) {
    std::vector<int> inorder = { 5 };
    std::vector<int> postorder = { 5 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    ASSERT_NE(nullptr, result);
    ASSERT_EQ(5, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_SingleNodeZero_ReturnsCorrectTree) {
    std::vector<int> inorder = { 0 };
    std::vector<int> postorder = { 0 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    ASSERT_NE(nullptr, result);
    ASSERT_EQ(0, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Two Node Trees - RecursiveLimit

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_TwoNodes_LeftChild_ReturnsCorrectTree) {
    // Tree:  2
    //       /
    //      1
    std::vector<int> inorder = { 1, 2 };
    std::vector<int> postorder = { 1, 2 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(1, result->left->val);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_TwoNodes_RightChild_ReturnsCorrectTree) {
    // Tree:  1
    //         \
    //          2
    std::vector<int> inorder = { 1, 2 };
    std::vector<int> postorder = { 2, 1 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(2, result->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Two Node Trees - RecursiveHashmap

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_TwoNodes_LeftChild_ReturnsCorrectTree) {
    std::vector<int> inorder = { 1, 2 };
    std::vector<int> postorder = { 1, 2 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(1, result->left->val);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_TwoNodes_RightChild_ReturnsCorrectTree) {
    std::vector<int> inorder = { 1, 2 };
    std::vector<int> postorder = { 2, 1 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(2, result->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Three Node Trees - RecursiveLimit

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_ThreeNodes_Balanced_ReturnsCorrectTree) {
    // Tree:    2
    //         / \
    //        1   3
    std::vector<int> inorder = { 1, 2, 3 };
    std::vector<int> postorder = { 1, 3, 2 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(1, result->left->val);
    ASSERT_EQ(3, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_ThreeNodes_LeftSkewed_ReturnsCorrectTree) {
    // Tree:      3
    //           /
    //          2
    //         /
    //        1
    std::vector<int> inorder = { 1, 2, 3 };
    std::vector<int> postorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(2, result->left->val);
    ASSERT_EQ(1, result->left->left->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_ThreeNodes_RightSkewed_ReturnsCorrectTree) {
    // Tree:  1
    //         \
    //          2
    //           \
    //            3
    std::vector<int> inorder = { 1, 2, 3 };
    std::vector<int> postorder = { 3, 2, 1 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(2, result->right->val);
    ASSERT_EQ(3, result->right->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Three Node Trees - RecursiveHashmap

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_ThreeNodes_Balanced_ReturnsCorrectTree) {
    std::vector<int> inorder = { 1, 2, 3 };
    std::vector<int> postorder = { 1, 3, 2 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(1, result->left->val);
    ASSERT_EQ(3, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_ThreeNodes_LeftSkewed_ReturnsCorrectTree) {
    std::vector<int> inorder = { 1, 2, 3 };
    std::vector<int> postorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(2, result->left->val);
    ASSERT_EQ(1, result->left->left->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_ThreeNodes_RightSkewed_ReturnsCorrectTree) {
    std::vector<int> inorder = { 1, 2, 3 };
    std::vector<int> postorder = { 3, 2, 1 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(2, result->right->val);
    ASSERT_EQ(3, result->right->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Perfect Binary Trees - RecursiveLimit

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_PerfectTree_7Nodes_ReturnsCorrectTree) {
    // Tree:        4
    //            /   \
    //           2     6
    //          / \   / \
    //         1   3 5   7
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7 };
    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(7, CountNodes(result));
    ASSERT_EQ(4, result->val);
    ASSERT_EQ(2, result->left->val);
    ASSERT_EQ(6, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_PerfectTree_15Nodes_ReturnsCorrectTree) {
    // Tree:               8
    //                /       \
    //               4         12
    //             /   \      /   \
    //            2     6    10    14
    //           / \   / \   / \   / \
    //          1   3 5   7 9  11 13 15
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(15, CountNodes(result));
    ASSERT_EQ(8, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Perfect Binary Trees - RecursiveHashmap

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_PerfectTree_7Nodes_ReturnsCorrectTree) {
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7 };
    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(7, CountNodes(result));
    ASSERT_EQ(4, result->val);
    ASSERT_EQ(2, result->left->val);
    ASSERT_EQ(6, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_PerfectTree_15Nodes_ReturnsCorrectTree) {
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(15, CountNodes(result));
    ASSERT_EQ(8, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Skewed Trees - RecursiveLimit

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_LeftSkewed_5Nodes_ReturnsCorrectTree) {
    // Tree:      5
    //           /
    //          4
    //         /
    //        3
    //       /
    //      2
    //     /
    //    1
    std::vector<int> inorder = { 1, 2, 3, 4, 5 };
    std::vector<int> postorder = { 1, 2, 3, 4, 5 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(5, CountNodes(result));
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_RightSkewed_5Nodes_ReturnsCorrectTree) {
    // Tree:  1
    //         \
    //          2
    //           \
    //            3
    //             \
    //              4
    //               \
    //                5
    std::vector<int> inorder = { 1, 2, 3, 4, 5 };
    std::vector<int> postorder = { 5, 4, 3, 2, 1 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(5, CountNodes(result));
    ASSERT_EQ(nullptr, result->left);

    FreeTree(result);
}

#pragma endregion

#pragma region Skewed Trees - RecursiveHashmap

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_LeftSkewed_5Nodes_ReturnsCorrectTree) {
    std::vector<int> inorder = { 1, 2, 3, 4, 5 };
    std::vector<int> postorder = { 1, 2, 3, 4, 5 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(5, CountNodes(result));
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_RightSkewed_5Nodes_ReturnsCorrectTree) {
    std::vector<int> inorder = { 1, 2, 3, 4, 5 };
    std::vector<int> postorder = { 5, 4, 3, 2, 1 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(5, CountNodes(result));
    ASSERT_EQ(nullptr, result->left);

    FreeTree(result);
}

#pragma endregion

#pragma region Asymmetric Trees - RecursiveLimit

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_AsymmetricTree1_ReturnsCorrectTree) {
    // Tree:           10
    //               /    \
    //              5      15
    //            /   \      \
    //           3     7     20
    //          / \
    //         1   4
    std::vector<int> inorder = { 1, 3, 4, 5, 7, 10, 15, 20 };
    std::vector<int> postorder = { 1, 4, 3, 7, 5, 20, 15, 10 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(8, CountNodes(result));

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_AsymmetricTree2_ReturnsCorrectTree) {
    // Tree:        20
    //            /    \
    //          10      30
    //         /      /    \
    //        5      25    35
    //       / \            \
    //      3   7           40
    std::vector<int> inorder = { 3, 5, 7, 10, 20, 25, 30, 35, 40 };
    std::vector<int> postorder = { 3, 7, 5, 10, 25, 40, 35, 30, 20 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(9, CountNodes(result));

    FreeTree(result);
}

#pragma endregion

#pragma region Asymmetric Trees - RecursiveHashmap

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_AsymmetricTree1_ReturnsCorrectTree) {
    std::vector<int> inorder = { 1, 3, 4, 5, 7, 10, 15, 20 };
    std::vector<int> postorder = { 1, 4, 3, 7, 5, 20, 15, 10 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(8, CountNodes(result));

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_AsymmetricTree2_ReturnsCorrectTree) {
    std::vector<int> inorder = { 3, 5, 7, 10, 20, 25, 30, 35, 40 };
    std::vector<int> postorder = { 3, 7, 5, 10, 25, 40, 35, 30, 20 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(9, CountNodes(result));

    FreeTree(result);
}

#pragma endregion

#pragma region Edge Cases - Negative Values - RecursiveLimit

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_NegativeValues_ReturnsCorrectTree) {
    // Tree:       0
    //           /   \
    //         -5     5
    //         / \   / \
    //       -8  -3 3   8
    std::vector<int> inorder = { -8, -5, -3, 0, 3, 5, 8 };
    std::vector<int> postorder = { -8, -3, -5, 3, 8, 5, 0 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(0, result->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_AllNegativeValues_ReturnsCorrectTree) {
    // Tree:       -4
    //           /    \
    //         -6     -2
    //         / \    / \
    //       -7  -5 -3  -1
    std::vector<int> inorder = { -7, -6, -5, -4, -3, -2, -1 };
    std::vector<int> postorder = { -7, -5, -6, -3, -1, -2, -4 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(-4, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Edge Cases - Negative Values - RecursiveHashmap

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_NegativeValues_ReturnsCorrectTree) {
    std::vector<int> inorder = { -8, -5, -3, 0, 3, 5, 8 };
    std::vector<int> postorder = { -8, -3, -5, 3, 8, 5, 0 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(0, result->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_AllNegativeValues_ReturnsCorrectTree) {
    std::vector<int> inorder = { -7, -6, -5, -4, -3, -2, -1 };
    std::vector<int> postorder = { -7, -5, -6, -3, -1, -2, -4 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(-4, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Boundary Cases - RecursiveLimit

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_MaxIntValue_ReturnsCorrectTree) {
    std::vector<int> inorder = { INT_MIN, 0, INT_MAX };
    std::vector<int> postorder = { INT_MIN, INT_MAX, 0 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(0, result->val);
    ASSERT_EQ(INT_MIN, result->left->val);
    ASSERT_EQ(INT_MAX, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_LargeBalancedTree_ReturnsCorrectTree) {
    // Large balanced tree (31 nodes)
    std::vector<int> inorder = { 3, 6, 9, 12, 15, 18, 21, 25, 28, 31, 34, 37, 40, 43, 46, 50, 53, 56, 59, 62, 65, 68, 71, 75, 78, 81, 84, 87, 90, 93, 96 };
    std::vector<int> postorder = { 3, 9, 6, 15, 21, 18, 12, 28, 34, 31, 40, 46, 43, 37, 25, 53, 59, 56, 65, 71, 68, 62, 78, 84, 81, 90, 96, 93, 87, 75, 50 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(31, CountNodes(result));
    ASSERT_EQ(50, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Boundary Cases - RecursiveHashmap

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_MaxIntValue_ReturnsCorrectTree) {
    std::vector<int> inorder = { INT_MIN, 0, INT_MAX };
    std::vector<int> postorder = { INT_MIN, INT_MAX, 0 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(0, result->val);
    ASSERT_EQ(INT_MIN, result->left->val);
    ASSERT_EQ(INT_MAX, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_LargeBalancedTree_ReturnsCorrectTree) {
    std::vector<int> inorder = { 3, 6, 9, 12, 15, 18, 21, 25, 28, 31, 34, 37, 40, 43, 46, 50, 53, 56, 59, 62, 65, 68, 71, 75, 78, 81, 84, 87, 90, 93, 96 };
    std::vector<int> postorder = { 3, 9, 6, 15, 21, 18, 12, 28, 34, 31, 40, 46, 43, 37, 25, 53, 59, 56, 65, 71, 68, 62, 78, 84, 81, 90, 96, 93, 87, 75, 50 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(31, CountNodes(result));
    ASSERT_EQ(50, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Property-Based Tests - RecursiveLimit

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_VerifyPostorderProperty_ReturnsCorrectTree) {
    // Postorder: left, then right, then root (root is LAST)
    std::vector<int> inorder = { 3, 5, 7, 10, 12, 15, 20 };
    std::vector<int> postorder = { 3, 7, 5, 12, 20, 15, 10 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    std::vector<int> actualPostorder = PostorderTraversal(result);
    ASSERT_EQ(postorder[postorder.size() - 1], actualPostorder[actualPostorder.size() - 1]); // Root is last
    ASSERT_EQ(postorder, actualPostorder);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_VerifyInorderProperty_ReturnsCorrectTree) {
    // Inorder: left, then root, then right
    std::vector<int> inorder = { 3, 5, 7, 10, 12, 15, 20 };
    std::vector<int> postorder = { 3, 7, 5, 12, 20, 15, 10 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    std::vector<int> actualInorder = InorderTraversal(result);
    ASSERT_EQ(inorder, actualInorder);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_NodeCountMatchesArrayLength_ReturnsCorrectTree) {
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    ASSERT_EQ(static_cast<int>(inorder.size()), CountNodes(result));

    FreeTree(result);
}

#pragma endregion

#pragma region Property-Based Tests - RecursiveHashmap

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_VerifyPostorderProperty_ReturnsCorrectTree) {
    std::vector<int> inorder = { 3, 5, 7, 10, 12, 15, 20 };
    std::vector<int> postorder = { 3, 7, 5, 12, 20, 15, 10 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    std::vector<int> actualPostorder = PostorderTraversal(result);
    ASSERT_EQ(postorder[postorder.size() - 1], actualPostorder[actualPostorder.size() - 1]);
    ASSERT_EQ(postorder, actualPostorder);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_VerifyInorderProperty_ReturnsCorrectTree) {
    std::vector<int> inorder = { 3, 5, 7, 10, 12, 15, 20 };
    std::vector<int> postorder = { 3, 7, 5, 12, 20, 15, 10 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    std::vector<int> actualInorder = InorderTraversal(result);
    ASSERT_EQ(inorder, actualInorder);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_NodeCountMatchesArrayLength_ReturnsCorrectTree) {
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    ASSERT_EQ(static_cast<int>(inorder.size()), CountNodes(result));

    FreeTree(result);
}

#pragma endregion

#pragma region Complex Real-World Scenarios - RecursiveLimit

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_ComplexTree1_ReturnsCorrectTree) {
    std::vector<int> inorder = { 10, 25, 50, 60, 75, 80, 100, 125, 150, 160, 175, 190 };
    std::vector<int> postorder = { 10, 25, 60, 80, 75, 50, 125, 160, 190, 175, 150, 100 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(12, CountNodes(result));
    ASSERT_EQ(100, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Complex Real-World Scenarios - RecursiveHashmap

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_ComplexTree1_ReturnsCorrectTree) {
    std::vector<int> inorder = { 10, 25, 50, 60, 75, 80, 100, 125, 150, 160, 175, 190 };
    std::vector<int> postorder = { 10, 25, 60, 80, 75, 50, 125, 160, 190, 175, 150, 100 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(12, CountNodes(result));
    ASSERT_EQ(100, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region ZigZag Pattern - RecursiveLimit

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_106_Tests, BuildTree_ZigZagPattern_ReturnsCorrectTree) {
    // Tree:    1
    //           \
    //            2
    //           /
    //          3
    //           \
    //            4
    //           /
    //          5
    std::vector<int> inorder = { 1, 3, 5, 4, 2 };
    std::vector<int> postorder = { 5, 4, 3, 2, 1 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(5, CountNodes(result));

    FreeTree(result);
}

#pragma endregion

#pragma region ZigZag Pattern - RecursiveHashmap

TEST_F(ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_106_Tests, BuildTree_ZigZagPattern_ReturnsCorrectTree) {
    std::vector<int> inorder = { 1, 3, 5, 4, 2 };
    std::vector<int> postorder = { 5, 4, 3, 2, 1 };

    TreeNode* result = solution.buildTree(inorder, postorder);

    AssertTreeStructure(result, inorder, postorder);
    ASSERT_EQ(5, CountNodes(result));

    FreeTree(result);
}

#pragma endregion
