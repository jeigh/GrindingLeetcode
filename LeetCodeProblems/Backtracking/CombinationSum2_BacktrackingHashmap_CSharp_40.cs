using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class CombinationSum2_BacktrackingHashmap_CSharp_40 : ICombinationSumII_40
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var response = new List<IList<int>>();
            var counts = new Dictionary<int, int>();
            var uniqueCandidates = new List<int>();

            BuildFrequencyMap(candidates, counts, uniqueCandidates);
            recurse(target, new List<int>(), 0, counts, uniqueCandidates, response);

            return response;
        }

        private static void BuildFrequencyMap(int[] candidates, Dictionary<int, int> counts, List<int> a)
        {
            foreach (int num in candidates)
            {
                if (counts.ContainsKey(num)) counts[num]++;
                else
                {
                    counts[num] = 1;
                    a.Add(num);
                }
            }
        }

        private void recurse(int target, List<int> currentList, int i, Dictionary<int, int> counts, List<int> uniqueCandidates, List<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(currentList.ToList());
                return;
            }

            if (target < 0 || i >= uniqueCandidates.Count) return;

            if (counts[uniqueCandidates[i]] > 0)
            {
                currentList.Add(uniqueCandidates[i]);
                counts[uniqueCandidates[i]]--;
                recurse(target - uniqueCandidates[i], currentList, i, counts, uniqueCandidates, result);
                counts[uniqueCandidates[i]]++;
                currentList.RemoveAt(currentList.Count - 1);
            }

            recurse(target, currentList, i + 1, counts, uniqueCandidates, result);
        }

    }
}
