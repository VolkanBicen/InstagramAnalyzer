using InstagramAnalyzer.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace InstagramAnalyzer.Web.Helpers
{
    public class InstagramGetDataHelper
    {
        public UnfollowListModel UnfollowData(LoginResultModel model)
        {
            var unfollowList = new UnfollowListModel();
            // TODO:Volkan - DB de cookie var mı kontrol et
            if (false)
            {

            }
            else
            {
                var allFollowers = GetAllFollowers(model);
                if (allFollowers.IsSuccess)
                {
                    unfollowList = GetUnfollowList(allFollowers);
                    return unfollowList;
                }

                unfollowList.IsSuccess = false;
                return unfollowList;
            }
        }
        public FollowersDataResult GetAllFollowers(LoginResultModel model)
        {
            try
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
                        //TODO:Volkan -  DB'ye kaydet
                        var cookieHeaderValue = new CookieHeaderValue(cookie.Name, cookie.Value);
                        client.DefaultRequestHeaders.Add("Cookie", cookieHeaderValue.ToString());
                    }

                }
                var result = client.GetAsync(url).Result;
                FollowersDataResult followersData = JsonConvert.DeserializeObject<FollowersDataResult>(result.Content.ReadAsStringAsync().Result);
                followersData.IsSuccess = true;
                return followersData;
            }
            catch (Exception)
            {
                var followersData = new FollowersDataResult();
                followersData.IsSuccess = false;
                return followersData;
                // TODO: Volkan - Log ekle
                throw;
            }


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
