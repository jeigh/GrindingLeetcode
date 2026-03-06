using LeetCodeProblems.CSharp.Queue;
using LeetCodeProblems.Interfaces.Medium;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class Twitter_355_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
             yield return new object[] { new Twitter_CSharp_355() };
        }

        #region LeetCode Example

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Twitter_LeetCodeExample_WorksCorrectly(ITwitter_355 twitter)
        {
            // ["Twitter","postTweet","getNewsFeed","follow","postTweet","getNewsFeed","unfollow","getNewsFeed"]
            // [[],[1,5],[1],[1,2],[2,6],[1],[1,2],[1]]

            twitter.PostTweet(1, 5);

            var feed1 = twitter.GetNewsFeed(1);
            Assert.AreEqual(1, feed1.Count);
            Assert.AreEqual(5, feed1[0]);

            twitter.Follow(1, 2);
            twitter.PostTweet(2, 6);

            var feed2 = twitter.GetNewsFeed(1);
            Assert.AreEqual(2, feed2.Count);
            Assert.AreEqual(6, feed2[0]);   // most recent first
            Assert.AreEqual(5, feed2[1]);

            twitter.Unfollow(1, 2);

            var feed3 = twitter.GetNewsFeed(1);
            Assert.AreEqual(1, feed3.Count);
            Assert.AreEqual(5, feed3[0]);   // user 2's tweet no longer visible
        }

        #endregion

        #region PostTweet & GetNewsFeed

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetNewsFeed_NewUser_ReturnsEmpty(ITwitter_355 twitter)
        {
            var feed = twitter.GetNewsFeed(1);

            Assert.AreEqual(0, feed.Count);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetNewsFeed_SingleTweet_ReturnsThatTweet(ITwitter_355 twitter)
        {
            twitter.PostTweet(1, 10);

            var feed = twitter.GetNewsFeed(1);

            Assert.AreEqual(1, feed.Count);
            Assert.AreEqual(10, feed[0]);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetNewsFeed_MultipleTweets_MostRecentFirst(ITwitter_355 twitter)
        {
            twitter.PostTweet(1, 100);
            twitter.PostTweet(1, 200);
            twitter.PostTweet(1, 300);

            var feed = twitter.GetNewsFeed(1);

            Assert.AreEqual(300, feed[0]);
            Assert.AreEqual(200, feed[1]);
            Assert.AreEqual(100, feed[2]);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetNewsFeed_MoreThanTenTweets_CappedAtTen(ITwitter_355 twitter)
        {
            for (int i = 1; i <= 11; i++)
                twitter.PostTweet(1, i);

            var feed = twitter.GetNewsFeed(1);

            Assert.AreEqual(10, feed.Count);
            Assert.AreEqual(11, feed[0]);   // most recent first
            Assert.AreEqual(2, feed[9]);    // tweet id 1 is dropped
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void GetNewsFeed_UnfollowedUserTweets_NotVisible(ITwitter_355 twitter)
        {
            twitter.PostTweet(2, 99);

            var feed = twitter.GetNewsFeed(1);

            Assert.AreEqual(0, feed.Count);
        }

        #endregion

        #region Follow

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Follow_FolloweeTweetsVisibleInFollowerFeed(ITwitter_355 twitter)
        {
            twitter.PostTweet(2, 42);
            twitter.Follow(1, 2);

            var feed = twitter.GetNewsFeed(1);

            Assert.IsTrue(feed.Contains(42));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Follow_MergedFeedOrderedByRecency(ITwitter_355 twitter)
        {
            twitter.PostTweet(2, 1);
            twitter.PostTweet(3, 2);
            twitter.PostTweet(1, 3);
            twitter.Follow(1, 2);
            twitter.Follow(1, 3);

            var feed = twitter.GetNewsFeed(1);

            Assert.AreEqual(3, feed.Count);
            Assert.AreEqual(3, feed[0]);
            Assert.AreEqual(2, feed[1]);
            Assert.AreEqual(1, feed[2]);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Follow_Self_OwnTweetsStillAppear(ITwitter_355 twitter)
        {
            twitter.PostTweet(1, 7);
            twitter.Follow(1, 1);

            var feed = twitter.GetNewsFeed(1);

            Assert.IsTrue(feed.Contains(7));
        }

        #endregion

        #region Unfollow

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Unfollow_RemovesFolloweeTweetsFromFeed(ITwitter_355 twitter)
        {
            twitter.PostTweet(2, 55);
            twitter.Follow(1, 2);
            twitter.Unfollow(1, 2);

            var feed = twitter.GetNewsFeed(1);

            Assert.IsFalse(feed.Contains(55));
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Unfollow_UserNeverFollowed_NoException(ITwitter_355 twitter)
        {
            // should not throw
            twitter.Unfollow(1, 2);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void Unfollow_Self_OwnTweetsStillAppear(ITwitter_355 twitter)
        {
            twitter.PostTweet(1, 77);
            twitter.Unfollow(1, 1);

            var feed = twitter.GetNewsFeed(1);

            Assert.IsTrue(feed.Contains(77));
        }

        #endregion
    }
}
