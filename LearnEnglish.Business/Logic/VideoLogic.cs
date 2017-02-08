﻿using System.Collections.Generic;
using System.Linq;
using LearnEnglish.Business.Builders.Interfaces;
using LearnEnglish.Business.Logic.Interfaces;
using LearnEnglish.Business.Models;
using LearnEnglish.Data.Framework;

namespace LearnEnglish.Business.Logic
{
    public class VideoLogic : BaseLogic, IVideoLogic
    {
        private readonly IVideoModelBuilder _videoModelBuilder;

        public VideoLogic(IVideoModelBuilder videoModelBuilder, ApplicationDbContext context)
            : base(context)
        {
            _videoModelBuilder = videoModelBuilder;
        }

        public ICollection<VideoModel> GetAll()
        {
            var userId = GetUser();

            var videos = Context.Videos.ToList();
            var userProgresses = Context.UserProgress.Where(up => up.User.Id == userId).ToList();

            var models = videos.Select(_videoModelBuilder.Build).ToList();

            foreach (var model in models)
            {
                var progress = userProgresses.FirstOrDefault(up => up.Video.Id == model.Id);
                model.ListeningModulePassed = progress?.ListeningModulePassed ?? false;
                model.WritingModulePassed = progress?.WritingModulePassed ?? false;
                model.SpeakingModulePassed = progress?.SpeakingModulePassed ?? false;
            }

            return models;
        }

        public VideoModel Get(int id)
        {
            var userId = GetUser();
            return (from a in Context.Videos.Where(v => v.Id == id)
                join b in Context.UserProgress.Where(v => v.User.Id == userId) on a equals b.Video into joined
                from j in joined.DefaultIfEmpty()
                select new VideoModel
                {
                    Id = a.Id,
                    Language = a.Language,
                    Level = a.Level,
                    Thumbnail = a.Thumbnail,
                    Url = a.Url,
                    Title = a.Title,
                    ListeningModulePassed = j == null ? false : j.ListeningModulePassed,
                    WritingModulePassed = j == null ? false : j.WritingModulePassed,
                    SpeakingModulePassed = j == null ? false : j.SpeakingModulePassed
                }).ToList().FirstOrDefault();
        }

        public string Add(VideoPhraseModel video)
        {
            return "Save the level Successful."; ;
        }
    }
}