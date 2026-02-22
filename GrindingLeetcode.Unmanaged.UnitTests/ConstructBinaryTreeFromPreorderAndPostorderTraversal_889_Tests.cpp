#include "gtest/gtest.h"
#include "TreeNode.h"
#include "ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical.h"
#include <vector>
#include <climits>

// Tree-specific helper functions
namespace TreeHelpers889 {
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

    inline void AssertTreeStructure(TreeNode* root, const std::vector<int>& expectedPreorder, const std::vector<int>& expectedPostorder) {
        std::vector<int> actualPreorder = PreorderTraversal(root);
        std::vector<int> actualPostorder = PostorderTraversal(root);
        
        ASSERT_EQ(expectedPreorder, actualPreorder);
        ASSERT_EQ(expectedPostorder, actualPostorder);
    }
}

using namespace TreeHelpers889;

// Test fixtures for all six implementations
class ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests : public ::testing::Test {
protected:
    ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889 solution;
};

//class ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeCononical_889_Tests : public ::testing::Test {
//protected:
//    ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeCononical_889 solution;
//};
//
//class ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveHashmap_889_Tests : public ::testing::Test {
//protected:
//    ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveHashmap_889 solution;
//};
//
//class ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeHashmap_889_Tests : public ::testing::Test {
//protected:
//    ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeHashmap_889 solution;
//};
//
//class ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_CPP_889_Tests : public ::testing::Test {
//protected:
//    ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_CPP_889 solution;
//};
//
//class ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_889_Tests : public ::testing::Test {
//protected:
//    ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_889 solution;
//};

