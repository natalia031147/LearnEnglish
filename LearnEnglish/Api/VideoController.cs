using System.Collections.Generic;
using System.Web.Http;
using LearnEnglish.Business.Logic.Interfaces;
using LearnEnglish.Business.Models;

namespace LearnEnglish.Api
{
    public class VideoController : ApiController
    {
        private readonly IVideoLogic _videoLogic;

        public VideoController(IVideoLogic videoLogic)
        {
            _videoLogic = videoLogic;
        }

        public IEnumerable<VideoModel> Get()
        {
            return _videoLogic.GetAll();
        }

        public VideoModel Get([FromUri] int id)
        {
            return _videoLogic.Get(id);
        }

        [HttpPost]
        public string Add(VideoPhraseModel video)
        {
            return _videoLogic.Add(video);
        }
    }
}