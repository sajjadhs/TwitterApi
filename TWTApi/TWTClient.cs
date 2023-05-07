using LowLayTwitterClient;
using OAuth;

namespace TWTApi
{
    public class TWTClient
    {
        private string consumerKey;
        private string consumerSecret;
        private string accessToken;
        private string accessTokenSecret;
        private const string baseUrl = "https://api.twitter.com";

        public TWTClient(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
            this.accessToken = accessToken;
            this.accessTokenSecret = accessTokenSecret;
        }

        private HttpClient GetClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            return httpClient;
        }

        private void SetHeaders(HttpClient httpClient, string url)
        {
            OAuthRequest client = OAuthRequest.ForProtectedResource("GET", consumerKey,
                consumerSecret,
                accessToken,
                accessTokenSecret);
            client.RequestUrl = url;
            var header = client.GetAuthorizationHeader().Replace("OAuth ", string.Empty);
            httpClient.DefaultRequestHeaders.Add("Authorization", "OAuth " + header);
        }

        /// <summary>
        /// Gets user info
        /// </summary>
        /// <param name="userName">User Handler without @.</param>
        public async Task<Get2UsersByUsernameUsernameResponse> GetUserId(string userName)
        {
            openapiClient x = new openapiClient(GetClient());
            return await x.FindUserByUsernameAsync(userName, null, null, null, SetHeaders);
        }

        /// <summary>
        /// Gets user timeline
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageToken"></param>
        /// <returns></returns>
        public async Task<Get2UsersIdTweetsResponse> GetUserTimeLine(string userId, string? pageToken = null)
        {
            openapiClient x = new openapiClient(GetClient());
            return await x.UsersIdTweetsAsync(userId, SetHeaders, null, null, 100, pageToken, null, null, null, null, null, null, null, null, null);
        }

        /// <summary>
        /// List of users reTweeted a tweet
        /// </summary>
        /// <param name="tweetId"></param>
        /// <param name="pageToken"></param>
        /// <returns></returns>
        public async Task<Get2TweetsIdRetweetedByResponse> GetUsersReTweetedTweet(string tweetId, string? pageToken = null)
        {
            openapiClient x = new openapiClient(GetClient());
            return await x.TweetsIdRetweetingUsersAsync(tweetId, SetHeaders, 100, pageToken, null, null, null);
        }

        /// <summary>
        /// Gets qouted tweets of a tweet
        /// </summary>
        /// <param name="tweetId"></param>
        /// <param name="pageToken"></param>
        /// <returns></returns>
        public async Task<Get2TweetsIdQuoteTweetsResponse> GetUsersQuotedATweet(string tweetId, string? pageToken = null)
        {
            openapiClient x = new openapiClient(GetClient());
            return await x.FindTweetsThatQuoteATweetAsync(tweetId, SetHeaders, 100, pageToken, null, null, null, null, null, null, null);
        }

        /// <summary>
        /// Gets likes of a tweet
        /// </summary>
        /// <param name="tweetId"></param>
        /// <param name="pageToken"></param>
        /// <returns></returns>
        public async Task<Get2TweetsIdLikingUsersResponse> GetLikesOfTweet(string tweetId, string? pageToken = null)
        {
            openapiClient x = new openapiClient(GetClient());
            return await x.GetLikesOfTweet(tweetId, SetHeaders, 100, pageToken, CancellationToken.None);
        }

        public async Task<Get2TweetsSearchRecentResponse> GetCommentsOfTweet(string tweetId, string? pageToken = null)
        {
            openapiClient x = new openapiClient(GetClient());
            return await x.GetCommentsOfTweet(string.Format("conversation_id:{0}", tweetId), SetHeaders, 100, pageToken, CancellationToken.None);
        }
    }
}