
namespace LeetCodeProblems.Interfaces.Medium
{
    public interface ITwitter_355
    {
        void Follow(int followerId, int followeeId);
        IList<int> GetNewsFeed(int userId);
        void PostTweet(int userId, int tweetId);
        void Unfollow(int followerId, int followeeId);
    }
}