using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace LearnEnglish.Business.Utils
{
    public class GoogleTranslate

    {
        public static string TranslateText(string text, string fromLanguage, string toLanguage)
        {
            fromLanguage = fromLanguage.ToLower();
            toLanguage = toLanguage.ToLower();

            // normalize the culture in case something like en-us was passed 
            // retrieve only en since Google doesn't support sub-locales
            string[] tokens = fromLanguage.Split('-');
            if (tokens.Length > 1)
                fromLanguage = tokens[0];

            // normalize ToCulture
            tokens = toLanguage.Split('-');
            if (tokens.Length > 1)
                toLanguage = tokens[0];

            string url =
                $@"https://translate.googleapis.com/translate_a/single?client=gtx&sl={@fromLanguage}&tl={toLanguage}&dt=t&q={
                    HttpUtility.UrlEncode(text)}";


            // Retrieve Translation with HTTP GET call
            string html = null;
            try
            {
                var web = new WebClient();

                // MUST add a known browser user agent or else response encoding doen't return UTF-8 (WTF Google?)
                web.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
                web.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");

                // Make sure we have response encoding to UTF-8
                web.Encoding = Encoding.UTF8;
                html = web.DownloadString(url);
            }
            catch (Exception ex)
            {
                return "";
            }
            html = html.Replace("],[", ",");
            html = html.Replace("]", string.Empty);
            html = html.Replace("[", string.Empty);
            html = html.Replace("\",\"", "\"");
            string[] phrases = html.Split(new[] { '\"' }, StringSplitOptions.RemoveEmptyEntries);
            string translation = "";
            for (int i = 0; (i < phrases.Count() - 1); i += 2)
            {
                string translatedPhrase = phrases[i];
                if (translatedPhrase.StartsWith(",,"))
                {
                    i--;
                    continue;
                }
                translation += translatedPhrase + "  ";
            }


            if (string.IsNullOrEmpty(translation))
            {
                return "";
            }
            return translation;
        }
    }
}
