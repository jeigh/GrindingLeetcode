import { TreeNode } from '../../src/Shared/TreeNode';
import { DeleteNodeInABST_DirectSuccessorPromotion_450 } from '../../src/Medium/DeleteNodeInABST_DirectSuccessorPromotion_450';
import { DeleteNodeInABST_LeftTreeDemotion_450 } from '../../src/Medium/DeleteNodeInABST_LeftTreeDemotion_450';
import { DeleteNodeInABST_RightTreePromotion_450 } from '../../src/Medium/DeleteNodeInABST_RightTreePromotion_450';
import { IDeleteNodeInABST_450 } from '../../src/Interfaces/Medium/IDeleteNodeInABST_450';

describe('DeleteNodeInABST_450', () => {
    const implementations: [IDeleteNodeInABST_450, string][] = [
        [new DeleteNodeInABST_DirectSuccessorPromotion_450(), 'Direct Successor Promotion'],
        [new DeleteNodeInABST_LeftTreeDemotion_450(), 'Left Tree Demotion'],
        [new DeleteNodeInABST_RightTreePromotion_450(), 'Right Tree Promotion']
    ];

    /**
     * Helper function to create a BST from level-order array representation
     */
    function createTree(values: (number | null)[]): TreeNode | null {
        if (values.length === 0 || values[0] === null) return null;

        const root = new TreeNode(values[0]);
        const queue: TreeNode[] = [root];
        let index = 1;

        while (queue.length > 0 && index < values.length) {
            const current = queue.shift()!;

            // Left child
            if (index < values.length && values[index] !== null) {
                current.left = new TreeNode(values[index]!);
                queue.push(current.left);
            }
            index++;

            // Right child
            if (index < values.length && values[index] !== null) {
                current.right = new TreeNode(values[index]!);
                queue.push(current.right);
            }
            index++;
        }

        return root;
    }

    /**
     * Performs in-order traversal to get sorted values from BST
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
     * Verifies that a tree is a valid BST
     */
    function isValidBST(root: TreeNode | null, min: number = Number.MIN_SAFE_INTEGER, max: number = Number.MAX_SAFE_INTEGER): boolean {
        if (root === null) return true;
        if (root.val <= min || root.val >= max) return false;
        return isValidBST(root.left, min, root.val) && isValidBST(root.right, root.val, max);
    }

    /**
     * Checks if a value exists in the BST
     */
    function contains(root: TreeNode | null, val: number): boolean {
        if (root === null) return false;
        if (root.val === val) return true;
        if (val < root.val) return contains(root.left, val);
        return contains(root.right, val);
    }

    /**
     * Counts total nodes in the tree
     */
    function countNodes(root: TreeNode | null): number {
        if (root === null) return 0;
        return 1 + countNodes(root.left) + countNodes(root.right);
    }

    implementations.forEach(([solution, name]) => {
        describe(name, () => {
            // LeetCode Examples
            describe('LeetCode Examples', () => {
                test('Example 1 - Deletes node with two children', () => {
                    const root = createTree([5, 3, 6, 2, 4, null, 7]);
                    const key = 3;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(countNodes(result)).toBe(5);

                    const inorder = inorderTraversal(result);
                    expect(inorder).toEqual([2, 4, 5, 6, 7]);
                });

                test('Example 2 - Key not found', () => {
                    const root = createTree([5, 3, 6, 2, 4, null, 7]);
                    const originalInorder = inorderTraversal(root);
                    const key = 0;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(countNodes(result)).toBe(6);
                    expect(inorderTraversal(result)).toEqual(originalInorder);
                });

                test('Example 3 - Empty tree', () => {
                    const root = null;
                    const key = 0;

                    const result = solution.deleteNode(root, key);

                    expect(result).toBeNull();
                });
            });

            // Delete Leaf Nodes
            describe('Delete Leaf Nodes', () => {
                test('Delete left leaf node', () => {
                    const root = createTree([4, 2, 6, 1, 3, 5, 7]);
                    const key = 1;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([2, 3, 4, 5, 6, 7]);
                });

                test('Delete right leaf node', () => {
                    const root = createTree([4, 2, 6, 1, 3, 5, 7]);
                    const key = 7;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([1, 2, 3, 4, 5, 6]);
                });
            });

            // Delete Node with One Child
            describe('Delete Node with One Child', () => {
                test('Node with only left child', () => {
                    const root = createTree([5, 3, 6, 2, null, null, 7]);
                    const key = 3;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([2, 5, 6, 7]);
                });

                test('Node with only right child', () => {
                    const root = createTree([5, 3, 6, null, 4, null, 7]);
                    const key = 3;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([4, 5, 6, 7]);
                });
            });

            // Delete Node with Two Children
            describe('Delete Node with Two Children', () => {
                test('Node with two children', () => {
                    const root = createTree([5, 3, 6, 2, 4, null, 7]);
                    const key = 3;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([2, 4, 5, 6, 7]);
                });

                test('Node with two children - complex tree', () => {
                    const root = createTree([10, 5, 15, 3, 7, 12, 20, 1, 4, 6, 9]);
                    const key = 5;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([1, 3, 4, 6, 7, 9, 10, 12, 15, 20]);
                });
            });

            // Delete Root Node
            describe('Delete Root Node', () => {
                test('Delete root - single node returns null', () => {
                    const root = new TreeNode(5);
                    const key = 5;

                    const result = solution.deleteNode(root, key);

                    expect(result).toBeNull();
                });

                test('Delete root with only left child', () => {
                    const root = new TreeNode(5);
                    root.left = new TreeNode(3);
                    const key = 5;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(result?.val).toBe(3);
                });

                test('Delete root with only right child', () => {
                    const root = new TreeNode(5);
                    root.right = new TreeNode(7);
                    const key = 5;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(result?.val).toBe(7);
                });

                test('Delete root with two children', () => {
                    const root = createTree([5, 3, 7, 2, 4, 6, 8]);
                    const key = 5;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([2, 3, 4, 6, 7, 8]);
                });
            });

            // Skewed Trees
            describe('Skewed Trees', () => {
                test('Left skewed tree', () => {
                    const root = createTree([5, 4, null, 3, null, 2, null, 1]);
                    const key = 3;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([1, 2, 4, 5]);
                });

                test('Right skewed tree', () => {
                    const root = createTree([1, null, 2, null, 3, null, 4, null, 5]);
                    const key = 3;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([1, 2, 4, 5]);
                });

                test('Left skewed tree - delete root', () => {
                    const root = createTree([5, 4, null, 3, null, 2, null, 1]);
                    const key = 5;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([1, 2, 3, 4]);
                });

                test('Right skewed tree - delete root', () => {
                    const root = createTree([1, null, 2, null, 3, null, 4, null, 5]);
                    const key = 1;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([2, 3, 4, 5]);
                });
            });

            // Balanced Trees
            describe('Balanced Trees', () => {
                test('Balanced tree - delete middle node', () => {
                    const root = createTree([8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15]);
                    const key = 6;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15]);
                });
            });

            // Edge Cases - Values
            describe('Edge Cases - Values', () => {
                test('Tree with negative values', () => {
                    const root = createTree([0, -2, 2, -3, -1, 1, 3]);
                    const key = -2;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([-3, -1, 0, 1, 2, 3]);
                });

                test('Tree with all negative values', () => {
                    const root = createTree([-4, -6, -2, -7, -5, -3, -1]);
                    const key = -4;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([-7, -6, -5, -3, -2, -1]);
                });

                test('Delete zero from tree', () => {
                    const root = createTree([5, -5, 10, -10, 0, 8, 15]);
                    const key = 0;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([-10, -5, 5, 8, 10, 15]);
                });
            });

            // Sequential Deletions
            describe('Sequential Deletions', () => {
                test('Multiple sequential deletions maintain BST', () => {
                    let root = createTree([8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15]);
                    const keysToDelete = [6, 10, 14];

                    for (const key of keysToDelete) {
                        root = solution.deleteNode(root, key);
                    }

                    expect(isValidBST(root)).toBe(true);
                    for (const key of keysToDelete) {
                        expect(contains(root, key)).toBe(false);
                    }
                    expect(inorderTraversal(root)).toEqual([1, 2, 3, 4, 5, 7, 8, 9, 11, 12, 13, 15]);
                });

                test('Delete all nodes one by one returns null', () => {
                    let root = createTree([4, 2, 6, 1, 3, 5, 7]);
                    const keysToDelete = [1, 2, 3, 4, 5, 6, 7];

                    for (const key of keysToDelete) {
                        root = solution.deleteNode(root, key);
                    }

                    expect(root).toBeNull();
                });
            });

            // Complex Scenarios
            describe('Complex Scenarios', () => {
                test('Delete node with complex subtree', () => {
                    const root = createTree([20, 10, 30, 5, 15, 25, 35, 3, 7, 12, 18]);
                    const key = 10;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([3, 5, 7, 12, 15, 18, 20, 25, 30, 35]);
                });

                test('Sparse tree deletion', () => {
                    const root = createTree([8, 4, 12, null, 6, 10, null, 5]);
                    const key = 4;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([5, 6, 8, 10, 12]);
                });
            });

            // Boundary Conditions
            describe('Boundary Conditions', () => {
                test('Delete minimum value', () => {
                    const root = createTree([8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15]);
                    const key = 1;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]);
                });

                test('Delete maximum value', () => {
                    const root = createTree([8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15]);
                    const key = 15;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]);
                });

                test('Two node tree', () => {
                    const root = new TreeNode(10);
                    root.left = new TreeNode(5);
                    const key = 5;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(result?.val).toBe(10);
                    expect(countNodes(result)).toBe(1);
                });
            });

            // Property-Based Tests
            describe('Property-Based Tests', () => {
                test('Preserves other nodes after deletion', () => {
                    const root = createTree([4, 2, 6, 1, 3, 5, 7]);
                    const originalInorder = inorderTraversal(root);
                    const key = 2;

                    const result = solution.deleteNode(root, key);

                    const newInorder = inorderTraversal(result);
                    for (const val of originalInorder) {
                        if (val !== key) {
                            expect(newInorder).toContain(val);
                        }
                    }
                });

                test('Node count decreases by exactly one', () => {
                    const root = createTree([4, 2, 6, 1, 3, 5, 7]);
                    const originalCount = countNodes(root);
                    const key = 6;

                    const result = solution.deleteNode(root, key);

                    const newCount = countNodes(result);
                    expect(newCount).toBe(originalCount - 1);
                });

                test('Maintains BST property after multiple deletions', () => {
                    let root = createTree([50, 30, 70, 20, 40, 60, 80, 10, 25, 35, 45, 55, 65, 75, 85]);
                    const keysToDelete = [20, 40, 60, 80];

                    for (const key of keysToDelete) {
                        root = solution.deleteNode(root, key);
                        expect(isValidBST(root)).toBe(true);
                    }
                });

                test('Inorder remains sorted after deletion', () => {
                    const root = createTree([50, 30, 70, 20, 40, 60, 80]);
                    const key = 30;

                    const result = solution.deleteNode(root, key);

                    const inorder = inorderTraversal(result);
                    const sorted = [...inorder].sort((a, b) => a - b);
                    expect(inorder).toEqual(sorted);
                });
            });

            // Successor/Predecessor Edge Cases
            describe('Successor/Predecessor Edge Cases', () => {
                test('Node with successor as direct right child', () => {
                    const root = createTree([5, 3, 7, 2, 4, 6, 8]);
                    const key = 5;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([2, 3, 4, 6, 7, 8]);
                });

                test('Node with successor deep in right subtree', () => {
                    const root = createTree([10, 5, 20, 3, 7, 15, 25, null, null, null, null, 12, 18]);
                    const key = 10;

                    const result = solution.deleteNode(root, key);

                    expect(isValidBST(result)).toBe(true);
                    expect(contains(result, key)).toBe(false);
                    expect(inorderTraversal(result)).toEqual([3, 5, 7, 12, 15, 18, 20, 25]);
                });
            });
        });
    });
});
