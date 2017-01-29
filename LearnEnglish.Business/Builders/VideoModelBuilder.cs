using LearnEnglish.Business.Builders.Interfaces;
using LearnEnglish.Business.Models;
using LearnEnglish.Data.Entities;

namespace LearnEnglish.Business.Builders
{
    public class VideoModelBuilder : IVideoModelBuilder
    {
        public VideoModel Build(Video video)
        {
            return new VideoModel
            {
                Id = video.Id,
                Language = video.Language,
                Level = video.Level,
                Thumbnail = video.Thumbnail,
                Url = video.Url,
                Title = video.Title
                //ListeningModulePassed = j == null ? false : j.WritingModulePassed,
                //WritingModulePassed = j == null ? false : j.WritingModulePassed
            };
        }
       
    }
}