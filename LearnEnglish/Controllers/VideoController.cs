using LearnEnglish.Models;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace LearnEnglish.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Add()
        {
            return View();
        }
        public string GetYoutubeInfo(string url)
        {
            var api = $"http://youtube.com/get_video_info?video_id={GetArgs(url, "v", '?')}";
            YoutubeVideo video = new YoutubeVideo();

            return new JavaScriptSerializer().Serialize(GetArgs(api,); ;
        }
        private YoutubeVideo GetArgs(string args, string key, char query)
        {
            var iqs = args.IndexOf(query);
            YoutubeVideo video = new YoutubeVideo();
            if (iqs == -1)
                return null;
            video.Title = HttpUtility.ParseQueryString(iqs < args.Length - 1
                    ? args.Substring(iqs + 1) : string.Empty)["title"];
            video.VideoID = HttpUtility.ParseQueryString(iqs < args.Length - 1
                    ? args.Substring(iqs + 1) : string.Empty)["v"];
            return video;
        }
    }
}