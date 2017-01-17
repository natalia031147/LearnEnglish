using System;
using System.Globalization;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Text;
using LearnEnglish.Business.Builders;
using LearnEnglish.Business.Logic;
using LearnEnglish.Business.Models;
using LearnEnglish.Data.Entities;
using LearnEnglish.Data.Framework;
using static LearnEnglish.Data.Entities.Enums;
using LearnEnglish.Business.Logic.Interfaces;

namespace LearnEnglish.Controllers
{
    public class VideoViewController : Controller
    {
        //private List<Video> _videos;
        //private List<VideoPhrase> _videosPhrases;
        //private List<UserProgress> _userProgress;
        ApplicationDbContext _context;
        IVideoLogic _videoLogic;
        public VideoViewController()
        {
            _context = new ApplicationDbContext();
            _videoLogic = new VideoLogic(new VideoModelBuilder(), new ApplicationDbContext());
        }


        // GET: Video
        public ActionResult Add()
        {
            return View();
        }

        private Level getLevel(int points)
        {
            Level level;
            if (points <= 500)
            {
                level = Level.Elementary;
            }
            else if (points <= 1000)
            {
                level = Level.PreIntermediate;
            }
            else if (points <= 1700)
            {
                level = Level.Intermediate;
            }
            else if (points <= 2400)
            {
                level = Level.PreIntermediate;
            }
            else
            {
                level = Level.Advanced;
            }
            return level;
        }
        [Authorize]
        public ActionResult Recommendations()
        {
            
            return View();
        }

        public JsonResult GetRecommendations()
        {
            //Elementary - 0- 500 points 
            //PreIntermediate - 501 - 1000
            //Intermediate - 1001 - 1700
            //UpperIntermediate 1701 - 2400
            //Advanced >= 2401

            string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            var points = _context.UsersPoints.Where(v => v.User.Id == UserId)
                .Select(s => new { s.ListeningPoints, s.WritingPoints }).FirstOrDefault();


            Level listeningLevel = getLevel((int)points.ListeningPoints);
            Level writingLevel = getLevel((int)points.WritingPoints);


            var videoForListening = (from a in _context.Videos.Where(l => l.Level >= (int)listeningLevel)
                                     join b in _context.UserProgress
                                        .Where(w => w.User.Id == UserId)
                                        on a equals b.Video into joined
                                     from j in joined.DefaultIfEmpty().Where(v => v.ListeningModulePassed != true || v.ListeningModulePassed == null)
                                     select new
                                     {
                                         a.Id,
                                         a.Language,
                                         a.Level,
                                         a.Thumbnail,
                                         a.Title,
                                         a.Url,
                                         j.ListeningModulePassed,
                                         j.WritingModulePassed
                                     }).OrderBy(o => o.Level).ThenByDescending(o => o.WritingModulePassed).ThenBy(o => o.Id).FirstOrDefault();

            var videoForWriting = (from a in _context.Videos.Where(l => l.Level >= (int)writingLevel)
                                   join b in _context.UserProgress
                                      .Where(w => w.User.Id == UserId)
                                      on a equals b.Video into joined
                                   from j in joined.DefaultIfEmpty().Where(v => v.WritingModulePassed != true || v.WritingModulePassed == null)
                                   select new
                                   {
                                       a.Id,
                                       a.Language,
                                       a.Level,
                                       a.Thumbnail,
                                       a.Title,
                                       a.Url,
                                       j.ListeningModulePassed,
                                       j.WritingModulePassed
                                   }).OrderBy(o => o.Level).ThenByDescending(o => o.ListeningModulePassed).ThenBy(o => o.Id).FirstOrDefault();

            int arithmeticMean = ((int)points.ListeningPoints + (int)points.WritingPoints) / 2;
            Level level = getLevel(arithmeticMean);

            Recommendations recommendations = new Recommendations();
            recommendations.UserLevel = level;

            recommendations.ListeningRecommendation = new Video()
            {
                Id = videoForListening.Id,
                Language = videoForListening.Language,
                Level = videoForListening.Level,
                Thumbnail = videoForListening.Thumbnail,
                Title = videoForListening.Title,
                Url = videoForListening.Url                
            };

            recommendations.WritingRecommendation = new Video()
            {
                Id = videoForWriting.Id,
                Language = videoForWriting.Language,
                Level = videoForWriting.Level,
                Thumbnail = videoForWriting.Thumbnail,
                Title = videoForWriting.Title,
                Url = videoForWriting.Url
            };
            return Json(recommendations, JsonRequestBehavior.AllowGet);
        }

       
         
       

      
        public ActionResult List()
        {
            return PartialView();
        }

       
        public ActionResult Details()
        {
            return PartialView();
        }

       
        public ActionResult Listening()
        {
            return PartialView();
        }

