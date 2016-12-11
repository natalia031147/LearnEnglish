using System;
using System.Data.Entity.Migrations;
using System.Globalization;
using LearnEnglish.Models;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;

namespace LearnEnglish.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Videos()
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
        public ActionResult UpdateVideo(VideoMv videomv) 
        {
            try
            {
              

            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
            return Json("Success", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddNewVideo(VideoMv videomv)
        {
            try
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    Video video = new Video()
                    {
                        Title = videomv.Title,
                        Url = videomv.Url,
                        Thumbnail = videomv.Thumbnail,
                        Level = (int)Common.Enums.Level.PreIntermediate,
                        Language = videomv.Language
                    };
                    context.Videos.Add(video);
                    context.SaveChanges();
                    // save  Video Phrases
                    var index = 1;
                    foreach (var part in videomv.parts)
                    {
                        VideoPhrase videoPhrase = new VideoPhrase()
                        {
                            OrderNumber = index,
                            StartTime = float.Parse(part.startTime, CultureInfo.InvariantCulture.NumberFormat),
                            EndTime = float.Parse(part.endTime, CultureInfo.InvariantCulture.NumberFormat),
                            Video = video,
                            Phrase = part.source,
                            TranslateLanguage = videomv.Language,
                            PhraseTranslated = part.native,
                        };
                        index++;
                        context.VideoPhrases.Add(videoPhrase);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}