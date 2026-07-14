using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.CSharp.HashingOrArrays
{
    public class FindTheTownJudge_CSharp_997 : IFindTheTownJudge_997
    {
        public class Person
        {
            public int _trustCount = 0;
            public int _trustedByCount = 0;
        }        

        public int FindJudge(int n, int[][] trust)
        {
            if (n == 1 && trust.Length == 0) return 1;

            var _people = new Dictionary<int, Person>();
            PopulateTrusts(trust, _people);
            int? candidate = null;
            foreach (KeyValuePair<int, Person> person in _people)
            {
                if (person.Value._trustedByCount == n-1 && person.Value._trustCount == 0) 
                { 
                    if (candidate != null) return -1; 
                    candidate = person.Key; 
                }
            }

            if (candidate == null) return -1;
            return candidate.Value;
        }

        private void PopulateTrusts(int[][] source, Dictionary<int, Person> _people)
        {
            foreach (var pair in source)
            {
                if (!_people.TryGetValue(pair[0], out Person truster)) 
                {
                    truster = new Person();
                    _people.Add(pair[0], truster);
                }
                
                if (!_people.TryGetValue(pair[1], out Person trusted))
                {
                    trusted = new Person();
                    _people.Add(pair[1], trusted);
                }

                trusted._trustedByCount++;
                truster._trustCount++;
            }
        }
    }
}
