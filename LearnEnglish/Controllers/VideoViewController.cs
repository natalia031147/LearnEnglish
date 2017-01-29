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
       
        // GET: Video
        public ActionResult Add()
        {
            return View();
        }

        
        
        public ActionResult Recommendations()
        {            
            return PartialView();
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
         
        //[HttpPost]
        //public ActionResult SaveAction(int id, string action)
        //{
        //    //try
        //    //{
        //    //    var userProgress = Context.UserProgress.Where(a => a.Video == Context.Videos.Where(v => v.Id == id)).FirstOrDefault();
        //    //    if (userProgress != null)
        //    //    {
        //    //        Context.UserProgress.Add(new UserProgress()
        //    //        {
        //    //            User = User,   
        //    //            ListeningModulePassed = action == "Listening" ? true : false,
        //    //            WritingModulePassed = action == "Writening" ? true : false,
        //    //            Video = Context.Videos.Where(v => v.Id == id).FirstOrDefault()
        //    //        });
        //    //    }
        //    //    else
        //    //    {
        //    //        if (action == "listening")
        //    //        {
        //    //            _userProgress[index].ListeningModulePassed = true;
        //    //        }
        //    //        else if (action == "writening")
        //    //        {
        //    //            _userProgress[index].WritingModulePassed = true;
        //    //        }
        //    //    }

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return Json("Error", JsonRequestBehavior.AllowGet);
        //    //}
        //    return Json("Success", JsonRequestBehavior.AllowGet);
        //}


        //[HttpPost]
        //public ActionResult UpdateVideo(VideoMv videomv) 
        //{
        //    try
        //    {
                

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json("Error", JsonRequestBehavior.AllowGet);
        //    }
        //    return Json("Success", JsonRequestBehavior.AllowGet);
        //}


        //[HttpPost]
        //public ActionResult AddNewVideo(VideoMv videomv)
        //{
        //    try
        //    {
        //        using (ApplicationDbContext context = new ApplicationDbContext())
        //        {
        //            Video video = new Video()
        //            {
        //                Title = videomv.Title,
        //                Url = videomv.Url,
        //                Thumbnail = videomv.Thumbnail,
        //                Level = (int)Enums.Level.PreIntermediate,
        //                Language = videomv.Language
        //            };
        //            context.Videos.Add(video);
        //            context.SaveChanges();
        //            // save  Video Phrases
        //            var index = 1;
        //            foreach (var part in videomv.parts)
        //            {
        //                VideoPhrase videoPhrase = new VideoPhrase()
        //                {
        //                    OrderNumber = index,
        //                    StartTime = float.Parse(part.startTime, CultureInfo.InvariantCulture.NumberFormat),
        //                    EndTime = float.Parse(part.endTime, CultureInfo.InvariantCulture.NumberFormat),
        //                    Video = video,
        //                    Phrase = part.source,
        //                    TranslateLanguage = videomv.Language,
        //                    PhraseTranslated = part.native,
        //                };
        //                index++;
        //                context.VideoPhrases.Add(videoPhrase);
        //            }
        //            context.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //        return Json("Error", JsonRequestBehavior.AllowGet);
        //    }
        //    return Json("Success", JsonRequestBehavior.AllowGet);
        //}

        
    }
}