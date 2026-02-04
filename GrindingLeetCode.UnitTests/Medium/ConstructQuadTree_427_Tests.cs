using LeetCodeProblems.CSharp.Tree;
using LeetCodeProblems.Interfaces;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.VisualBasic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class ConstructQuadTree_427_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new ConstructQuadTree_Recursion_CSharp_427(), "C# Recursive" };
            yield return new object[] { new ConstructQuadTree_Recursion_Optimized_CSharp_427(), "C# Recursive Optimized" };
            yield return new object[] { new ConstructQuadTree_Iterative_CSharp_427(), "C# Iterative" };

            yield return new object[] { new ConstructQuadTree_Recursion_VB_427(), "VB Recursive" };
            yield return new object[] { new ConstructQuadTree_RecursionOptimized_VB_427(), "VB Optimized recursion" };
            yield return new object[] { new ConstructQuadTree_Iterative_VB_427(), "VB Iterative" };
        }

        #region Helper Methods

        /// <summary>
        /// Creates a 2D grid from a jagged array
        /// </summary>
        private int[][] CreateGrid(int[][] grid)
        {
            return grid;
        }

        /// <summary>
        /// Validates that a Quad Node is a leaf
        /// </summary>
        private void AssertIsLeaf(QuadNode node, bool expectedValue)
        {
            Assert.IsTrue(node.isLeaf, "Node should be a leaf");
            Assert.AreEqual(expectedValue, node.val, "Leaf value mismatch");
            Assert.IsNull(node.topLeft);
            Assert.IsNull(node.topRight);
            Assert.IsNull(node.bottomLeft);
            Assert.IsNull(node.bottomRight);
        }

        /// <summary>
        /// Validates that a Quad Node is an internal node
        /// </summary>
        private void AssertIsInternalNode(QuadNode node)
        {
            Assert.IsFalse(node.isLeaf, "Node should not be a leaf");
            Assert.IsNotNull(node.topLeft, "Top-left child should exist");
            Assert.IsNotNull(node.topRight, "Top-right child should exist");
            Assert.IsNotNull(node.bottomLeft, "Bottom-left child should exist");
            Assert.IsNotNull(node.bottomRight, "Bottom-right child should exist");
        }

        /// <summary>
        /// Converts Quad Tree to grid representation for validation
        /// </summary>
        private int[][] QuadTreeToGrid(QuadNode root, int size)
        {
            int[][] grid = new int[size][];
            for (int i = 0; i < size; i++)
            {
                grid[i] = new int[size];
            }

            FillGridFromQuadTree(root, grid, 0, 0, size);
            return grid;
        }

        private void FillGridFromQuadTree(QuadNode node, int[][] grid, int row, int col, int size)
        {
            if (node == null) return;

            if (node.isLeaf)
            {
                // Fill the region with the leaf value
                int value = node.val ? 1 : 0;
                for (int i = row; i < row + size; i++)
                {
                    for (int j = col; j < col + size; j++)
                    {
                        grid[i][j] = value;
                    }
                }
            }
            else
            {
                int halfSize = size / 2;
                FillGridFromQuadTree(node.topLeft, grid, row, col, halfSize);
                FillGridFromQuadTree(node.topRight, grid, row, col + halfSize, halfSize);
                FillGridFromQuadTree(node.bottomLeft, grid, row + halfSize, col, halfSize);
                FillGridFromQuadTree(node.bottomRight, grid, row + halfSize, col + halfSize, halfSize);
            }
        }

        /// <summary>
        /// Asserts two grids are equal
        /// </summary>
        private void AssertGridsEqual(int[][] expected, int[][] actual, string solutionName)
        {
            Assert.AreEqual(expected.Length, actual.Length, $"Grid height mismatch for {solutionName}");
            
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i], 
                    $"Row {i} mismatch for {solutionName}");
            }
        }

        /// <summary>
        /// Counts total nodes in Quad Tree
        /// </summary>
        private int CountNodes(QuadNode node)
        {
            if (node == null) return 0;
            if (node.isLeaf) return 1;
            
            return 1 + CountNodes(node.topLeft) + CountNodes(node.topRight) + 
                   CountNodes(node.bottomLeft) + CountNodes(node.bottomRight);
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_Example1_4x4_Mixed_ReturnsCorrectQuadTree(IConstructQuadTree_427 solution, string solutionName)
        {
            // Input: grid = [[0,1],[1,0]]
            // Output: [[0,1],[1,0],[1,1],[1,1],[1,0]]
            // Explanation:
            // Top-left and bottom-right are 0, top-right and bottom-left are 1
            // So we split into 4 leaf nodes

            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 0, 1 },
                new int[] { 1, 0 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsInternalNode(result);
            
            // Verify children are leaves
            AssertIsLeaf(result.topLeft, false);      // 0
            AssertIsLeaf(result.topRight, true);      // 1
            AssertIsLeaf(result.bottomLeft, true);    // 1
            AssertIsLeaf(result.bottomRight, false);  // 0
            
            // Verify grid reconstruction
            var reconstructed = QuadTreeToGrid(result, 2);
            AssertGridsEqual(grid, reconstructed, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_Example2_8x8_Complex_ReturnsCorrectQuadTree(IConstructQuadTree_427 solution, string solutionName)
        {
            // Input: grid = [[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,1],[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0]]
            // 8x8 grid with mixed values

            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 1, 1, 1, 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 0, 0, 0, 0 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            Assert.IsNotNull(result, $"Result should not be null for {solutionName}");
            
            // Verify grid reconstruction matches original
            var reconstructed = QuadTreeToGrid(result, 8);
            AssertGridsEqual(grid, reconstructed, solutionName);
        }

        #endregion

        #region Uniform Grids (Should Result in Single Leaf)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_1x1_AllOnes_ReturnsSingleLeafTrue(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange
            var grid = CreateGrid(new int[][] { new int[] { 1 } });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsLeaf(result, true);
            Assert.AreEqual(1, CountNodes(result), $"Should have 1 node for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_1x1_AllZeros_ReturnsSingleLeafFalse(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange
            var grid = CreateGrid(new int[][] { new int[] { 0 } });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsLeaf(result, false);
            Assert.AreEqual(1, CountNodes(result), $"Should have 1 node for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_2x2_AllOnes_ReturnsSingleLeafTrue(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 1, 1 },
                new int[] { 1, 1 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsLeaf(result, true);
            Assert.AreEqual(1, CountNodes(result), $"Should have 1 node for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_2x2_AllZeros_ReturnsSingleLeafFalse(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 0, 0 },
                new int[] { 0, 0 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsLeaf(result, false);
            Assert.AreEqual(1, CountNodes(result), $"Should have 1 node for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_4x4_AllOnes_ReturnsSingleLeafTrue(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsLeaf(result, true);
            Assert.AreEqual(1, CountNodes(result), $"Should have 1 node for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_4x4_AllZeros_ReturnsSingleLeafFalse(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsLeaf(result, false);
            Assert.AreEqual(1, CountNodes(result), $"Should have 1 node for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_8x8_AllOnes_ReturnsSingleLeafTrue(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange - 8x8 grid of all 1s
            var grid = CreateGrid(Enumerable.Range(0, 8)
                .Select(_ => Enumerable.Repeat(1, 8).ToArray())
                .ToArray());

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsLeaf(result, true);
            Assert.AreEqual(1, CountNodes(result), $"Should have 1 node for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_8x8_AllZeros_ReturnsSingleLeafFalse(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange - 8x8 grid of all 0s
            var grid = CreateGrid(Enumerable.Range(0, 8)
                .Select(_ => Enumerable.Repeat(0, 8).ToArray())
                .ToArray());

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsLeaf(result, false);
            Assert.AreEqual(1, CountNodes(result), $"Should have 1 node for {solutionName}");
        }

        #endregion

        #region Maximum Subdivision (All Different)

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_2x2_AllDifferent_Returns5Nodes(IConstructQuadTree_427 solution, string solutionName)
        {
            // Checkerboard pattern - maximum subdivision
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 1, 0 },
                new int[] { 0, 1 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsInternalNode(result);
            Assert.AreEqual(5, CountNodes(result), $"Should have 5 nodes (1 root + 4 leaves) for {solutionName}");
            
            var reconstructed = QuadTreeToGrid(result, 2);
            AssertGridsEqual(grid, reconstructed, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_4x4_Checkerboard_ReturnsCorrectTree(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 1, 0, 1, 0 },
                new int[] { 0, 1, 0, 1 },
                new int[] { 1, 0, 1, 0 },
                new int[] { 0, 1, 0, 1 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            Assert.IsNotNull(result, $"Result should not be null for {solutionName}");
            
            var reconstructed = QuadTreeToGrid(result, 4);
            AssertGridsEqual(grid, reconstructed, solutionName);
        }

        #endregion

        #region Partial Subdivision

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_4x4_TopLeftUniform_ReturnsPartialTree(IConstructQuadTree_427 solution, string solutionName)
        {
            // Top-left quadrant is uniform, others vary
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 1, 1, 0, 1 },
                new int[] { 1, 1, 1, 0 },
                new int[] { 0, 1, 1, 1 },
                new int[] { 1, 0, 1, 1 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsInternalNode(result);
            // Top-left should be a leaf (all 1s)
            AssertIsLeaf(result.topLeft, true);
            
            var reconstructed = QuadTreeToGrid(result, 4);
            AssertGridsEqual(grid, reconstructed, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_4x4_BottomRightUniform_ReturnsPartialTree(IConstructQuadTree_427 solution, string solutionName)
        {
            // Bottom-right quadrant is uniform
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 0, 1, 0, 1 },
                new int[] { 1, 0, 1, 0 },
                new int[] { 0, 1, 0, 0 },
                new int[] { 1, 0, 0, 0 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsInternalNode(result);
            // Bottom-right should be a leaf (all 0s)
            AssertIsLeaf(result.bottomRight, false);
            
            var reconstructed = QuadTreeToGrid(result, 4);
            AssertGridsEqual(grid, reconstructed, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_4x4_TwoQuadrantsUniform_ReturnsCorrectTree(IConstructQuadTree_427 solution, string solutionName)
        {
            // Top-left and bottom-right are uniform
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 1, 1, 0, 1 },
                new int[] { 1, 1, 1, 0 },
                new int[] { 0, 1, 0, 0 },
                new int[] { 1, 0, 0, 0 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsInternalNode(result);
            AssertIsLeaf(result.topLeft, true);        // All 1s
            AssertIsLeaf(result.bottomRight, false);   // All 0s
            
            var reconstructed = QuadTreeToGrid(result, 4);
            AssertGridsEqual(grid, reconstructed, solutionName);
        }

        #endregion

        #region Larger Grids

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_16x16_AllOnes_ReturnsSingleLeaf(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange - 16x16 grid of all 1s
            var grid = CreateGrid(Enumerable.Range(0, 16)
                .Select(_ => Enumerable.Repeat(1, 16).ToArray())
                .ToArray());

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsLeaf(result, true);
            Assert.AreEqual(1, CountNodes(result), $"Should have 1 node for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_32x32_AllZeros_ReturnsSingleLeaf(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange - 32x32 grid of all 0s
            var grid = CreateGrid(Enumerable.Range(0, 32)
                .Select(_ => Enumerable.Repeat(0, 32).ToArray())
                .ToArray());

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsLeaf(result, false);
            Assert.AreEqual(1, CountNodes(result), $"Should have 1 node for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_64x64_AllOnes_ReturnsSingleLeaf(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange - 64x64 grid of all 1s (max constraint)
            var grid = CreateGrid(Enumerable.Range(0, 64)
                .Select(_ => Enumerable.Repeat(1, 64).ToArray())
                .ToArray());

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsLeaf(result, true);
            Assert.AreEqual(1, CountNodes(result), $"Should have 1 node for {solutionName}");
        }

        #endregion

        #region Specific Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_4x4_TopHalfOnes_BottomHalfZeros(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsInternalNode(result);
            // Top half should be uniform 1s
            AssertIsLeaf(result.topLeft, true);
            AssertIsLeaf(result.topRight, true);
            // Bottom half should be uniform 0s
            AssertIsLeaf(result.bottomLeft, false);
            AssertIsLeaf(result.bottomRight, false);
            
            var reconstructed = QuadTreeToGrid(result, 4);
            AssertGridsEqual(grid, reconstructed, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_4x4_LeftHalfOnes_RightHalfZeros(IConstructQuadTree_427 solution, string solutionName)
        {
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 1, 1, 0, 0 },
                new int[] { 1, 1, 0, 0 },
                new int[] { 1, 1, 0, 0 },
                new int[] { 1, 1, 0, 0 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsInternalNode(result);
            // Left half should be uniform 1s
            AssertIsLeaf(result.topLeft, true);
            AssertIsLeaf(result.bottomLeft, true);
            // Right half should be uniform 0s
            AssertIsLeaf(result.topRight, false);
            AssertIsLeaf(result.bottomRight, false);
            
            var reconstructed = QuadTreeToGrid(result, 4);
            AssertGridsEqual(grid, reconstructed, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_8x8_DiagonalPattern_ReturnsCorrectTree(IConstructQuadTree_427 solution, string solutionName)
        {
            // Diagonal pattern: top-left to bottom-right
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 1, 1, 1, 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 1, 1, 1, 1 },
                new int[] { 0, 0, 0, 0, 1, 1, 1, 1 },
                new int[] { 0, 0, 0, 0, 1, 1, 1, 1 },
                new int[] { 0, 0, 0, 0, 1, 1, 1, 1 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            Assert.IsNotNull(result, $"Result should not be null for {solutionName}");
            
            var reconstructed = QuadTreeToGrid(result, 8);
            AssertGridsEqual(grid, reconstructed, solutionName);
        }

        #endregion

        #region Deep Subdivision

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_8x8_SingleCellDifference_CreatesDeepTree(IConstructQuadTree_427 solution, string solutionName)
        {
            // Grid with all 1s except one 0 in corner - requires deep subdivision
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 0, 1, 1, 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            Assert.IsNotNull(result, $"Result should not be null for {solutionName}");
            AssertIsInternalNode(result);
            
            var reconstructed = QuadTreeToGrid(result, 8);
            AssertGridsEqual(grid, reconstructed, solutionName);
        }

        #endregion

        #region Property Tests

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_ReconstructedGridMatchesOriginal_AllCases(IConstructQuadTree_427 solution, string solutionName)
        {
            // Property: Reconstructed grid should always match original
            var testGrids = new List<int[][]>
            {
                CreateGrid(new int[][] { new int[] { 1 } }),
                CreateGrid(new int[][] 
                {
                    new int[] { 1, 0 },
                    new int[] { 0, 1 }
                }),
                CreateGrid(new int[][] 
                {
                    new int[] { 1, 1, 0, 0 },
                    new int[] { 1, 1, 0, 0 },
                    new int[] { 0, 0, 1, 1 },
                    new int[] { 0, 0, 1, 1 }
                })
            };

            foreach (var grid in testGrids)
            {
                var result = solution.Construct(grid);
                var reconstructed = QuadTreeToGrid(result, grid.Length);
                AssertGridsEqual(grid, reconstructed, solutionName);
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_UniformGrid_AlwaysProducesSingleLeaf(IConstructQuadTree_427 solution, string solutionName)
        {
            // Property: Any uniform grid should produce exactly 1 leaf node
            var sizes = new[] { 1, 2, 4, 8, 16 };
            var values = new[] { 0, 1 };

            foreach (var size in sizes)
            {
                foreach (var value in values)
                {
                    var grid = CreateGrid(Enumerable.Range(0, size)
                        .Select(_ => Enumerable.Repeat(value, size).ToArray())
                        .ToArray());

                    var result = solution.Construct(grid);

                    Assert.IsTrue(result.isLeaf, 
                        $"Uniform {size}x{size} grid with value {value} should be a leaf for {solutionName}");
                    Assert.AreEqual(value == 1, result.val, 
                        $"Leaf value should be {value == 1} for {solutionName}");
                    Assert.AreEqual(1, CountNodes(result), 
                        $"Should have exactly 1 node for {solutionName}");
                }
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_LeafNodesShouldHaveNullChildren(IConstructQuadTree_427 solution, string solutionName)
        {
            // Property: All leaf nodes must have null children
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 1, 0 },
                new int[] { 0, 1 }
            });

            var result = solution.Construct(grid);

            ValidateLeafNodes(result, solutionName);
        }

        private void ValidateLeafNodes(QuadNode node, string solutionName)
        {
            if (node == null) return;

            if (node.isLeaf)
            {
                Assert.IsNull(node.topLeft, $"Leaf node should have null topLeft for {solutionName}");
                Assert.IsNull(node.topRight, $"Leaf node should have null topRight for {solutionName}");
                Assert.IsNull(node.bottomLeft, $"Leaf node should have null bottomLeft for {solutionName}");
                Assert.IsNull(node.bottomRight, $"Leaf node should have null bottomRight for {solutionName}");
            }
            else
            {
                Assert.IsNotNull(node.topLeft, $"Internal node should have topLeft child for {solutionName}");
                Assert.IsNotNull(node.topRight, $"Internal node should have topRight child for {solutionName}");
                Assert.IsNotNull(node.bottomLeft, $"Internal node should have bottomLeft child for {solutionName}");
                Assert.IsNotNull(node.bottomRight, $"Internal node should have bottomRight child for {solutionName}");

                ValidateLeafNodes(node.topLeft, solutionName);
                ValidateLeafNodes(node.topRight, solutionName);
                ValidateLeafNodes(node.bottomLeft, solutionName);
                ValidateLeafNodes(node.bottomRight, solutionName);
            }
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_AlternatingRows_ReturnsCorrectTree(IConstructQuadTree_427 solution, string solutionName)
        {
            // Alternating rows of 0s and 1s
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 1 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 1 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            var reconstructed = QuadTreeToGrid(result, 4);
            AssertGridsEqual(grid, reconstructed, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_AlternatingColumns_ReturnsCorrectTree(IConstructQuadTree_427 solution, string solutionName)
        {
            // Alternating columns of 0s and 1s
            // Arrange
            var grid = CreateGrid(new int[][] 
            {
                new int[] { 0, 1, 0, 1 },
                new int[] { 0, 1, 0, 1 },
                new int[] { 0, 1, 0, 1 },
                new int[] { 0, 1, 0, 1 }
            });

            // Act
            var result = solution.Construct(grid);

            // Assert
            var reconstructed = QuadTreeToGrid(result, 4);
            AssertGridsEqual(grid, reconstructed, solutionName);
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_MaxSize64x64_Uniform_HandlesCorrectly(IConstructQuadTree_427 solution, string solutionName)
        {
            // Maximum constraint: 64x64 grid
            // Arrange
            var grid = CreateGrid(Enumerable.Range(0, 64)
                .Select(_ => Enumerable.Repeat(1, 64).ToArray())
                .ToArray());

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsLeaf(result, true);
            Assert.AreEqual(1, CountNodes(result), $"64x64 uniform grid should be 1 leaf for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Construct_MinSize1x1_HandlesCorrectly(IConstructQuadTree_427 solution, string solutionName)
        {
            // Minimum constraint: 1x1 grid
            // Arrange
            var grid = CreateGrid(new int[][] { new int[] { 0 } });

            // Act
            var result = solution.Construct(grid);

            // Assert
            AssertIsLeaf(result, false);
        }

        #endregion
    }
}
