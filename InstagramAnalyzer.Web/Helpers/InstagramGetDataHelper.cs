using InstagramAnalyzer.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using OpenQA.Selenium.DevTools.V112.Page;
using System.Security.Policy;
using static InstagramAnalyzer.Web.Models.FollowersDataResult;

namespace InstagramAnalyzer.Web.Helpers
{
    public class InstagramGetDataHelper
    {
        public FollowersDataResult GetAllFollowers(LoginResultModel model)
        {
            string userId = "";
            foreach (var item in model.Cookie)
            {
                if (item.Name.Contains("ds_user_id"))
                {
                    userId = item.Value;
                }
            }
            var url = new Uri("https://www.instagram.com/graphql/query/?query_hash=3dec7e2c57367ef3da3d987d89f9dbc8&variables={\"id\":\"" + userId + "\",\"include_reel\":\"true\",\"fetch_mutual\":\"false\",\"first\":\"24\"}");
            var client = new HttpClient();
            foreach (var cookie in model.Cookie)
            {
                if (cookie.Name != "rur")
                {
                    // DB'ye kaydet
                    var cookieHeaderValue = new CookieHeaderValue(cookie.Name, cookie.Value);
                    client.DefaultRequestHeaders.Add("Cookie", cookieHeaderValue.ToString());
                }

            }
            var result = client.GetAsync(url).Result;
            FollowersDataResult followersData = JsonConvert.DeserializeObject<FollowersDataResult>(result.Content.ReadAsStringAsync().Result);
            return followersData;

        }

        public UnfollowListModel GetUnfollowList(FollowersDataResult followersData)
        {
            var unfollowList = new UnfollowListModel();
            var unfollowers = new Unfollowers();

            foreach (var item in followersData.data.user.edge_follow.edges)
            {
                if (item.node.follows_viewer == false)
                {
                    unfollowers.FullName = item.node.full_name;
                    unfollowers.UserId = item.node.id;
                    unfollowList.UnfollowersList.Add(unfollowers);
                }

            }
            return unfollowList;
        }
    }
}
