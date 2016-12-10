using System;
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
        public void GetYoutubeInfo(string url)
        {
            //var api = $"http://youtube.com/get_video_info?video_id={GetArgs(url, "v", '?')}";
            //YoutubeVideo video = new YoutubeVideo();

            //return new JavaScriptSerializer().Serialize(GetArgs(api,); ;
        }
        private void GetArgs(string args, string key, char query)
        {
            //var iqs = args.IndexOf(query);
            //YoutubeVideo video = new YoutubeVideo();
            //if (iqs == -1)
            //    return null;
            //video.Title = HttpUtility.ParseQueryString(iqs < args.Length - 1
            //        ? args.Substring(iqs + 1) : string.Empty)["title"];
            //video.VideoID = HttpUtility.ParseQueryString(iqs < args.Length - 1
            //        ? args.Substring(iqs + 1) : string.Empty)["v"];
            //return video;
        }

        [HttpPost]
        public ActionResult AddNewVideo()/*VideoMaterial video*/
        {
            try
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    VideoMaterial video = new VideoMaterial()
                    {
                        Image =
                            "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQBK3FmyjIENz16NWEl1iJcIWj8I5n8hs-rl5JPixzw-XppNfKx",
                        Name = "Text Video"
                    };
                    context.VideoMaterials.Add(video);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}