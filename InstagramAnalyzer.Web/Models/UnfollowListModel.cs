namespace InstagramAnalyzer.Web.Models
{

    public class Unfollowers
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
    }


    public class UnfollowListModel
    {
        public List<Unfollowers> UnfollowersList { get; set; }

        public UnfollowListModel()
        {
            UnfollowersList = new List<Unfollowers>();
        }
    }
   
}
