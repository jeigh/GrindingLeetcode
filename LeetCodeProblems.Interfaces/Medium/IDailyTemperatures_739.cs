namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// Given an array of integers temperatures represents the daily temperatures, 
    /// return an array answer such that answer[i] is the number of days you have to wait 
    /// after the ith day to get a warmer temperature. 
    /// If there is no future day for which this is possible, keep answer[i] == 0 instead.
    /// </summary>
    public interface IDailyTemperatures_739
    {
        int[] DailyTemperatures(int[] temperatures);
    }

}