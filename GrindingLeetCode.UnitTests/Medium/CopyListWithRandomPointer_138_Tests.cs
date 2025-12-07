using LeetCodeProblems.CSharp.LinkedList;
using LeetCodeProblems.Interfaces.Medium;
using LeetCodeProblems.Shared;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class CopyListWithRandomPointer_138_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new CopyListWithRandomPointerCSharp_138(), "C#" };
        }

        #region Helper Methods

        /// <summary>
        /// Creates a list with random pointers based on the specification
        /// </summary>
        /// <param name="values">Array of [val, random_index] pairs. random_index is -1 for null.</param>
        /// <returns>Head of the created list</returns>
        private Node CreateListWithRandomPointers(int[][] values)
        {
            if (values == null || values.Length == 0) return null;

            // First pass: create all nodes
            Node[] nodes = new Node[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                nodes[i] = new Node(values[i][0]);
            }

            // Second pass: link next pointers
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                nodes[i].next = nodes[i + 1];
            }

            // Third pass: link random pointers
            for (int i = 0; i < nodes.Length; i++)
            {
                int randomIndex = values[i][1];
                if (randomIndex >= 0 && randomIndex < nodes.Length)
                {
                    nodes[i].random = nodes[randomIndex];
                }
            }

            return nodes[0];
        }

        /// <summary>
        /// Verifies that the copied list is a deep copy with correct structure
        /// </summary>
        private void AssertDeepCopy(Node original, Node copy, string solutionName)
        {
            if (original == null && copy == null) return;
            Assert.IsNotNull(copy, $"Copy should not be null when original is not null for {solutionName}");

            // Build dictionaries to track node mappings
            var originalNodes = new Dictionary<Node, int>();
            var copyNodes = new List<Node>();
            var current = original;
            int index = 0;

            // Map original nodes to indices
            while (current != null)
            {
                originalNodes[current] = index++;
                current = current.next;
            }

            // Traverse copy and verify
            current = copy;
            Node origCurrent = original;
            index = 0;

            while (current != null)
            {
                copyNodes.Add(current);

                // Verify values match
                Assert.AreEqual(origCurrent.val, current.val, 
                    $"Value mismatch at index {index} for {solutionName}");

                // Verify it's a different object (deep copy)
                Assert.AreNotSame(origCurrent, current, 
                    $"Node at index {index} should be a different object (deep copy) for {solutionName}");

                current = current.next;
                origCurrent = origCurrent.next;
                index++;
            }

            // Verify random pointers
            current = copy;
            origCurrent = original;
            index = 0;

            while (current != null)
            {
                if (origCurrent.random == null)
                {
                    Assert.IsNull(current.random, 
                        $"Random pointer at index {index} should be null for {solutionName}");
                }
                else
                {
                    Assert.IsNotNull(current.random, 
                        $"Random pointer at index {index} should not be null for {solutionName}");

                    // Find which index the original random points to
                    int originalRandomIndex = originalNodes[origCurrent.random];

                    // Verify copy's random points to the corresponding copied node
                    Assert.AreSame(copyNodes[originalRandomIndex], current.random,
                        $"Random pointer at index {index} should point to copied node at index {originalRandomIndex} for {solutionName}");
                }

                current = current.next;
                origCurrent = origCurrent.next;
                index++;
            }
        }

        /// <summary>
        /// Converts a list to string representation for debugging
        /// </summary>
        private string ListToString(Node head)
        {
            if (head == null) return "[]";

            var nodes = new List<Node>();
            var nodeIndices = new Dictionary<Node, int>();
            var current = head;
            int index = 0;

            while (current != null)
            {
                nodes.Add(current);
                nodeIndices[current] = index++;
                current = current.next;
            }

            var result = new System.Text.StringBuilder("[");
            for (int i = 0; i < nodes.Count; i++)
            {
                if (i > 0) result.Append(",");
                result.Append($"[{nodes[i].val},");
                result.Append(nodes[i].random == null ? "null" : nodeIndices[nodes[i].random].ToString());
                result.Append("]");
            }
            result.Append("]");

            return result.ToString();
        }

        #endregion

        #region LeetCode Examples

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_Example1_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[7,null],[13,0],[11,4],[10,2],[1,0]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 7, -1 },   // Node 0: val=7, random=null
                new int[] { 13, 0 },   // Node 1: val=13, random->Node 0
                new int[] { 11, 4 },   // Node 2: val=11, random->Node 4
                new int[] { 10, 2 },   // Node 3: val=10, random->Node 2
                new int[] { 1, 0 }     // Node 4: val=1, random->Node 0
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_Example2_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[1,1],[2,1]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 1 },    // Node 0: val=1, random->Node 1
                new int[] { 2, 1 }     // Node 1: val=2, random->Node 1 (itself)
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_Example3_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[3,null],[3,0],[3,null]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 3, -1 },   // Node 0: val=3, random=null
                new int[] { 3, 0 },    // Node 1: val=3, random->Node 0
                new int[] { 3, -1 }    // Node 2: val=3, random=null
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        #endregion

        #region Null and Empty Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_NullHead_ReturnsNull(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange
            Node head = null;

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            Assert.IsNull(copy, $"Copy of null list should be null for {solutionName}");
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_SingleNodeNoRandom_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[1,null]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, -1 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_SingleNodeRandomToSelf_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[1,0]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 0 }    // Points to itself
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
            Assert.AreSame(copy, copy.random, $"Single node pointing to itself should have random pointing to itself for {solutionName}");
        }

        #endregion

        #region Two Node Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_TwoNodesNoRandoms_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[1,null],[2,null]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, -1 },
                new int[] { 2, -1 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_TwoNodesRandomToEachOther_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[1,1],[2,0]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 1 },    // Node 0 random->Node 1
                new int[] { 2, 0 }     // Node 1 random->Node 0
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_TwoNodesBothRandomToFirst_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[1,0],[2,0]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 0 },    // Node 0 random->Node 0 (itself)
                new int[] { 2, 0 }     // Node 1 random->Node 0
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_TwoNodesBothRandomToSecond_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[1,1],[2,1]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 1 },    // Node 0 random->Node 1
                new int[] { 2, 1 }     // Node 1 random->Node 1 (itself)
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        #endregion

        #region All Random Pointers Null

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_ThreeNodesAllRandomsNull_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[1,null],[2,null],[3,null]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, -1 },
                new int[] { 2, -1 },
                new int[] { 3, -1 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_FiveNodesAllRandomsNull_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[1,null],[2,null],[3,null],[4,null],[5,null]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, -1 },
                new int[] { 2, -1 },
                new int[] { 3, -1 },
                new int[] { 4, -1 },
                new int[] { 5, -1 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        #endregion

        #region All Random Pointers to First Node

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_AllRandomPointToFirst_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[1,0],[2,0],[3,0],[4,0]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 2, 0 },
                new int[] { 3, 0 },
                new int[] { 4, 0 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        #endregion

        #region All Random Pointers to Last Node

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_AllRandomPointToLast_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[1,3],[2,3],[3,3],[4,3]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 3 },
                new int[] { 2, 3 },
                new int[] { 3, 3 },
                new int[] { 4, 3 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        #endregion

        #region Random Pointers Form Chains

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_RandomsFormChain_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: Each random points to next node
            // [[1,1],[2,2],[3,3],[4,null]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 1 },    // 0->1
                new int[] { 2, 2 },    // 1->2
                new int[] { 3, 3 },    // 2->3
                new int[] { 4, -1 }    // 3->null
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_RandomsFormReverseChain_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: Each random points to previous node
            // [[1,null],[2,0],[3,1],[4,2]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, -1 },   // 0->null
                new int[] { 2, 0 },    // 1->0
                new int[] { 3, 1 },    // 2->1
                new int[] { 4, 2 }     // 3->2
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        #endregion

        #region Complex Random Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_AlternatingPattern_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: Odd nodes point forward, even nodes point backward
            // [[1,2],[2,0],[3,4],[4,2],[5,null]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 2 },    // 0->2
                new int[] { 2, 0 },    // 1->0
                new int[] { 3, 4 },    // 2->4
                new int[] { 4, 2 },    // 3->2
                new int[] { 5, -1 }    // 4->null
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_CrossLinkedPattern_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: First half points to second half, second half points to first half
            // [[1,3],[2,4],[3,0],[4,1]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 3 },    // 0->3
                new int[] { 2, 4 },    // 1->4 (will be out of range, but demonstrates pattern)
                new int[] { 3, 0 },    // 2->0
                new int[] { 4, 1 }     // 3->1
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        #endregion

        #region All Nodes Point to Themselves

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_AllNodesPointToThemselves_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[1,0],[2,1],[3,2],[4,3]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 2, 1 },
                new int[] { 3, 2 },
                new int[] { 4, 3 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        #endregion

        #region Different Value Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_NegativeValues_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[-1,1],[-2,0],[-3,null]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { -1, 1 },
                new int[] { -2, 0 },
                new int[] { -3, -1 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_ZeroValues_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[0,1],[0,0],[0,null]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 0, 0 },
                new int[] { 0, -1 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_LargeValues_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[1000,1],[2000,0],[3000,2]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1000, 1 },
                new int[] { 2000, 0 },
                new int[] { 3000, 2 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_DuplicateValues_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: [[5,2],[5,0],[5,1],[5,3]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 5, 2 },
                new int[] { 5, 0 },
                new int[] { 5, 1 },
                new int[] { 5, 3 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        #endregion

        #region Longer Lists

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_TenNodes_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: 10 nodes with various random patterns
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 5 },
                new int[] { 2, 9 },
                new int[] { 3, 0 },
                new int[] { 4, 7 },
                new int[] { 5, 3 },
                new int[] { 6, -1 },
                new int[] { 7, 2 },
                new int[] { 8, 8 },
                new int[] { 9, 1 },
                new int[] { 10, 6 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_LongListSequentialRandom_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: Each node points to the next (or null for last)
            var data = new List<int[]>();
            for (int i = 0; i < 20; i++)
            {
                data.Add(new int[] { i + 1, i < 19 ? i + 1 : -1 });
            }
            Node head = CreateListWithRandomPointers(data.ToArray());

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_LongListReverseRandom_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: Each node points to the previous (or null for first)
            var data = new List<int[]>();
            for (int i = 0; i < 20; i++)
            {
                data.Add(new int[] { i + 1, i > 0 ? i - 1 : -1 });
            }
            Node head = CreateListWithRandomPointers(data.ToArray());

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        #endregion

        #region Mixed Patterns

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_SomeNullSomePointing_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: Mix of null and non-null random pointers
            // [[1,2],[2,null],[3,0],[4,null],[5,3]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2, -1 },
                new int[] { 3, 0 },
                new int[] { 4, -1 },
                new int[] { 5, 3 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_StarPattern_AllPointToMiddle_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: All nodes point to the middle node
            // [[1,2],[2,2],[3,2],[4,2],[5,2]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2, 2 },
                new int[] { 3, 2 },
                new int[] { 4, 2 },
                new int[] { 5, 2 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_CircularRandomPointers_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: Circular pattern - each points to node 2 steps ahead (mod list length)
            // [[1,2],[2,3],[3,4],[4,0],[5,1]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 3, 4 },
                new int[] { 4, 0 },
                new int[] { 5, 1 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void CopyRandomList_PalindromeRandomPattern_CopiesCorrectly(ICopyListWithRandomPointer_138 solution, string solutionName)
        {
            // Arrange: Symmetric random pointers
            // [[1,4],[2,3],[3,2],[4,1],[5,0]]
            Node head = CreateListWithRandomPointers(new int[][]
            {
                new int[] { 1, 4 },
                new int[] { 2, 3 },
                new int[] { 3, 2 },
                new int[] { 4, 1 },
                new int[] { 5, 0 }
            });

            // Act
            Node copy = solution.CopyRandomList(head);

            // Assert
            AssertDeepCopy(head, copy, solutionName);
        }

        #endregion
    }
}
