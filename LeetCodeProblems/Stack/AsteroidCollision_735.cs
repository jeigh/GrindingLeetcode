using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Stack
{
    public class AsteroidCollision_735 : IAsteroidCollision_735
    {
        public int[] AsteroidCollision(int[] asteroids)
        {
            var _stack = new Stack<int>();
            
            foreach (int asteroid in asteroids)
            {
                if (asteroid > 0)
                {
                    _stack.Push(asteroid);
                    continue;
                }
                bool destroyed = false;

                while (_stack.Count > 0 && _stack.Peek() > 0)
                {
                    int top = _stack.Peek();

                    if (Math.Abs(top) < Math.Abs(asteroid))
                    {
                        _stack.Pop();
                        continue;
                    }
                    else if (Math.Abs(top) == Math.Abs(asteroid))
                    {
                        _stack.Pop();
                        destroyed = true;
                        break;
                    }
                    else
                    {
                        destroyed = true;
                        break;
                    }
                }

                if (!destroyed)
                    _stack.Push(asteroid);
            }

            return _stack.Reverse().ToArray();
        }
    }
}
