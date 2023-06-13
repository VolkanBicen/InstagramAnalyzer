namespace InstagramAnalyzer.Web.Models
{

    public class FollowersDataResult
    {
        public Data data { get; set; }
        public Extensions extensions { get; set; }
        public string status { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Data
    {
        public User user { get; set; }
    }

    public class Edge
    {
        public Node node { get; set; }
    }

    public class EdgeFollow
    {
        public int count { get; set; }
        public PageInfo page_info { get; set; }
        public List<Edge> edges { get; set; }
    }

    public class Extensions
    {
        public bool is_final { get; set; }
    }

    public class Node
    {
        public string id { get; set; }
        public string username { get; set; }
        public string full_name { get; set; }
        public string profile_pic_url { get; set; }
        public bool is_private { get; set; }
        public bool is_verified { get; set; }
        public bool followed_by_viewer { get; set; }
        public bool follows_viewer { get; set; }
        public bool requested_by_viewer { get; set; }
        public Reel reel { get; set; }
    }

    public class Owner
    {
        public string __typename { get; set; }
        public string id { get; set; }
        public string profile_pic_url { get; set; }
        public string username { get; set; }
    }

    public class PageInfo
    {
        public bool has_next_page { get; set; }
        public string end_cursor { get; set; }
    }

    public class Reel
    {
        public string id { get; set; }
        public int expiring_at { get; set; }
        public bool has_pride_media { get; set; }
        public int latest_reel_media { get; set; }
        public int? seen { get; set; }
        public Owner owner { get; set; }
    }

    public class User
    {
        public EdgeFollow edge_follow { get; set; }
    }



}
