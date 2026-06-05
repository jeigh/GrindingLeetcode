using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class Permutations_BacktrackingOptimized_CSharp_46 : IPermutations_46
    {
        private List<IList<int>> _result;
        private List<int> _currentList;
        private bool[] _pick;

        public IList<IList<int>> Permute(int[] nums)
        {
            _currentList = new List<int>();
            _result = new List<IList<int>>();
            _pick = new bool[nums.Length];

            recurse(nums);

            return _result;
        }

        public void recurse(int[] nums)
        {
            if (_currentList.Count == nums.Length)
            {
                _result.Add(_currentList.ToList());
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!_pick[i])
                {
                    _currentList.Add(nums[i]);
                    _pick[i] = true;
                    recurse(nums);
                    _currentList.RemoveAt(_currentList.Count - 1);
                    _pick[i] = false;
                }
            }
        }
    }
}
