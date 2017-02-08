using System.Collections.Generic;
using System.Web.Http;
using LearnEnglish.Business.Logic.Interfaces;
using LearnEnglish.Business.Models;

namespace LearnEnglish.Api
{
    public class VideoPhraseController : ApiController
    {
        private readonly IVideoPhraseLogic _videoPhraseLogic;

        public VideoPhraseController(IVideoPhraseLogic videoPhraseLogic)
        {
            _videoPhraseLogic = videoPhraseLogic;
        }

        public IEnumerable<VideoPhraseModel> Get([FromUri] int id)
        {
            return _videoPhraseLogic.GetAll(id);
        }

       
    }
}