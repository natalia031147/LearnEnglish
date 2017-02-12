using System.Collections.Generic;
using System.Web.Http;
using LearnEnglish.Business.Logic.Interfaces;
using LearnEnglish.Business.Models;
using Newtonsoft.Json.Linq;

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
       
        public string Add([FromBody]JObject data) //VideoPhraseModel video, IEnumerable<PhrasePartModel> videoPhrases
        {
            IList<PhrasePartModel> videoPhrases = new List<PhrasePartModel>();
            foreach (var item in data["videoPhrases"])
            {
                videoPhrases.Add(item.ToObject<PhrasePartModel>());
            }
            return _videoLogic.Add(data["video"].ToObject<VideoModel>(), videoPhrases);
        }
    }
}