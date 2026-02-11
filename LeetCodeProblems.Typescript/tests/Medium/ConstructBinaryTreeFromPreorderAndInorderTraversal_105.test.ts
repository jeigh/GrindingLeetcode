import { TreeNode } from '../../src/Shared/TreeNode';
import { ConstructBinaryTreeFromPreorderAndInorderTraversal_FiveParams_105 } from '../../src/Medium/ConstructBinaryTreeFromPreorderAndInorderTraversal_RecursiveFiveParameters_105';
import { ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105 } from '../../src/Medium/ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105';
import { ConstructBinaryTreeFromPreorderAndInorderTraversal_Iterative_105 } from '../../src/Medium/ConstructBinaryTreeFromPreorderAndInorderTraversal_Iterative_105';
import { ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105 } from '../../src/Medium/ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105';
import { IConstructBinaryTreeFromPreorderAndInorderTraversal_105 } from '../../src/Interfaces/Medium/IConstructBinaryTreeFromPreorderAndInorderTraversal_105';

describe('ConstructBinaryTreeFromPreorderAndInorderTraversal_105', () => {
    const implementations: [IConstructBinaryTreeFromPreorderAndInorderTraversal_105, string][] = [
        [new ConstructBinaryTreeFromPreorderAndInorderTraversal_FiveParams_105(), 'Recursive Five Parameters'],
        [new ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105(), 'Recursive Six Parameters'],
        [new ConstructBinaryTreeFromPreorderAndInorderTraversal_Iterative_105(), 'Iterative'],
        [new ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105(), 'HashMap']
    ];

    /**
     * Helper function to perform preorder traversal
     */
    function preorderTraversal(root: TreeNode | null): number[] {
        const result: number[] = [];
        if (root === null) return result;

        result.push(root.val);
        result.push(...preorderTraversal(root.left));
        result.push(...preorderTraversal(root.right));

        return result;
    }

    /**
     * Helper function to perform inorder traversal
     */
    function inorderTraversal(root: TreeNode | null): number[] {
        const result: number[] = [];
        if (root === null) return result;

        result.push(...inorderTraversal(root.left));
        result.push(root.val);
        result.push(...inorderTraversal(root.right));

        return result;
    }

    /**
     * Helper function to count nodes in the tree
     */
    function countNodes(root: TreeNode | null): number {
        if (root === null) return 0;
        return 1 + countNodes(root.left) + countNodes(root.right);
    }

    implementations.forEach(([solution, name]) => {
        describe(name, () => {
            // LeetCode Examples
            describe('LeetCode Examples', () => {
                test('Example 1 - Constructs tree from preorder [3,9,20,15,7] and inorder [9,3,15,20,7]', () => {
                    const preorder = [3, 9, 20, 15, 7];
                    const inorder = [9, 3, 15, 20, 7];

                    const root = solution.buildTree(preorder, inorder);

                    expect(root).not.toBeNull();
                    expect(root!.val).toBe(3);
                    expect(root!.left).not.toBeNull();
                    expect(root!.left!.val).toBe(9);
                    expect(root!.right).not.toBeNull();
                    expect(root!.right!.val).toBe(20);
                    expect(root!.right!.left!.val).toBe(15);
                    expect(root!.right!.right!.val).toBe(7);

                    // Verify traversals match
                    expect(preorderTraversal(root)).toEqual(preorder);
                    expect(inorderTraversal(root)).toEqual(inorder);
                });

                test('Example 2 - Single node tree with preorder [1] and inorder [1]', () => {
                    const preorder = [1];
                    const inorder = [1];

                    const root = solution.buildTree(preorder, inorder);

                    expect(root).not.toBeNull();
                    expect(root!.val).toBe(1);
                    expect(root!.left).toBeNull();
                    expect(root!.right).toBeNull();

                    expect(preorderTraversal(root)).toEqual(preorder);
                    expect(inorderTraversal(root)).toEqual(inorder);
                });
            });

            // Edge Cases
            describe('Edge Cases', () => {
                test('Empty arrays should return null', () => {
                    const root = solution.buildTree([], []);

                    expect(root).toBeNull();
                });

                test('Left skewed tree (all nodes on left)', () => {
                    const preorder = [3, 2, 1];
                    const inorder = [1, 2, 3];

                    const root = solution.buildTree(preorder, inorder);

                    expect(root).not.toBeNull();
                    expect(root!.val).toBe(3);
                    expect(root!.left!.val).toBe(2);
                    expect(root!.left!.left!.val).toBe(1);
                    expect(root!.right).toBeNull();

                    expect(preorderTraversal(root)).toEqual(preorder);
                    expect(inorderTraversal(root)).toEqual(inorder);
                    expect(countNodes(root)).toBe(3);
                });

                test('Right skewed tree (all nodes on right)', () => {
                    const preorder = [1, 2, 3];
                    const inorder = [1, 2, 3];

                    const root = solution.buildTree(preorder, inorder);

                    expect(root).not.toBeNull();
                    expect(root!.val).toBe(1);
                    expect(root!.right!.val).toBe(2);
                    expect(root!.right!.right!.val).toBe(3);
                    expect(root!.left).toBeNull();

                    expect(preorderTraversal(root)).toEqual(preorder);
                    expect(inorderTraversal(root)).toEqual(inorder);
                    expect(countNodes(root)).toBe(3);
                });

                test('Balanced binary tree', () => {
                    const preorder = [4, 2, 1, 3, 6, 5, 7];
                    const inorder = [1, 2, 3, 4, 5, 6, 7];

                    const root = solution.buildTree(preorder, inorder);

                    expect(root).not.toBeNull();
                    expect(root!.val).toBe(4);
                    expect(countNodes(root)).toBe(7);

                    expect(preorderTraversal(root)).toEqual(preorder);
                    expect(inorderTraversal(root)).toEqual(inorder);
                });
            });

            // Property-based Tests
            describe('Property-based Tests', () => {
                test('Returned tree should have correct number of nodes', () => {
                    const preorder = [1, 2, 3, 4, 5];
                    const inorder = [5, 4, 3, 2, 1];

                    const root = solution.buildTree(preorder, inorder);

                    expect(countNodes(root)).toBe(preorder.length);
                });

                test('Preorder and inorder traversals should match input arrays', () => {
                    const preorder = [10, 5, 1, 7, 15, 12, 20];
                    const inorder = [1, 5, 7, 10, 12, 15, 20];

                    const root = solution.buildTree(preorder, inorder);

                    expect(preorderTraversal(root)).toEqual(preorder);
                    expect(inorderTraversal(root)).toEqual(inorder);
                });

                test('First element of preorder should be root', () => {
                    const preorder = [5, 3, 2, 4, 7, 6, 8];
                    const inorder = [2, 3, 4, 5, 6, 7, 8];

                    const root = solution.buildTree(preorder, inorder);

                    expect(root!.val).toBe(preorder[0]);
                });

                test('Elements to the left of root in inorder should be in left subtree', () => {
                    const preorder = [3, 1, 2];
                    const inorder = [1, 3, 2];

                    const root = solution.buildTree(preorder, inorder);

                    // 1 is to the left of 3 in inorder, so it should be in left subtree
                    expect(root!.left).not.toBeNull();
                    expect(root!.left!.val).toBe(1);
                    // 2 is to the right of 3 in inorder, so it should be in right subtree
                    expect(root!.right).not.toBeNull();
                    expect(root!.right!.val).toBe(2);
                });
            });

            // Complex Cases
            describe('Complex Cases', () => {
                test('Large balanced tree', () => {
                    const preorder = [8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15];
                    const inorder = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];

                    const root = solution.buildTree(preorder, inorder);

                    expect(root).not.toBeNull();
                    expect(countNodes(root)).toBe(15);
                    expect(preorderTraversal(root)).toEqual(preorder);
                    expect(inorderTraversal(root)).toEqual(inorder);
                });

                test('Tree with negative numbers', () => {
                    const preorder = [-3, -9, -20, -15, -7];
                    const inorder = [-9, -3, -15, -20, -7];

                    const root = solution.buildTree(preorder, inorder);

                    expect(root).not.toBeNull();
                    expect(root!.val).toBe(-3);
                    expect(preorderTraversal(root)).toEqual(preorder);
                    expect(inorderTraversal(root)).toEqual(inorder);
                });

                test('Tree with mixed positive and negative numbers', () => {
                    const preorder = [0, -1, -2, 1, 2];
                    const inorder = [-2, -1, 0, 1, 2];

                    const root = solution.buildTree(preorder, inorder);

                    expect(root).not.toBeNull();
                    expect(preorderTraversal(root)).toEqual(preorder);
                    expect(inorderTraversal(root)).toEqual(inorder);
                });
            });

            // Stress Tests
            describe('Stress Tests', () => {
                test('Single node with different values', () => {
                    for (const val of [0, 1, -1, 100, -100, 999]) {
                        const preorder = [val];
                        const inorder = [val];

                        const root = solution.buildTree(preorder, inorder);

                        expect(root!.val).toBe(val);
                        expect(root!.left).toBeNull();
                        expect(root!.right).toBeNull();
                    }
                });

                test('Two-node tree (parent and left child)', () => {
                    const preorder = [2, 1];
                    const inorder = [1, 2];

                    const root = solution.buildTree(preorder, inorder);

                    expect(root!.val).toBe(2);
                    expect(root!.left!.val).toBe(1);
                    expect(root!.right).toBeNull();
                });

                test('Two-node tree (parent and right child)', () => {
                    const preorder = [1, 2];
                    const inorder = [1, 2];

                    const root = solution.buildTree(preorder, inorder);

                    expect(root!.val).toBe(1);
                    expect(root!.right!.val).toBe(2);
                    expect(root!.left).toBeNull();
                });
            });
        });
    });
});