        public ActionResult Writing()
        {
            return PartialView();
        }
         
        [HttpPost]
        public ActionResult SaveAction(int id, string action)
        {
            //try
            //{
            //    var userProgress = Context.UserProgress.Where(a => a.Video == Context.Videos.Where(v => v.Id == id)).FirstOrDefault();
            //    if (userProgress != null)
            //    {
            //        Context.UserProgress.Add(new UserProgress()
            //        {
            //            User = User,   
            //            ListeningModulePassed = action == "Listening" ? true : false,
            //            WritingModulePassed = action == "Writening" ? true : false,
            //            Video = Context.Videos.Where(v => v.Id == id).FirstOrDefault()
            //        });
            //    }
            //    else
            //    {
            //        if (action == "listening")
            //        {
            //            _userProgress[index].ListeningModulePassed = true;
            //        }
            //        else if (action == "writening")
            //        {
            //            _userProgress[index].WritingModulePassed = true;
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    return Json("Error", JsonRequestBehavior.AllowGet);
            //}
            return Json("Success", JsonRequestBehavior.AllowGet);
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
                        Level = (int)Enums.Level.PreIntermediate,
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

        //public string TranslateGoogle(string text, string from, string to)
        //{
        //    from = from.ToLower();
        //    to = to.ToLower();

        //    // normalize the culture in case something like en-us was passed 
        //    // retrieve only en since Google doesn't support sub-locales
        //    string[] tokens = from.Split('-');
        //    if (tokens.Length > 1)
        //        from = tokens[0];

        //    // normalize ToCulture
        //    tokens = to.Split('-');
        //    if (tokens.Length > 1)
        //        to = tokens[0];

        //    string url =
        //        $@"https://translate.googleapis.com/translate_a/single?client=gtx&sl={@from}&tl={to}&dt=t&q={
        //            HttpUtility.UrlEncode(text)}";
            

        //    // Retrieve Translation with HTTP GET call
        //    string html = null;
        //    try
        //    {
        //        var web = new WebClient();

        //        // MUST add a known browser user agent or else response encoding doen't return UTF-8 (WTF Google?)
        //        web.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
        //        web.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");

        //        // Make sure we have response encoding to UTF-8
        //        web.Encoding = Encoding.UTF8;
        //        html = web.DownloadString(url);
        //    }
        //    catch (Exception ex)
        //    {               
        //        return "";
        //    }
        //    html = html.Replace("],[", ",");
        //    html = html.Replace("]", string.Empty);
        //    html = html.Replace("[", string.Empty);
        //    html = html.Replace("\",\"", "\"");
        //    string[] phrases = html.Split(new[] { '\"' }, StringSplitOptions.RemoveEmptyEntries);
        //    string translation = "";
        //    for (int i = 0; (i < phrases.Count() - 1); i += 2)
        //    {
        //        string translatedPhrase = phrases[i];
        //        if (translatedPhrase.StartsWith(",,"))
        //        {
        //            i--;
        //            continue;
        //        }
        //        translation += translatedPhrase + "  ";
        //    }
           

        //    if (string.IsNullOrEmpty(translation))
        //    {
        //        return "";
        //    }
        //    return translation;
        //}
    }
}