using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.FirstAttempts
{
    public class ThreeSumSolution
    {
        // this was my brute force attempt.  It appears to deliver the expected result, but the time complexity is unacceptable.
        // time complexity: O(n^3)
        // space complexity: O(n^3)

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var returnable = new HashSet<(int, int, int)>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    for (int k = 0; k < nums.Length; k++)
                    {
                        if (i == j) continue;
                        if (i == k) continue;
                        if (j == k) continue;

                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            var sortable = new List<int> { nums[i], nums[j], nums[k] };
                            sortable.Sort();
                            (int, int, int) addable = (sortable[0], sortable[1], sortable[2]);
                            returnable.Add(addable);
                        }
                    }
                }
            }

            return Convert(returnable);
        }

        private List<IList<int>> Convert(HashSet<(int, int, int)> returnable)
        {
            var actualReturnable = new List<IList<int>>();
            foreach ((int a, int b, int c) item in returnable)
            {
                var listItem = new List<int>
                {
                    item.a,
                    item.b,
                    item.c
                };

                actualReturnable.Add(listItem);
            }

            return actualReturnable;
        }
    }
}
