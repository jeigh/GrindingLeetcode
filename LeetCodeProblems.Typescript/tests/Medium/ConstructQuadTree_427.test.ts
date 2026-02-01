import { QuadNode } from '../../src/Shared/QuadNode';
import { ConstructQuadtree_Recursion_427 } from '../../src/Medium/ConstructQuadTree_Recursion_427';
import { ConstructQuadTree_Optimized_427 } from '../../src/Medium/ConstructQuadTree_Optimized_427';
import { IConstructQuadTree_Recursion_427 } from '../../src/Interfaces/Medium/IConstructQuadTree_Recursion_427';

describe('ConstructQuadTree_427', () => {
    const implementations: [IConstructQuadTree_Recursion_427, string][] = [
        [new ConstructQuadtree_Recursion_427(), 'Recursion'],
        [new ConstructQuadTree_Optimized_427(), 'Optimized']
    ];

    /**
     * Helper function to compare two QuadNode trees for structural and value equality
     */
    function areQuadTreesEqual(node1: QuadNode | null, node2: QuadNode | null): boolean {
        if (node1 === null && node2 === null) return true;
        if (node1 === null || node2 === null) return false;

        return (
            node1.val === node2.val &&
            node1.isLeaf === node2.isLeaf &&
            areQuadTreesEqual(node1.topLeft, node2.topLeft) &&
            areQuadTreesEqual(node1.topRight, node2.topRight) &&
            areQuadTreesEqual(node1.bottomLeft, node2.bottomLeft) &&
            areQuadTreesEqual(node1.bottomRight, node2.bottomRight)
        );
    }

    /**
     * Helper function to print QuadNode tree structure for debugging
     */
    function printQuadTree(node: QuadNode | null, indent: string = ''): string {
        if (node === null) return '';
        let result = `${indent}val: ${node.val}, isLeaf: ${node.isLeaf}\n`;
        if (node.topLeft) result += `${indent}topLeft:\n${printQuadTree(node.topLeft, indent + '  ')}`;
        if (node.topRight) result += `${indent}topRight:\n${printQuadTree(node.topRight, indent + '  ')}`;
        if (node.bottomLeft) result += `${indent}bottomLeft:\n${printQuadTree(node.bottomLeft, indent + '  ')}`;
        if (node.bottomRight) result += `${indent}bottomRight:\n${printQuadTree(node.bottomRight, indent + '  ')}`;
        return result;
    }

    implementations.forEach(([implementation, name]) => {
        describe(`${name} Implementation`, () => {
            describe('Single cell grids', () => {
                test('1x1 grid with value 1', () => {
                    const grid = [[1]];
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.val).toBe(true);
                    expect(result!.isLeaf).toBe(true);
                    expect(result!.topLeft).toBeNull();
                    expect(result!.topRight).toBeNull();
                    expect(result!.bottomLeft).toBeNull();
                    expect(result!.bottomRight).toBeNull();
                });

                test('1x1 grid with value 0', () => {
                    const grid = [[0]];
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.val).toBe(false);
                    expect(result!.isLeaf).toBe(true);
                });
            });

            describe('Uniform grids (all same value)', () => {
                test('2x2 grid with all 1s', () => {
                    const grid = [
                        [1, 1],
                        [1, 1]
                    ];
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.val).toBe(true);
                    expect(result!.isLeaf).toBe(true);
                });

                test('2x2 grid with all 0s', () => {
                    const grid = [
                        [0, 0],
                        [0, 0]
                    ];
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.val).toBe(false);
                    expect(result!.isLeaf).toBe(true);
                });

                test('4x4 grid with all 1s', () => {
                    const grid = [
                        [1, 1, 1, 1],
                        [1, 1, 1, 1],
                        [1, 1, 1, 1],
                        [1, 1, 1, 1]
                    ];
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.val).toBe(true);
                    expect(result!.isLeaf).toBe(true);
                });

                test('8x8 grid with all 0s', () => {
                    const grid = Array(8).fill(null).map(() => Array(8).fill(0));
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.val).toBe(false);
                    expect(result!.isLeaf).toBe(true);
                });
            });

            describe('Non-uniform grids (mixed values)', () => {
                test('2x2 grid with mixed values', () => {
                    const grid = [
                        [1, 0],
                        [1, 0]
                    ];
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.isLeaf).toBe(false);
                    expect(result!.topLeft).not.toBeNull();
                    expect(result!.topRight).not.toBeNull();
                    expect(result!.bottomLeft).not.toBeNull();
                    expect(result!.bottomRight).not.toBeNull();
                    
                    // Check that all children are leaves
                    expect(result!.topLeft!.isLeaf).toBe(true);
                    expect(result!.topRight!.isLeaf).toBe(true);
                    expect(result!.bottomLeft!.isLeaf).toBe(true);
                    expect(result!.bottomRight!.isLeaf).toBe(true);
                });

                test('4x4 grid with alternating checkerboard pattern', () => {
                    const grid = [
                        [1, 0, 1, 0],
                        [0, 1, 0, 1],
                        [1, 0, 1, 0],
                        [0, 1, 0, 1]
                    ];
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.isLeaf).toBe(false);
                    // All quadrants should be non-leaves due to mixed values
                    expect(result!.topLeft!.isLeaf).toBe(false);
                    expect(result!.topRight!.isLeaf).toBe(false);
                    expect(result!.bottomLeft!.isLeaf).toBe(false);
                    expect(result!.bottomRight!.isLeaf).toBe(false);
                });

                test('4x4 grid with three uniform quadrants and one non-uniform', () => {
                    const grid = [
                        [1, 1, 1, 1],
                        [1, 1, 1, 1],
                        [1, 1, 0, 1],
                        [1, 1, 1, 0]
                    ];
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.isLeaf).toBe(false);
                    
                    // Top-left and top-right should be leaves (uniform)
                    expect(result!.topLeft!.isLeaf).toBe(true);
                    expect(result!.topRight!.isLeaf).toBe(true);
                    
                    // Bottom-left should be a leaf (uniform)
                    expect(result!.bottomLeft!.isLeaf).toBe(true);
                    // Bottom-right should be non-leaf (mixed)
                    expect(result!.bottomRight!.isLeaf).toBe(false);
                });

                test('8x8 grid with mixed values', () => {
                    const grid = [
                        [1, 1, 0, 0, 1, 1, 0, 0],
                        [1, 1, 0, 0, 1, 1, 0, 0],
                        [0, 0, 1, 1, 0, 0, 1, 1],
                        [0, 0, 1, 1, 0, 0, 1, 1],
                        [1, 1, 0, 0, 1, 1, 0, 0],
                        [1, 1, 0, 0, 1, 1, 0, 0],
                        [0, 0, 1, 1, 0, 0, 1, 1],
                        [0, 0, 1, 1, 0, 0, 1, 1]
                    ];
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.isLeaf).toBe(false);
                    // All quadrants should be non-leaves due to pattern
                    expect(result!.topLeft!.isLeaf).toBe(false);
                    expect(result!.topRight!.isLeaf).toBe(false);
                    expect(result!.bottomLeft!.isLeaf).toBe(false);
                    expect(result!.bottomRight!.isLeaf).toBe(false);
                });
            });

            describe('Edge cases', () => {
                test('16x16 grid with all 1s', () => {
                    const grid = Array(16).fill(null).map(() => Array(16).fill(1));
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.isLeaf).toBe(true);
                    expect(result!.val).toBe(true);
                });

                test('2x2 grid with three 1s and one 0', () => {
                    const grid = [
                        [1, 1],
                        [1, 0]
                    ];
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.isLeaf).toBe(false);
                    expect(result!.topLeft).not.toBeNull();
                    expect(result!.topRight).not.toBeNull();
                    expect(result!.bottomLeft).not.toBeNull();
                    expect(result!.bottomRight).not.toBeNull();
                });

                test('4x4 grid mostly uniform with one outlier in corner', () => {
                    const grid = [
                        [0, 0, 0, 0],
                        [0, 0, 0, 0],
                        [0, 0, 0, 0],
                        [0, 0, 0, 1]
                    ];
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.isLeaf).toBe(false);
                });
            });

            describe('Value correctness', () => {
                test('Leaf nodes represent correct boolean value for 1', () => {
                    const grid = [[1]];
                    const result = implementation.construct(grid);

                    expect(result!.val).toBe(true);
                });

                test('Leaf nodes represent correct boolean value for 0', () => {
                    const grid = [[0]];
                    const result = implementation.construct(grid);

                    expect(result!.val).toBe(false);
                });

                test('Non-leaf node val is irrelevant (can be any value)', () => {
                    const grid = [
                        [1, 0],
                        [1, 0]
                    ];
                    const result = implementation.construct(grid);

                    // Non-leaf nodes have arbitrary val, just verify structure
                    expect(result!.isLeaf).toBe(false);
                    expect(result!.topLeft).not.toBeNull();
                });
            });

            describe('Structure validation', () => {
                test('All leaf nodes have null children', () => {
                    const grid = [
                        [1, 1],
                        [1, 1]
                    ];
                    const result = implementation.construct(grid);

                    function validateLeafStructure(node: QuadNode | null): boolean {
                        if (node === null) return true;
                        
                        if (node.isLeaf) {
                            return (
                                node.topLeft === null &&
                                node.topRight === null &&
                                node.bottomLeft === null &&
                                node.bottomRight === null
                            );
                        }
                        
                        return (
                            validateLeafStructure(node.topLeft) &&
                            validateLeafStructure(node.topRight) &&
                            validateLeafStructure(node.bottomLeft) &&
                            validateLeafStructure(node.bottomRight)
                        );
                    }

                    expect(validateLeafStructure(result)).toBe(true);
                });

                test('Non-leaf nodes have all four children non-null', () => {
                    const grid = [
                        [1, 0],
                        [1, 0]
                    ];
                    const result = implementation.construct(grid);

                    function validateNonLeafStructure(node: QuadNode | null): boolean {
                        if (node === null) return true;
                        
                        if (!node.isLeaf) {
                            // Non-leaf must have all four children
                            if (
                                node.topLeft === null ||
                                node.topRight === null ||
                                node.bottomLeft === null ||
                                node.bottomRight === null
                            ) {
                                return false;
                            }
                        }
                        
                        return (
                            validateNonLeafStructure(node.topLeft) &&
                            validateNonLeafStructure(node.topRight) &&
                            validateNonLeafStructure(node.bottomLeft) &&
                            validateNonLeafStructure(node.bottomRight)
                        );
                    }

                    expect(validateNonLeafStructure(result)).toBe(true);
                });
            });

            describe('Recursion depth', () => {
                test('Correctly builds recursive tree for 8x8 grid', () => {
                    const grid = [
                        [1, 1, 1, 1, 0, 0, 0, 0],
                        [1, 1, 1, 1, 0, 0, 0, 0],
                        [1, 1, 1, 1, 0, 0, 0, 0],
                        [1, 1, 1, 1, 0, 0, 0, 0],
                        [0, 0, 0, 0, 1, 1, 1, 1],
                        [0, 0, 0, 0, 1, 1, 1, 1],
                        [0, 0, 0, 0, 1, 1, 1, 1],
                        [0, 0, 0, 0, 1, 1, 1, 1]
                    ];
                    const result = implementation.construct(grid);

                    expect(result).not.toBeNull();
                    expect(result!.isLeaf).toBe(false);
                    
                    // Top-left quadrant should be a leaf (all 1s)
                    expect(result!.topLeft!.isLeaf).toBe(true);
                    expect(result!.topLeft!.val).toBe(true);
                    
                    // Bottom-right quadrant should be a leaf (all 1s)
                    expect(result!.bottomRight!.isLeaf).toBe(true);
                    expect(result!.bottomRight!.val).toBe(true);
                });
            });
        });
    });
});
