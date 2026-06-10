using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class PermutationsII_Backtracking_CSharp_47 : IPermutationsII_47
    {
        private List<int> _currentList;
        private List<IList<int>> _result;

        public IList<IList<int>> Permute(int[] nums)
        {
            _currentList = new List<int>();
            _result = new List<IList<int>>();
            var _pick = new bool[nums.Length];

            Array.Sort(nums);

            recurse(nums, ref _pick);

            return _result;
        }

        public void recurse(int[] nums, ref bool[] pick)
        {
            if (_currentList.Count == nums.Length)
            {
                _result.Add(_currentList.ToList());
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (pick[i]) continue;
                if (i > 0 && nums[i] == nums[i - 1] && !pick[i - 1]) continue;

                pick[i] = true;
                _currentList.Add(nums[i]);
                recurse(nums, ref pick);
                _currentList.RemoveAt(_currentList.Count - 1);
                pick[i] = false;
            }
        }
    }
}
