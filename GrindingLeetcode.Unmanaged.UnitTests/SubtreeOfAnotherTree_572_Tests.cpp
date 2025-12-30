#include "gtest/gtest.h"
#include "TreeNode.h"
#include "SubtreeOfAnotherTree_Recursive_572.h"
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

// Test fixture for SubtreeOfAnotherTree_Recursive_572
class SubtreeOfAnotherTree_Recursive_572_Tests : public ::testing::Test {
protected:
    SubtreeOfAnotherTree_Recursive_572 solution;

    void TearDown() override {
        // Cleanup is handled by FreeTree in each test
    }
};

#pragma region LeetCode Examples

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_Example1_ReturnsTrue) {
    // Input: root = [3,4,5,1,2], subRoot = [4,1,2]
    //       3              4
    //      / \            / \
    //     4   5          1   2
    //    / \
    //   1   2
    // Output: true
    // Explanation: The subtree rooted at 4 matches subRoot exactly

    // Arrange
    TreeNode* root = CreateTree({ 3, 4, 5, 1, 2 });
    TreeNode* subroot = CreateTree({ 4, 1, 2 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_Example2_ReturnsFalse) {
    // Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
    //       3              4
    //      / \            / \
    //     4   5          1   2
    //    / \
    //   1   2
    //      /
    //     0
    // Output: false
    // Explanation: The tree rooted at 4 has an extra node (0), so it doesn't match subRoot

    // Arrange
    TreeNode* root = CreateTree({ 3, 4, 5, 1, 2, -1001, -1001, -1001, -1001, 0 });
    TreeNode* subroot = CreateTree({ 4, 1, 2 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Basic Cases

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_BothNull_ReturnsTrue) {
    // Input: root = [], subRoot = []
    // Output: true
    // Explanation: Both trees are empty

    // Arrange
    TreeNode* root = nullptr;
    TreeNode* subroot = nullptr;

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SubrootNull_ReturnsTrue) {
    // Input: root = [1,2,3], subRoot = []
    // Output: true
    // Explanation: An empty tree is a subtree of any tree

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3 });
    TreeNode* subroot = nullptr;

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_RootNull_ReturnsFalse) {
    // Input: root = [], subRoot = [1]
    // Output: false
    // Explanation: Cannot find a non-empty subtree in an empty tree

    // Arrange
    TreeNode* root = nullptr;
    TreeNode* subroot = new TreeNode(1);

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_IdenticalTrees_ReturnsTrue) {
    // Input: root = [1,2,3], subRoot = [1,2,3]
    //    1         1
    //   / \       / \
    //  2   3     2   3
    // Output: true
    // Explanation: The entire tree matches

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3 });
    TreeNode* subroot = CreateTree({ 1, 2, 3 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SingleNodeSame_ReturnsTrue) {
    // Input: root = [5], subRoot = [5]
    // Output: true

    // Arrange
    TreeNode* root = new TreeNode(5);
    TreeNode* subroot = new TreeNode(5);

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SingleNodeDifferent_ReturnsFalse) {
    // Input: root = [5], subRoot = [3]
    // Output: false

    // Arrange
    TreeNode* root = new TreeNode(5);
    TreeNode* subroot = new TreeNode(3);

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Subtree at Root

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SubtreeAtRoot_ReturnsTrue) {
    // Input: root = [1,2,3], subRoot = [1,2,3]
    // Output: true
    // Explanation: Subtree matches at root

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3 });
    TreeNode* subroot = CreateTree({ 1, 2, 3 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SubtreeAtRootLarger_ReturnsTrue) {
    // Input: root = [4,2,6,1,3,5,7], subRoot = [4,2,6,1,3,5,7]
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 4, 2, 6, 1, 3, 5, 7 });
    TreeNode* subroot = CreateTree({ 4, 2, 6, 1, 3, 5, 7 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Subtree in Left Subtree

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SubtreeInLeftChild_ReturnsTrue) {
    // Input: root = [5,3,8,2,4], subRoot = [3,2,4]
    //       5              3
    //      / \            / \
    //     3   8          2   4
    //    / \
    //   2   4
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 5, 3, 8, 2, 4 });
    TreeNode* subroot = CreateTree({ 3, 2, 4 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SubtreeDeepInLeft_ReturnsTrue) {
    // Input: root = [10,5,15,3,7,null,20,1,4], subRoot = [3,1,4]
    //           10                3
    //          /  \              / \
    //         5    15           1   4
    //        / \     \
    //       3   7     20
    //      / \
    //     1   4
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 10, 5, 15, 3, 7, -1001, 20, 1, 4 });
    TreeNode* subroot = CreateTree({ 3, 1, 4 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SubtreeLeftLeaf_ReturnsTrue) {
    // Input: root = [5,3,8,2,4], subRoot = [2]
    //       5
    //      / \
    //     3   8
    //    / \
    //   2   4
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 5, 3, 8, 2, 4 });
    TreeNode* subroot = CreateTree({ 2 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Subtree in Right Subtree

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SubtreeInRightChild_ReturnsTrue) {
    // Input: root = [5,2,8,null,null,6,9], subRoot = [8,6,9]
    //       5              8
    //      / \            / \
    //     2   8          6   9
    //        / \
    //       6   9
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 5, 2, 8, -1001, -1001, 6, 9 });
    TreeNode* subroot = CreateTree({ 8, 6, 9 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SubtreeDeepInRight_ReturnsTrue) {
    // Input: root = [10,5,15,null,null,12,20,null,18], subRoot = [12,null,18]
    //           10               12
    //          /  \                \
    //         5    15               18
    //             /  \
    //            12   20
    //              \
    //               18
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 10, 5, 15, -1001, -1001, 12, 20, -1001, 18 });
    TreeNode* subroot = CreateTree({ 12, -1001, 18 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SubtreeRightLeaf_ReturnsTrue) {
    // Input: root = [5,2,8,null,null,6,9], subRoot = [9]
    //       5
    //      / \
    //     2   8
    //        / \
    //       6   9
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 5, 2, 8, -1001, -1001, 6, 9 });
    TreeNode* subroot = CreateTree({ 9 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Not a Subtree - Structure Mismatch

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_ExtraNodeInRoot_ReturnsFalse) {
    // Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
    // Output: false
    // Explanation: Root has extra node (0) under 2

    // Arrange
    TreeNode* root = CreateTree({ 3, 4, 5, 1, 2, -1001, -1001, -1001, -1001, 0 });
    TreeNode* subroot = CreateTree({ 4, 1, 2 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_MissingNodeInRoot_ReturnsFalse) {
    // Input: root = [3,4,5,1], subRoot = [4,1,2]
    // Output: false
    // Explanation: Root's subtree at 4 is missing node 2

    // Arrange
    TreeNode* root = CreateTree({ 3, 4, 5, 1 });
    TreeNode* subroot = CreateTree({ 4, 1, 2 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_DifferentStructure_ReturnsFalse) {
    // Input: root = [1,2,3], subRoot = [1,3,2]
    //    1         1
    //   / \       / \
    //  2   3     3   2
    // Output: false

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3 });
    TreeNode* subroot = CreateTree({ 1, 3, 2 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_LeftVsRightPosition_ReturnsFalse) {
    // Input: root = [1,2,null], subRoot = [1,null,2]
    //    1         1
    //   /           \
    //  2             2
    // Output: false

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, -1001 });
    TreeNode* subroot = CreateTree({ 1, -1001, 2 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Not a Subtree - Value Mismatch

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_DifferentRootValue_ReturnsFalse) {
    // Input: root = [3,4,5,1,2], subRoot = [4,1,3]
    // Output: false
    // Explanation: Subtree has 3 but root's subtree has 2

    // Arrange
    TreeNode* root = CreateTree({ 3, 4, 5, 1, 2 });
    TreeNode* subroot = CreateTree({ 4, 1, 3 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_DifferentLeafValue_ReturnsFalse) {
    // Input: root = [3,4,5,1,2], subRoot = [4,1,9]
    // Output: false

    // Arrange
    TreeNode* root = CreateTree({ 3, 4, 5, 1, 2 });
    TreeNode* subroot = CreateTree({ 4, 1, 9 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_NoMatchingStartNode_ReturnsFalse) {
    // Input: root = [3,4,5,1,2], subRoot = [6,7,8]
    // Output: false
    // Explanation: Value 6 doesn't exist in root

    // Arrange
    TreeNode* root = CreateTree({ 3, 4, 5, 1, 2 });
    TreeNode* subroot = CreateTree({ 6, 7, 8 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Edge Cases - Values

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_NegativeValues_ReturnsTrue) {
    // Input: root = [0,-2,2,-3,-1,1,3], subRoot = [-2,-3,-1]
    //        0                 -2
    //       / \               /  \
    //     -2   2            -3   -1
    //     / \ / \
    //   -3 -1 1  3
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 0, -2, 2, -3, -1, 1, 3 });
    TreeNode* subroot = CreateTree({ -2, -3, -1 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_AllNegativeValues_ReturnsTrue) {
    // Input: root = [-4,-6,-2,-7,-5,-3,-1], subRoot = [-6,-7,-5]
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ -4, -6, -2, -7, -5, -3, -1 });
    TreeNode* subroot = CreateTree({ -6, -7, -5 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_DuplicateValues_ReturnsTrue) {
    // Input: root = [5,5,5,5,5,5,5], subRoot = [5,5,5]
    //      5              5
    //     / \            / \
    //    5   5          5   5
    //   / \ / \
    //  5  5 5  5
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 5, 5, 5, 5, 5, 5, 5 });
    TreeNode* subroot = CreateTree({ 5, 5, 5 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_DuplicateValuesNoMatch_ReturnsFalse) {
    // Input: root = [2,2,2,1,2], subRoot = [2,2,2]
    //      2              2
    //     / \            / \
    //    2   2          2   2
    //   / \
    //  1   2
    // Output: false (structure doesn't match)

    // Arrange
    TreeNode* root = CreateTree({ 2, 2, 2, 1, 2 });
    TreeNode* subroot = CreateTree({ 2, 2, 2 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_ZeroValues_ReturnsTrue) {
    // Input: root = [0,0,0], subRoot = [0]
    //      0
    //     / \
    //    0   0
    // Output: true

    // Arrange
    TreeNode* root = CreateSimpleTree(0, 0, 0);
    TreeNode* subroot = new TreeNode(0);

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_LargeValues_ReturnsTrue) {
    // Input: root = [10000,-10000,5000,100,200], subRoot = [-10000,100,200]
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 10000, -10000, 5000, 100, 200 });
    TreeNode* subroot = CreateTree({ -10000, 100, 200 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Tricky Cases - Partial Matches

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_PartialMatch_ReturnsTrue) {
    // Input: root = [1,1], subRoot = [1]
    //    1
    //   /
    //  1
    // Output: true (leaf 1 matches)

    // Arrange
    TreeNode* root = CreateTree({ 1, 1 });
    TreeNode* subroot = CreateTree({ 1 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_ValueMatchButStructureDifferent_ReturnsFalse) {
    // Input: root = [3,4,5,1,2], subRoot = [3,1,2]
    // Output: false
    // Explanation: Root value 3 matches but structure is different

    // Arrange
    TreeNode* root = CreateTree({ 3, 4, 5, 1, 2 });
    TreeNode* subroot = CreateTree({ 3, 1, 2 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SubsetNotSubtree_ReturnsFalse) {
    // Input: root = [3,4,5,1,2], subRoot = [4,null,2]
    //       3              4
    //      / \              \
    //     4   5              2
    //    / \
    //   1   2
    // Output: false
    // Explanation: Even though 4 and 2 exist, 4->2 is not the actual relationship

    // Arrange
    TreeNode* root = CreateTree({ 3, 4, 5, 1, 2 });
    TreeNode* subroot = CreateTree({ 4, -1001, 2 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Skewed Trees

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_LeftSkewedBothTrees_ReturnsTrue) {
    // Input: root = [5,4,null,3,null,2], subRoot = [4,3,null,2]
    //      5            4
    //     /            /
    //    4            3
    //   /            /
    //  3            2
    // /
    //2
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 5, 4, -1001, 3, -1001, 2 });
    TreeNode* subroot = CreateTree({ 4, 3, -1001, 2 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_RightSkewedBothTrees_ReturnsTrue) {
    // Input: root = [1,null,2,null,3,null,4], subRoot = [2,null,3,null,4]
    // 1            2
    //  \            \
    //   2            3
    //    \            \
    //     3            4
    //      \
    //       4
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 1, -1001, 2, -1001, 3, -1001, 4 });
    TreeNode* subroot = CreateTree({ 2, -1001, 3, -1001, 4 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Larger Trees

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_LargeTreeSmallSubtree_ReturnsTrue) {
    // Large balanced tree with small subtree match
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
    TreeNode* subroot = CreateTree({ 6, 5, 7 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_LargeTreeNoMatch_ReturnsFalse) {
    // Large tree but subtree doesn't match
    // Output: false

    // Arrange
    TreeNode* root = CreateTree({ 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 });
    TreeNode* subroot = CreateTree({ 6, 5, 8 }); // 8 doesn't match 7

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_VeryLargeIdenticalTrees_ReturnsTrue) {
    // Large identical trees (31 nodes)
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 
        16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
        1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
    });
    TreeNode* subroot = CreateTree({ 
        16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30,
        1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31
    });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Complex Patterns

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_ZigZagPattern_ReturnsTrue) {
    // Input: root = [1,null,2,3,null,null,4,5], subRoot = [2,3,null,null,4,5]
    //    1               2
    //     \             /
    //      2           3
    //     /             \
    //    3               4
    //     \             /
    //      4           5
    //     /
    //    5
    // Output: true

    // Arrange
    TreeNode* root = new TreeNode(1);
    root->right = new TreeNode(2);
    root->right->left = new TreeNode(3);
    root->right->left->right = new TreeNode(4);
    root->right->left->right->left = new TreeNode(5);

    TreeNode* subroot = new TreeNode(2);
    subroot->left = new TreeNode(3);
    subroot->left->right = new TreeNode(4);
    subroot->left->right->left = new TreeNode(5);

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SymmetricTree_ReturnsTrue) {
    // Input: root = [1,2,2,3,4,4,3], subRoot = [2,3,4]
    //        1              2
    //       / \            / \
    //      2   2          3   4
    //     / \ / \
    //    3  4 4  3
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 2, 3, 4, 4, 3 });
    TreeNode* subroot = CreateTree({ 2, 3, 4 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SparseTree_ReturnsTrue) {
    // Input: root = [8,4,12,null,6,10], subRoot = [4,null,6]
    //     8            4
    //    / \            \
    //   4   12           6
    //    \ /
    //     6 10
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 8, 4, 12, -1001, 6, 10 });
    TreeNode* subroot = CreateTree({ 4, -1001, 6 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Substring Value Edge Cases

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_ValueSubstringOfAnother_ReturnsFalse) {
    // CRITICAL TEST: Catches serialization delimiter bug
    // Input: root = [12], subRoot = [2]
    //    12        2
    // Output: false
    // Explanation: Value 2 is substring of 12, but trees don't match

    // Arrange
    TreeNode* root = new TreeNode(12);
    TreeNode* subroot = new TreeNode(2);

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_ValuePrefixOfAnother_ReturnsFalse) {
    // Input: root = [100], subRoot = [10]
    //    100       10
    // Output: false
    // Explanation: Value 10 is prefix of 100

    // Arrange
    TreeNode* root = new TreeNode(100);
    TreeNode* subroot = new TreeNode(10);

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_ValueSuffixOfAnother_ReturnsFalse) {
    // Input: root = [123], subRoot = [23]
    //    123       23
    // Output: false
    // Explanation: Value 23 is suffix of 123

    // Arrange
    TreeNode* root = new TreeNode(123);
    TreeNode* subroot = new TreeNode(23);

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_MultiDigitSubstringMatch_ReturnsFalse) {
    // Input: root = [1234,56,78], subRoot = [234]
    //      1234         234
    //      /  \
    //     56  78
    // Output: false
    // Explanation: 234 is substring of 1234 but not a subtree

    // Arrange
    TreeNode* root = CreateTree({ 1234, 56, 78 });
    TreeNode* subroot = new TreeNode(234);

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_NegativeValueSubstring_ReturnsFalse) {
    // Input: root = [-12], subRoot = [-2]
    //    -12       -2
    // Output: false
    // Explanation: Value -2 substring of -12

    // Arrange
    TreeNode* root = new TreeNode(-12);
    TreeNode* subroot = new TreeNode(-2);

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_ZeroInValue_ReturnsFalse) {
    // Input: root = [10], subRoot = [0]
    //    10        0
    // Output: false
    // Explanation: Value 0 appears in 10

    // Arrange
    TreeNode* root = new TreeNode(10);
    TreeNode* subroot = new TreeNode(0);

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_SubstringInLeftChild_ReturnsFalse) {
    // Input: root = [5,12,8], subRoot = [2]
    //      5         2
    //     / \
    //    12  8
    // Output: false
    // Explanation: 2 is substring of 12 (left child), but not a subtree

    // Arrange
    TreeNode* root = CreateTree({ 5, 12, 8 });
    TreeNode* subroot = new TreeNode(2);

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_ValueContainsSubrootValueButWrongStructure_ReturnsFalse) {
    // CRITICAL TEST for serialization approaches
    // Input: root = [12, 3, 4], subRoot = [2, 3, 4]
    //       12            2
    //       /  \         / \
    //      3    4       3   4
    // Output: false

    // Arrange
    TreeNode* root = CreateTree({ 12, 3, 4 });
    TreeNode* subroot = CreateTree({ 2, 3, 4 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_ActualMatchWithSimilarValues_ReturnsTrue) {
    // Positive test: Ensure logic doesn't break legitimate matches
    // Input: root = [12,2,8], subRoot = [2]
    //      12        2
    //     /  \
    //    2    8
    // Output: true
    // Explanation: 2 is left child, legitimate match

    // Arrange
    TreeNode* root = CreateTree({ 12, 2, 8 });
    TreeNode* subroot = new TreeNode(2);

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Property Tests

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_TreeIsSubtreeOfItself_ReturnsTrue) {
    // A tree is always a subtree of itself
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3, 4, 5, 6, 7 });
    TreeNode* subroot = CreateTree({ 1, 2, 3, 4, 5, 6, 7 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_LeafIsSubtreeOfTree_ReturnsTrue) {
    // Any leaf is a subtree of the tree containing it
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3, 4, 5, 6, 7 });
    TreeNode* subroot = new TreeNode(7); // Rightmost leaf

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_LargerTreeNotSubtree_ReturnsFalse) {
    // A larger tree cannot be a subtree of a smaller tree
    // Output: false

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 3 });
    TreeNode* subroot = CreateTree({ 1, 2, 3, 4, 5, 6, 7 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_FALSE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion

#pragma region Recursive Edge Cases

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_DeepRecursion_ReturnsTrue) {
    // Test deep recursion with left-skewed tree
    // Output: true

    // Arrange
    TreeNode* root = new TreeNode(10);
    TreeNode* current = root;
    for (int i = 9; i >= 1; i--) {
        current->left = new TreeNode(i);
        current = current->left;
    }

    TreeNode* subroot = new TreeNode(5);
    current = subroot;
    for (int i = 4; i >= 1; i--) {
        current->left = new TreeNode(i);
        current = current->left;
    }

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_DeepRightSkewed_ReturnsTrue) {
    // Test deep recursion with right-skewed tree
    // Output: true

    // Arrange
    TreeNode* root = new TreeNode(1);
    TreeNode* current = root;
    for (int i = 2; i <= 10; i++) {
        current->right = new TreeNode(i);
        current = current->right;
    }

    TreeNode* subroot = new TreeNode(5);
    current = subroot;
    for (int i = 6; i <= 10; i++) {
        current->right = new TreeNode(i);
        current = current->right;
    }

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

TEST_F(SubtreeOfAnotherTree_Recursive_572_Tests, IsSubtree_MultipleIdenticalSubtrees_ReturnsTrue) {
    // Tree has multiple identical subtrees, one should match
    // Input: root = [1,2,2,3,4,3,4], subRoot = [2,3,4]
    //        1              2
    //       / \            / \
    //      2   2          3   4
    //     / \ / \
    //    3  4 3  4
    // Output: true

    // Arrange
    TreeNode* root = CreateTree({ 1, 2, 2, 3, 4, 3, 4 });
    TreeNode* subroot = CreateTree({ 2, 3, 4 });

    // Act
    bool result = solution.isSubtree(root, subroot);

    // Assert
    ASSERT_TRUE(result);

    // Cleanup
    FreeTree(root);
    FreeTree(subroot);
}

#pragma endregion
