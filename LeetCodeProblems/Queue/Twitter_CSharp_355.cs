using LeetCodeProblems.HashingOrArrays;
using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Queue
{
    public class Twitter_CSharp_355 : ITwitter_355
    {
        private class TwitterUser
        {
            
            public int UserId { get; private set; }
            public int LatestTick { get; set; } = int.MinValue;

            public Dictionary<int, TwitterUser> Followers { get; } = new();
            public Dictionary<int, TwitterUser> SubscribesTo { get; } = new();

            public PriorityQueue<int, int> PublishedTweets { get; } = new();
            public PriorityQueue<int, int> Feed { get; set; } = new();
            public TwitterUser(int id) => UserId = id;
            
            public void RebuildFeed()
            {
                Feed.Clear();
                Feed.EnqueueRange(PublishedTweets.UnorderedItems);
                foreach (var publisher in SubscribesTo)
                {
                    Feed.EnqueueRange(publisher.Value.PublishedTweets.UnorderedItems);
                }
                TrimFeed();
            }

            public void TrimFeed()
            {
                while (Feed.Count > 10) Feed.Dequeue();
            }

        }
        private class UserManager 
        {
            
            public TwitterUser GetUserById(int userId)
            {
                if (!_users.ContainsKey(userId)) _users.Add(userId, new TwitterUser(userId));
                return _users[userId];
            }

            private Dictionary<int, TwitterUser> _users = new();
        }

        private int _lastTick = int.MinValue;
        
        public Twitter_CSharp_355() { }
        private UserManager _userManager = new();
        
        public void PostTweet(int userId, int tweetId)
        {
            var author = _userManager.GetUserById(userId);
            _lastTick += 1;

            author.LatestTick = _lastTick;
            author.PublishedTweets.Enqueue(tweetId, _lastTick);
            author.Feed.Enqueue(tweetId, _lastTick);


            author.TrimFeed();
            foreach(KeyValuePair<int, TwitterUser> follower in author.Followers)
            {
                follower.Value.Feed.Enqueue(tweetId, _lastTick);
                follower.Value.TrimFeed();
            }
        }

        public void Follow(int followerId, int followeeId)
        {
            if (followerId == followeeId) return;

            var follower = _userManager.GetUserById(followerId);
            var followee = _userManager.GetUserById(followeeId);

            if (follower.SubscribesTo.ContainsKey(followee.UserId)) return;

            follower.SubscribesTo.Add(followee.UserId, followee);
            followee.Followers.Add(follower.UserId, follower);

            follower.Feed.EnqueueRange(followee.PublishedTweets.UnorderedItems);
            follower.TrimFeed();
        }
        
        public void Unfollow(int followerId, int followeeId)
        {
            var followee = _userManager.GetUserById(followeeId);
            var follower = _userManager.GetUserById(followerId);

            followee.Followers.Remove(follower.UserId);
            follower.SubscribesTo.Remove(followee.UserId);

            if (FeedContainsTweetsFrom(follower, followee))
                follower.RebuildFeed();
        }


        private bool FeedContainsTweetsFrom(TwitterUser subscriber, TwitterUser publisher)
        {
            if (publisher.PublishedTweets.Count == 0 || subscriber.Feed.Count == 0)
                return false;

            subscriber.Feed.TryPeek(out _, out int oldestTickInfeed);

            return publisher.LatestTick >= oldestTickInfeed;


        }

        public IList<int> GetNewsFeed(int userId)
        {
            var returnable = new List<int>();
            var user = _userManager.GetUserById(userId);
            var copy = new PriorityQueue<int, int>(user.Feed.UnorderedItems);

            while (copy.Count > 0)
            {
                returnable.Add(copy.Dequeue());
            }
            returnable.Reverse();
            return returnable;
        }
    }
}