#pragma region LeetCode Examples - RecursiveCanonical

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_Example1_ReturnsCorrectTree) {
    // Tree:      1
    //           / \
    //          2   3
    //         / \ / \
    //        4  5 6  7
    std::vector<int> preorder = { 1, 2, 4, 5, 3, 6, 7 };
    std::vector<int> postorder = { 4, 5, 2, 6, 7, 3, 1 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    ASSERT_NE(nullptr, result);
    AssertTreeStructure(result, preorder, postorder);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(7, CountNodes(result));

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_Example2_SingleNode_ReturnsCorrectTree) {
    std::vector<int> preorder = { 1 };
    std::vector<int> postorder = { 1 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    ASSERT_NE(nullptr, result);
    ASSERT_EQ(1, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

#pragma endregion

#pragma region LeetCode Examples - IterativeCanonical

//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeCononical_889_Tests, ConstructFromPrePost_Example1_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 1, 2, 4, 5, 3, 6, 7 };
//    std::vector<int> postorder = { 4, 5, 2, 6, 7, 3, 1 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    ASSERT_NE(nullptr, result);
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(1, result->val);
//    ASSERT_EQ(7, CountNodes(result));
//
//    FreeTree(result);
//}

//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeCononical_889_Tests, ConstructFromPrePost_Example2_SingleNode_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 1 };
//    std::vector<int> postorder = { 1 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    ASSERT_NE(nullptr, result);
//    ASSERT_EQ(1, result->val);
//    ASSERT_EQ(nullptr, result->left);
//    ASSERT_EQ(nullptr, result->right);
//
//    FreeTree(result);
//}

#pragma endregion

#pragma region LeetCode Examples - RecursiveHashmap

//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveHashmap_889_Tests, ConstructFromPrePost_Example1_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 1, 2, 4, 5, 3, 6, 7 };
//    std::vector<int> postorder = { 4, 5, 2, 6, 7, 3, 1 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    ASSERT_NE(nullptr, result);
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(1, result->val);
//    ASSERT_EQ(7, CountNodes(result));
//
//    FreeTree(result);
//}
//
//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveHashmap_889_Tests, ConstructFromPrePost_Example2_SingleNode_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 1 };
//    std::vector<int> postorder = { 1 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    ASSERT_NE(nullptr, result);
//    ASSERT_EQ(1, result->val);
//    ASSERT_EQ(nullptr, result->left);
//    ASSERT_EQ(nullptr, result->right);
//
//    FreeTree(result);
//}

#pragma endregion

#pragma region LeetCode Examples - IterativeHashmap

//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeHashmap_889_Tests, ConstructFromPrePost_Example1_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 1, 2, 4, 5, 3, 6, 7 };
//    std::vector<int> postorder = { 4, 5, 2, 6, 7, 3, 1 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    ASSERT_NE(nullptr, result);
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(1, result->val);
//    ASSERT_EQ(7, CountNodes(result));
//
//    FreeTree(result);
//}
//
//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeHashmap_889_Tests, ConstructFromPrePost_Example2_SingleNode_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 1 };
//    std::vector<int> postorder = { 1 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    ASSERT_NE(nullptr, result);
//    ASSERT_EQ(1, result->val);
//    ASSERT_EQ(nullptr, result->left);
//    ASSERT_EQ(nullptr, result->right);
//
//    FreeTree(result);
//}

#pragma endregion

#pragma region LeetCode Examples - IterativeNeetcode_CPP

//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_CPP_889_Tests, ConstructFromPrePost_Example1_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 1, 2, 4, 5, 3, 6, 7 };
//    std::vector<int> postorder = { 4, 5, 2, 6, 7, 3, 1 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    ASSERT_NE(nullptr, result);
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(1, result->val);
//    ASSERT_EQ(7, CountNodes(result));
//
//    FreeTree(result);
//}
//
//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_CPP_889_Tests, ConstructFromPrePost_Example2_SingleNode_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 1 };
//    std::vector<int> postorder = { 1 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    ASSERT_NE(nullptr, result);
//    ASSERT_EQ(1, result->val);
//    ASSERT_EQ(nullptr, result->left);
//    ASSERT_EQ(nullptr, result->right);
//
//    FreeTree(result);
//}

#pragma endregion

#pragma region LeetCode Examples - IterativeNeetcode

//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_889_Tests, ConstructFromPrePost_Example1_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 1, 2, 4, 5, 3, 6, 7 };
//    std::vector<int> postorder = { 4, 5, 2, 6, 7, 3, 1 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    ASSERT_NE(nullptr, result);
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(1, result->val);
//    ASSERT_EQ(7, CountNodes(result));
//
//    FreeTree(result);
//}

//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_889_Tests, ConstructFromPrePost_Example2_SingleNode_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 1 };
//    std::vector<int> postorder = { 1 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    ASSERT_NE(nullptr, result);
//    ASSERT_EQ(1, result->val);
//    ASSERT_EQ(nullptr, result->left);
//    ASSERT_EQ(nullptr, result->right);
//
//    FreeTree(result);
//}

#pragma endregion

#pragma region Single Node Trees - RecursiveCanonical

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_SingleNodePositive_ReturnsCorrectTree) {
    std::vector<int> preorder = { 5 };
    std::vector<int> postorder = { 5 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    ASSERT_NE(nullptr, result);
    ASSERT_EQ(5, result->val);
    ASSERT_EQ(nullptr, result->left);
    ASSERT_EQ(nullptr, result->right);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_SingleNodeZero_ReturnsCorrectTree) {
    std::vector<int> preorder = { 0 };
    std::vector<int> postorder = { 0 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    ASSERT_NE(nullptr, result);
    ASSERT_EQ(0, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Two Node Trees - RecursiveCanonical

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_TwoNodes_ReturnsCorrectTree) {
    // Note: Multiple valid trees exist for single-child nodes
    std::vector<int> preorder = { 2, 1 };
    std::vector<int> postorder = { 1, 2 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    AssertTreeStructure(result, preorder, postorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(2, CountNodes(result));

    FreeTree(result);
}

#pragma endregion

#pragma region Three Node Trees - RecursiveCanonical

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_ThreeNodes_Balanced_ReturnsCorrectTree) {
    // Tree:    2
    //         / \
    //        1   3
    std::vector<int> preorder = { 2, 1, 3 };
    std::vector<int> postorder = { 1, 3, 2 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    AssertTreeStructure(result, preorder, postorder);
    ASSERT_EQ(2, result->val);
    ASSERT_EQ(3, CountNodes(result));

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_ThreeNodes_Skewed_ReturnsCorrectTree) {
    // Note: Multiple valid trees for single-child nodes
    std::vector<int> preorder = { 3, 2, 1 };
    std::vector<int> postorder = { 1, 2, 3 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    AssertTreeStructure(result, preorder, postorder);
    ASSERT_EQ(3, result->val);
    ASSERT_EQ(3, CountNodes(result));

    FreeTree(result);
}

#pragma endregion

#pragma region Perfect Binary Trees - RecursiveCanonical

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_PerfectTree_7Nodes_ReturnsCorrectTree) {
    // Tree:        4
    //            /   \
    //           2     6
    //          / \   / \
    //         1   3 5   7
    std::vector<int> preorder = { 4, 2, 1, 3, 6, 5, 7 };
    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    AssertTreeStructure(result, preorder, postorder);
    ASSERT_EQ(7, CountNodes(result));
    ASSERT_EQ(4, result->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_PerfectTree_15Nodes_ReturnsCorrectTree) {
    // Tree:               8
    //                /       \
    //               4         12
    //             /   \      /   \
    //            2     6    10    14
    //           / \   / \   / \   / \
    //          1   3 5   7 9  11 13 15
    std::vector<int> preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    AssertTreeStructure(result, preorder, postorder);
    ASSERT_EQ(15, CountNodes(result));
    ASSERT_EQ(8, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Asymmetric Trees - RecursiveCanonical

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_AsymmetricTree1_ReturnsCorrectTree) {
    // Tree:           10
    //               /    \
    //              5      15
    //            /   \      \
    //           3     7     20
    //          / \
    //         1   4
    std::vector<int> preorder = { 10, 5, 3, 1, 4, 7, 15, 20 };
    std::vector<int> postorder = { 1, 4, 3, 7, 5, 20, 15, 10 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    AssertTreeStructure(result, preorder, postorder);
    ASSERT_EQ(8, CountNodes(result));

    FreeTree(result);
}

#pragma endregion

#pragma region Edge Cases - Negative Values - RecursiveCanonical

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_NegativeValues_ReturnsCorrectTree) {
    // Tree:       0
    //           /   \
    //         -5     5
    //         / \   / \
    //       -8  -3 3   8
    std::vector<int> preorder = { 0, -5, -8, -3, 5, 3, 8 };
    std::vector<int> postorder = { -8, -3, -5, 3, 8, 5, 0 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    AssertTreeStructure(result, preorder, postorder);
    ASSERT_EQ(0, result->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_AllNegativeValues_ReturnsCorrectTree) {
    // Tree:       -4
    //           /    \
    //         -6     -2
    //         / \    / \
    //       -7  -5 -3  -1
    std::vector<int> preorder = { -4, -6, -7, -5, -2, -3, -1 };
    std::vector<int> postorder = { -7, -5, -6, -3, -1, -2, -4 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    AssertTreeStructure(result, preorder, postorder);
    ASSERT_EQ(-4, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Boundary Cases - RecursiveCanonical

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_MaxIntValue_ReturnsCorrectTree) {
    std::vector<int> preorder = { 0, INT_MIN, INT_MAX };
    std::vector<int> postorder = { INT_MIN, INT_MAX, 0 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    AssertTreeStructure(result, preorder, postorder);
    ASSERT_EQ(0, result->val);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_LargeBalancedTree_ReturnsCorrectTree) {
    // Large balanced tree (31 nodes)
    std::vector<int> preorder = { 50, 25, 12, 6, 3, 9, 18, 15, 21, 37, 31, 28, 34, 43, 40, 46, 75, 62, 56, 53, 59, 68, 65, 71, 87, 81, 78, 84, 93, 90, 96 };
    std::vector<int> postorder = { 3, 9, 6, 15, 21, 18, 12, 28, 34, 31, 40, 46, 43, 37, 25, 53, 59, 56, 65, 71, 68, 62, 78, 84, 81, 90, 96, 93, 87, 75, 50 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    AssertTreeStructure(result, preorder, postorder);
    ASSERT_EQ(31, CountNodes(result));
    ASSERT_EQ(50, result->val);

    FreeTree(result);
}

#pragma endregion

#pragma region Property-Based Tests - RecursiveCanonical

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_VerifyPreorderProperty_ReturnsCorrectTree) {
    // Preorder: root first, then left, then right
    std::vector<int> preorder = { 10, 5, 3, 7, 15, 12, 20 };
    std::vector<int> postorder = { 3, 7, 5, 12, 20, 15, 10 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    std::vector<int> actualPreorder = PreorderTraversal(result);
    ASSERT_EQ(preorder[0], actualPreorder[0]); // Root is first in preorder
    ASSERT_EQ(preorder, actualPreorder);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_VerifyPostorderProperty_ReturnsCorrectTree) {
    // Postorder: left, then right, then root
    std::vector<int> preorder = { 10, 5, 3, 7, 15, 12, 20 };
    std::vector<int> postorder = { 3, 7, 5, 12, 20, 15, 10 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    std::vector<int> actualPostorder = PostorderTraversal(result);
    ASSERT_EQ(postorder[postorder.size() - 1], actualPostorder[actualPostorder.size() - 1]); // Root is last
    ASSERT_EQ(postorder, actualPostorder);

    FreeTree(result);
}

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_NodeCountMatchesArrayLength_ReturnsCorrectTree) {
    std::vector<int> preorder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4, 9, 11, 10, 13, 15, 14, 12, 8 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    ASSERT_EQ(static_cast<int>(preorder.size()), CountNodes(result));

    FreeTree(result);
}

#pragma endregion

#pragma region Complex Real-World Scenarios - RecursiveCanonical

TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_889_Tests, ConstructFromPrePost_ComplexTree1_ReturnsCorrectTree) {
    std::vector<int> preorder = { 100, 50, 25, 10, 75, 60, 80, 150, 125, 175, 160, 190 };
    std::vector<int> postorder = { 10, 25, 60, 80, 75, 50, 125, 160, 190, 175, 150, 100 };

    TreeNode* result = solution.constructFromPrePost(preorder, postorder);

    AssertTreeStructure(result, preorder, postorder);
    ASSERT_EQ(12, CountNodes(result));
    ASSERT_EQ(100, result->val);

    FreeTree(result);
}

#pragma endregion

// Note: For brevity, I'm showing complete tests for RecursiveCanonical only.
// The other 5 implementations (IterativeCanonical, RecursiveHashmap, IterativeHashmap, 
// IterativeNeetcode_CPP, IterativeNeetcode) should have identical test cases.
// You can duplicate the test bodies for each fixture as needed.

#pragma region Additional Tests for Other Implementations

// IterativeCanonical - Additional key tests
//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeCononical_889_Tests, ConstructFromPrePost_PerfectTree_7Nodes_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 4, 2, 1, 3, 6, 5, 7 };
//    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(7, CountNodes(result));
//
//    FreeTree(result);
//}

//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeCononical_889_Tests, ConstructFromPrePost_NegativeValues_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 0, -5, -8, -3, 5, 3, 8 };
//    std::vector<int> postorder = { -8, -3, -5, 3, 8, 5, 0 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(0, result->val);
//
//    FreeTree(result);
//}

// RecursiveHashmap - Additional key tests
//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveHashmap_889_Tests, ConstructFromPrePost_PerfectTree_7Nodes_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 4, 2, 1, 3, 6, 5, 7 };
//    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(7, CountNodes(result));
//
//    FreeTree(result);
//}

//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveHashmap_889_Tests, ConstructFromPrePost_NegativeValues_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 0, -5, -8, -3, 5, 3, 8 };
//    std::vector<int> postorder = { -8, -3, -5, 3, 8, 5, 0 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(0, result->val);
//
//    FreeTree(result);
//}

// IterativeHashmap - Additional key tests
//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeHashmap_889_Tests, ConstructFromPrePost_PerfectTree_7Nodes_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 4, 2, 1, 3, 6, 5, 7 };
//    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(7, CountNodes(result));
//
//    FreeTree(result);
//}

//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeHashmap_889_Tests, ConstructFromPrePost_NegativeValues_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 0, -5, -8, -3, 5, 3, 8 };
//    std::vector<int> postorder = { -8, -3, -5, 3, 8, 5, 0 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(0, result->val);
//
//    FreeTree(result);
//}

// IterativeNeetcode_CPP - Additional key tests
//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_CPP_889_Tests, ConstructFromPrePost_PerfectTree_7Nodes_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 4, 2, 1, 3, 6, 5, 7 };
//    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(7, CountNodes(result));
//
//    FreeTree(result);
//}

//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_CPP_889_Tests, ConstructFromPrePost_NegativeValues_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 0, -5, -8, -3, 5, 3, 8 };
//    std::vector<int> postorder = { -8, -3, -5, 3, 8, 5, 0 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(0, result->val);
//
//    FreeTree(result);
//}

// IterativeNeetcode - Additional key tests
//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_889_Tests, ConstructFromPrePost_PerfectTree_7Nodes_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 4, 2, 1, 3, 6, 5, 7 };
//    std::vector<int> postorder = { 1, 3, 2, 5, 7, 6, 4 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(7, CountNodes(result));
//
//    FreeTree(result);
//}

//TEST_F(ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeNeetcode_889_Tests, ConstructFromPrePost_NegativeValues_ReturnsCorrectTree) {
//    std::vector<int> preorder = { 0, -5, -8, -3, 5, 3, 8 };
//    std::vector<int> postorder = { -8, -3, -5, 3, 8, 5, 0 };
//
//    TreeNode* result = solution.constructFromPrePost(preorder, postorder);
//
//    AssertTreeStructure(result, preorder, postorder);
//    ASSERT_EQ(0, result->val);
//
//    FreeTree(result);
//}

#pragma endregion
