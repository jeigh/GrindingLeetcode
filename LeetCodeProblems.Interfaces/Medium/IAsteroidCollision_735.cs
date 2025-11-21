namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// We are given an array asteroids of integers representing asteroids in a row. The indices of the asteroid in the array represent their relative position in space.
    /// 
    /// For each asteroid, the absolute value represents its size, and the sign represents its direction(positive meaning right, negative meaning left). Each asteroid moves at the same speed.
    /// 
    /// Find out the state of the asteroids after all collisions.If two asteroids meet, the smaller one will explode.If both are the same size, both will explode.Two asteroids moving in the same direction will never meet.
    /// </summary>
    public interface IAsteroidCollision_735
    {
        int[] AsteroidCollision(int[] asteroids);
    }
}