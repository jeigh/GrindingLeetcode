#include "gtest/gtest.h"
#include "TreeNode.h"
#include "AbstractConstructBinaryTreeFromPreorderAndInorder_105.h"
#include "ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105.h"
#include "ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105.h"
#include "ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105.h"
#include "ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105.h"
#include <queue>

// Tree-specific helper functions
namespace TreeHelpers105 {
    inline void FreeTree(TreeNode* root) {
        if (root == nullptr) return;
        FreeTree(root->left);
        FreeTree(root->right);
        delete root;
    }

    inline std::vector<int> PreorderTraversal(TreeNode* root) {
        std::vector<int> result;
        if (root == nullptr) return result;
        
        result.push_back(root->val);
        std::vector<int> left = PreorderTraversal(root->left);
        std::vector<int> right = PreorderTraversal(root->right);
        
        result.insert(result.end(), left.begin(), left.end());
        result.insert(result.end(), right.begin(), right.end());
        
        return result;
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

    inline int CountNodes(TreeNode* root) {
        if (root == nullptr) return 0;
        return 1 + CountNodes(root->left) + CountNodes(root->right);
    }

    inline void AssertTreeStructure(TreeNode* root, const std::vector<int>& expectedPreorder, const std::vector<int>& expectedInorder) {
        std::vector<int> actualPreorder = PreorderTraversal(root);
        std::vector<int> actualInorder = InorderTraversal(root);
        
        ASSERT_EQ(expectedPreorder, actualPreorder);
        ASSERT_EQ(expectedInorder, actualInorder);
    }
}

using namespace TreeHelpers105;

// Test fixture for ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105
class ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests : public ::testing::Test {
protected:
    ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105 solution;
};

// Test fixture for ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105
class ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests : public ::testing::Test {
protected:
    ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105 solution;
};

// Test fixture for ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105
class ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests : public ::testing::Test {
protected:
    ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105 solution;
};

// Test fixture for ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105
class ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests : public ::testing::Test {
protected:
    ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105 solution;
};

#pragma region LeetCode Examples - RecursiveOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_Example1_ReturnsCorrectTree) {
    std::vector<int> preorder = { 3, 9, 20, 15, 7 };
    std::vector<int> inorder = { 9, 3, 15, 20, 7 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    ASSERT_NE(nullptr, result);
    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(9, result->left->val);
    ASSERT_EQ(20, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_Example2_SingleNode_ReturnsCorrectTree) {
    std::vector<int> preorder = { -1 };
    std::vector<int> inorder = { -1 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    ASSERT_NE(nullptr, result);
    ASSERT_EQ(-1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

#pragma endregion

#pragma region LeetCode Examples - SixParams

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_Example1_ReturnsCorrectTree) {
    std::vector<int> preorder = { 3, 9, 20, 15, 7 };
    std::vector<int> inorder = { 9, 3, 15, 20, 7 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    ASSERT_NE(nullptr, result);
    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(9, result->left->val);
    ASSERT_EQ(20, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_Example2_SingleNode_ReturnsCorrectTree) {
    std::vector<int> preorder = { -1 };
    std::vector<int> inorder = { -1 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    ASSERT_NE(nullptr, result);
    ASSERT_EQ(-1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

#pragma endregion

#pragma region Two Node Trees - RecursiveOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_TwoNodes_LeftChild_ReturnsCorrectTree) {
    std::vector<int> preorder = { 2, 1 };
    std::vector<int> inorder = { 1, 2 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(1, result->left->val);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_TwoNodes_RightChild_ReturnsCorrectTree) {
    std::vector<int> preorder = { 1, 2 };
    std::vector<int> inorder = { 1, 2 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(2, result->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Two Node Trees - SixParams

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_TwoNodes_LeftChild_ReturnsCorrectTree) {
    std::vector<int> preorder = { 2, 1 };
    std::vector<int> inorder = { 1, 2 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(1, result->left->val);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_TwoNodes_RightChild_ReturnsCorrectTree) {
    std::vector<int> preorder = { 1, 2 };
    std::vector<int> inorder = { 1, 2 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(2, result->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Three Node Trees - RecursiveOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_ThreeNodes_Balanced_ReturnsCorrectTree) {
    std::vector<int> preorder = { 2, 1, 3 };
    std::vector<int> inorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(1, result->left->val);
    ASSERT_EQ(3, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_ThreeNodes_LeftSkewed_ReturnsCorrectTree) {
    std::vector<int> preorder = { 3, 2, 1 };
    std::vector<int> inorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(2, result->left->val);
    ASSERT_EQ(1, result->left->left->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_ThreeNodes_RightSkewed_ReturnsCorrectTree) {
    std::vector<int> preorder = { 1, 2, 3 };
    std::vector<int> inorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(2, result->right->val);
    ASSERT_EQ(3, result->right->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Three Node Trees - SixParams

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_ThreeNodes_Balanced_ReturnsCorrectTree) {
    std::vector<int> preorder = { 2, 1, 3 };
    std::vector<int> inorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(1, result->left->val);
    ASSERT_EQ(3, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_ThreeNodes_LeftSkewed_ReturnsCorrectTree) {
    std::vector<int> preorder = { 3, 2, 1 };
    std::vector<int> inorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(2, result->left->val);
    ASSERT_EQ(1, result->left->left->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_ThreeNodes_RightSkewed_ReturnsCorrectTree) {
    std::vector<int> preorder = { 1, 2, 3 };
    std::vector<int> inorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(2, result->right->val);
    ASSERT_EQ(3, result->right->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Perfect Binary Trees - RecursiveOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_PerfectTree_7Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 4, 2, 1, 3, 6, 5, 7 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(7, CountNodes(result));
    ASSERT_EQ(4, result->val);
    ASSERT_EQ(2, result->left->val);
    ASSERT_EQ(6, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_PerfectTree_15Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(15, CountNodes(result));
    ASSERT_EQ(8, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Perfect Binary Trees - SixParams

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_PerfectTree_7Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 4, 2, 1, 3, 6, 5, 7 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(7, CountNodes(result));
    ASSERT_EQ(4, result->val);
    ASSERT_EQ(2, result->left->val);
    ASSERT_EQ(6, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_PerfectTree_15Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(15, CountNodes(result));
    ASSERT_EQ(8, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Skewed Trees - RecursiveOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_LeftSkewed_5Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 5, 4, 3, 2, 1 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(5, CountNodes(result));
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_RightSkewed_5Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 1, 2, 3, 4, 5 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(5, CountNodes(result));
    ASSERT_EQ(nullptr, result->left);

    FreeTree(result);
}

#pragma endregion

#pragma region Skewed Trees - SixParams

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_LeftSkewed_5Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 5, 4, 3, 2, 1 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(5, CountNodes(result));
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_RightSkewed_5Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 1, 2, 3, 4, 5 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(5, CountNodes(result));
    ASSERT_EQ(nullptr, result->left);

    FreeTree(result);
}

#pragma endregion

#pragma region Edge Cases - Negative Values - RecursiveOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_NegativeValues_ReturnsCorrectTree) {
    std::vector<int> preorder = { 0, -5, -8, -3, 5, 3, 8 };
    std::vector<int> inorder = { -8, -5, -3, 0, 3, 5, 8 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(0, result->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_AllNegativeValues_ReturnsCorrectTree) {
    std::vector<int> preorder = { -4, -6, -7, -5, -2, -3, -1 };
    std::vector<int> inorder = { -7, -6, -5, -4, -3, -2, -1 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(-4, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Edge Cases - Negative Values - SixParams

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_NegativeValues_ReturnsCorrectTree) {
    std::vector<int> preorder = { 0, -5, -8, -3, 5, 3, 8 };
    std::vector<int> inorder = { -8, -5, -3, 0, 3, 5, 8 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(0, result->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_AllNegativeValues_ReturnsCorrectTree) {
    std::vector<int> preorder = { -4, -6, -7, -5, -2, -3, -1 };
    std::vector<int> inorder = { -7, -6, -5, -4, -3, -2, -1 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(-4, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Boundary Cases - RecursiveOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_MaxIntValue_ReturnsCorrectTree) {
    std::vector<int> preorder = { 0, INT_MIN, INT_MAX };
    std::vector<int> inorder = { INT_MIN, 0, INT_MAX };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(0, result->val);
    ASSERT_EQ(INT_MIN, result->left->val);
    ASSERT_EQ(INT_MAX, result->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Boundary Cases - SixParams

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_MaxIntValue_ReturnsCorrectTree) {
    std::vector<int> preorder = { 0, INT_MIN, INT_MAX };
    std::vector<int> inorder = { INT_MIN, 0, INT_MAX };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(0, result->val);
    ASSERT_EQ(INT_MIN, result->left->val);
    ASSERT_EQ(INT_MAX, result->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Property-Based Tests - RecursiveOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorder_RecursiveOptimized_105_Tests, BuildTree_NodeCountMatchesArrayLength_ReturnsCorrectTree) {
    std::vector<int> preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    ASSERT_EQ(static_cast<int>(preorder.size()), CountNodes(result));

    FreeTree(result);
}

#pragma endregion

#pragma region Property-Based Tests - SixParams

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105_Tests, BuildTree_NodeCountMatchesArrayLength_ReturnsCorrectTree) {
    std::vector<int> preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    ASSERT_EQ(static_cast<int>(preorder.size()), CountNodes(result));

    FreeTree(result);
}

#pragma endregion

#pragma region LeetCode Examples - IterativeOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_Example1_ReturnsCorrectTree) {
    std::vector<int> preorder = { 3, 9, 20, 15, 7 };
    std::vector<int> inorder = { 9, 3, 15, 20, 7 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    ASSERT_NE(nullptr, result);
    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(9, result->left->val);
    ASSERT_EQ(20, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_Example2_SingleNode_ReturnsCorrectTree) {
    std::vector<int> preorder = { -1 };
    std::vector<int> inorder = { -1 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    ASSERT_NE(nullptr, result);
    ASSERT_EQ(-1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

#pragma endregion

#pragma region Two Node Trees - IterativeOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_TwoNodes_LeftChild_ReturnsCorrectTree) {
    std::vector<int> preorder = { 2, 1 };
    std::vector<int> inorder = { 1, 2 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(1, result->left->val);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_TwoNodes_RightChild_ReturnsCorrectTree) {
    std::vector<int> preorder = { 1, 2 };
    std::vector<int> inorder = { 1, 2 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(2, result->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Three Node Trees - IterativeOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_ThreeNodes_Balanced_ReturnsCorrectTree) {
    std::vector<int> preorder = { 2, 1, 3 };
    std::vector<int> inorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(1, result->left->val);
    ASSERT_EQ(3, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_ThreeNodes_LeftSkewed_ReturnsCorrectTree) {
    std::vector<int> preorder = { 3, 2, 1 };
    std::vector<int> inorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(2, result->left->val);
    ASSERT_EQ(1, result->left->left->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_ThreeNodes_RightSkewed_ReturnsCorrectTree) {
    std::vector<int> preorder = { 1, 2, 3 };
    std::vector<int> inorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(2, result->right->val);
    ASSERT_EQ(3, result->right->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Perfect Binary Trees - IterativeOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_PerfectTree_7Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 4, 2, 1, 3, 6, 5, 7 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(7, CountNodes(result));
    ASSERT_EQ(4, result->val);
    ASSERT_EQ(2, result->left->val);
    ASSERT_EQ(6, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_PerfectTree_15Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(15, CountNodes(result));
    ASSERT_EQ(8, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Skewed Trees - IterativeOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_LeftSkewed_5Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 5, 4, 3, 2, 1 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(5, CountNodes(result));
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_RightSkewed_5Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 1, 2, 3, 4, 5 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(5, CountNodes(result));
    ASSERT_EQ(nullptr, result->left);

    FreeTree(result);
}

#pragma endregion

#pragma region Edge Cases - Negative Values - IterativeOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_NegativeValues_ReturnsCorrectTree) {
    std::vector<int> preorder = { 0, -5, -8, -3, 5, 3, 8 };
    std::vector<int> inorder = { -8, -5, -3, 0, 3, 5, 8 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(0, result->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_AllNegativeValues_ReturnsCorrectTree) {
    std::vector<int> preorder = { -4, -6, -7, -5, -2, -3, -1 };
    std::vector<int> inorder = { -7, -6, -5, -4, -3, -2, -1 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(-4, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Boundary Cases - IterativeOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_MaxIntValue_ReturnsCorrectTree) {
    std::vector<int> preorder = { 0, INT_MIN, INT_MAX };
    std::vector<int> inorder = { INT_MIN, 0, INT_MAX };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(0, result->val);
    ASSERT_EQ(INT_MIN, result->left->val);
    ASSERT_EQ(INT_MAX, result->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Property-Based Tests - IterativeOptimized

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105_Tests, BuildTree_NodeCountMatchesArrayLength_ReturnsCorrectTree) {
    std::vector<int> preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    ASSERT_EQ(static_cast<int>(preorder.size()), CountNodes(result));

    FreeTree(result);
}

#pragma endregion

#pragma region LeetCode Examples - HashMap

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_Example1_ReturnsCorrectTree) {
    std::vector<int> preorder = { 3, 9, 20, 15, 7 };
    std::vector<int> inorder = { 9, 3, 15, 20, 7 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    ASSERT_NE(nullptr, result);
    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(9, result->left->val);
    ASSERT_EQ(20, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_Example2_SingleNode_ReturnsCorrectTree) {
    std::vector<int> preorder = { -1 };
    std::vector<int> inorder = { -1 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    ASSERT_NE(nullptr, result);
    ASSERT_EQ(-1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

#pragma endregion

#pragma region Two Node Trees - HashMap

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_TwoNodes_LeftChild_ReturnsCorrectTree) {
    std::vector<int> preorder = { 2, 1 };
    std::vector<int> inorder = { 1, 2 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(1, result->left->val);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_TwoNodes_RightChild_ReturnsCorrectTree) {
    std::vector<int> preorder = { 1, 2 };
    std::vector<int> inorder = { 1, 2 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(2, result->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Three Node Trees - HashMap

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_ThreeNodes_Balanced_ReturnsCorrectTree) {
    std::vector<int> preorder = { 2, 1, 3 };
    std::vector<int> inorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(1, result->left->val);
    ASSERT_EQ(3, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_ThreeNodes_LeftSkewed_ReturnsCorrectTree) {
    std::vector<int> preorder = { 3, 2, 1 };
    std::vector<int> inorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(2, result->left->val);
    ASSERT_EQ(1, result->left->left->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_ThreeNodes_RightSkewed_ReturnsCorrectTree) {
    std::vector<int> preorder = { 1, 2, 3 };
    std::vector<int> inorder = { 1, 2, 3 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(2, result->right->val);
    ASSERT_EQ(3, result->right->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Perfect Binary Trees - HashMap

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_PerfectTree_7Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 4, 2, 1, 3, 6, 5, 7 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(7, CountNodes(result));
    ASSERT_EQ(4, result->val);
    ASSERT_EQ(2, result->left->val);
    ASSERT_EQ(6, result->right->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_PerfectTree_15Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(15, CountNodes(result));
    ASSERT_EQ(8, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Skewed Trees - HashMap

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_LeftSkewed_5Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 5, 4, 3, 2, 1 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(5, CountNodes(result));
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_RightSkewed_5Nodes_ReturnsCorrectTree) {
    std::vector<int> preorder = { 1, 2, 3, 4, 5 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(5, CountNodes(result));
    ASSERT_EQ(nullptr, result->left);

    FreeTree(result);
}

#pragma endregion

#pragma region Edge Cases - Negative Values - HashMap

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_NegativeValues_ReturnsCorrectTree) {
    std::vector<int> preorder = { 0, -5, -8, -3, 5, 3, 8 };
    std::vector<int> inorder = { -8, -5, -3, 0, 3, 5, 8 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(0, result->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_AllNegativeValues_ReturnsCorrectTree) {
    std::vector<int> preorder = { -4, -6, -7, -5, -2, -3, -1 };
    std::vector<int> inorder = { -7, -6, -5, -4, -3, -2, -1 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(-4, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Boundary Cases - HashMap

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_MaxIntValue_ReturnsCorrectTree) {
    std::vector<int> preorder = { 0, INT_MIN, INT_MAX };
    std::vector<int> inorder = { INT_MIN, 0, INT_MAX };

    TreeNode* result = solution.buildTree(preorder, inorder);

    AssertTreeStructure(result, preorder, inorder);
    ASSERT_EQ(0, result->val);
    ASSERT_EQ(INT_MIN, result->left->val);
    ASSERT_EQ(INT_MAX, result->right->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Property-Based Tests - HashMap

TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_NodeCountMatchesArrayLength_ReturnsCorrectTree) {
    std::vector<int> preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
    std::vector<int> inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

    TreeNode* result = solution.buildTree(preorder, inorder);

    ASSERT_EQ(static_cast<int>(preorder.size()), CountNodes(result));

    FreeTree(result);
}

// This test would expose boundary inconsistency more clearly
TEST_F(ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105_Tests, BuildTree_RightmostLeaf_HandledCorrectly) {
    // Tree where rightmost element is at the end
    // This exercises the inRight boundary more directly
    std::vector<int> preorder = { 1, 2 };
    std::vector<int> inorder = { 1, 2 };
    
    TreeNode* result = solution.buildTree(preorder, inorder);
    
    ASSERT_NE(nullptr, result);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_NE(nullptr, result->right);
    ASSERT_EQ(2, result->right->val);
    ASSERT_EQ(nullptr, result->right->left);
    ASSERT_EQ(nullptr, result->right->right);
    
    FreeTree(result);
}

#pragma endregion
