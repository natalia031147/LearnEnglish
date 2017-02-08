using System.Web.Http;
using LearnEnglish.Business.Utils;

namespace LearnEnglish.Api
{
    public class GoogleTranslateController : ApiController
    {
        public string Get([FromUri] string phrase)
        {
            return GoogleTranslate.TranslateText(phrase, "en", "ro");
        }
    }
}