
string consumerKey = "ccc";
string consumerSecret = "aaa";
string accessToken = "vvvv";
string accessTokenSecret = "ddd";


TWTApi.TWTClient client = new TWTApi.TWTClient(consumerKey, consumerSecret, accessToken, accessTokenSecret);
var user = await client.GetUserId("binance");

var likes = await client.GetLikesOfTweet("1654781770695319555", "7140dibdnow9c7btw482mju0vk3d9jzbk0sg1cq6yy6ur");

var userTimeLine = await client.GetUserTimeLine(user.Data.Id);
foreach (var s in userTimeLine.Data)
{
    Console.WriteLine(s.Text);
}


var rewteets = await client.GetUsersReTweetedTweet("1654781770695319555");
var qouted = await client.GetUsersQuotedATweet("1654781770695319555");
Console.WriteLine(user.Data.Id);