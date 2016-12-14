﻿using System;
using System.Data.Entity.Migrations;
using System.Globalization;
using LearnEnglish.Models;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace LearnEnglish.Controllers
{
    public class VideoController : Controller
    {
        private List<Video> _videos;
        private List<VideoPhrase> _videosPhrases;
        public VideoController()
        {
            #region InitList
            _videos = new List<Video>();
            _videos.Add(new Models.Video() { Id = 1, Language = "en", Level = (int)Common.Enums.Level.PreIntermediate, Thumbnail = "https://i.ytimg.com/vi/4Y8WR5VrN9E/mqdefault.jpg", Title = "dady is the sweetest daddy in the world", Url = "https://www.youtube.com/watch?v=4Y8WR5VrN9E" });
            _videos.Add(new Models.Video() { Id = 2, Language = "en", Level = (int)Common.Enums.Level.Intermediate, Thumbnail = "https://i.ytimg.com/vi/y5-vt3f8JM4/mqdefault.jpg", Title = "The Proposal - Film Clip", Url = "https://www.youtube.com/watch?v=y5-vt3f8JM4" });
            _videos.Add(new Models.Video() { Id = 3, Language = "en", Level = (int)Common.Enums.Level.PreIntermediate, Thumbnail = "https://i.ytimg.com/vi/zgnHF2CwrPs/mqdefault.jpg", Title = "Hercules I can Go The Distance", Url = "https://www.youtube.com/watch?v=zgnHF2CwrPs" });
            _videos.Add(new Models.Video() { Id = 4, Language = "en", Level = (int)Common.Enums.Level.PreIntermediate, Thumbnail = "https://i.ytimg.com/vi/1EZQ3rqO-_I/mqdefault.jpg", Title = "Game of Thrones 6x10 Martels and Lord Varys", Url = "https://www.youtube.com/watch?v=1EZQ3rqO-_I" });
            _videos.Add(new Models.Video() { Id = 5, Language = "en", Level = (int)Common.Enums.Level.UpperIntermediate, Thumbnail = "https://i.ytimg.com/vi/re5veV2F7eY/mqdefault.jpg", Title = "Mean Girls (1/10) Movie CLIP - Meeting the Plastics (2004)", Url = "https://www.youtube.com/watch?v=re5veV2F7eY" });
            _videos.Add(new Models.Video() { Id = 6, Language = "en", Level = (int)Common.Enums.Level.UpperIntermediate, Thumbnail = "https://i.ytimg.com/vi/wc93gQRRKbA/mqdefault.jpg", Title = "Tyrion's Trial in the Vale", Url = "https://www.youtube.com/watch?v=wc93gQRRKbA" });
            _videos.Add(new Models.Video() { Id = 7, Language = "en", Level = (int)Common.Enums.Level.Elementary, Thumbnail = "https://i.ytimg.com/vi/DQYNM6SjD_o/mqdefault.jpg", Title = "Miranda Lambert - The House That Built Me", Url = "https://www.youtube.com/watch?v=DQYNM6SjD_o" });
            _videos.Add(new Models.Video() { Id = 8, Language = "en", Level = (int)Common.Enums.Level.Intermediate, Thumbnail = "https://i.ytimg.com/vi/HSzx-zryEgM/mqdefault.jpg", Title = "Doctor Strange Official Trailer 2", Url = "https://www.youtube.com/watch?v=HSzx-zryEgM" });
            _videos.Add(new Models.Video() { Id = 9, Language = "en", Level = (int)Common.Enums.Level.Advanced, Thumbnail = "https://i.ytimg.com/vi/-bN_xU5kbSs/mqdefault.jpg", Title = "Guardians of the Galaxy Movie CLIP - Prison Break (2014) - Bradley Cooper Movie", Url = "https://www.youtube.com/watch?v=-bN_xU5kbSs" });

            _videosPhrases = new List<VideoPhrase>();
            _videosPhrases.Add(new VideoPhrase() { Id = 1, OrderNumber = 1, StartTime = 0.0f, EndTime = 7.1f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 2, OrderNumber = 2, StartTime = 7.1f, EndTime = 10.3f, Video = _videos[0], Phrase = "Daddy is the sweetest daddy in the world.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 3, OrderNumber = 3, StartTime = 10.3f, EndTime = 14.0f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 4, OrderNumber = 4, StartTime = 14.0f, EndTime = 16.8f, Video = _videos[0], Phrase = "Daddy is the most handsome.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 5, OrderNumber = 5, StartTime = 16.0f, EndTime = 21.0f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 6, OrderNumber = 6, StartTime = 21.0f, EndTime = 22.5f, Video = _videos[0], Phrase = "The smartest.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 7, OrderNumber = 7, StartTime = 22.5f, EndTime = 28.3f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 8, OrderNumber = 8, StartTime = 28.3f, EndTime = 29.8f, Video = _videos[0], Phrase = "The most clever.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 9, OrderNumber = 9, StartTime = 29.8f, EndTime = 32.4f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 10, OrderNumber = 10, StartTime = 32.4f, EndTime = 33.7f, Video = _videos[0], Phrase = "The kindest.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 11, OrderNumber = 11, StartTime = 33.7f, EndTime = 39.0f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 12, OrderNumber = 12, StartTime = 39.0f, EndTime = 41.0f, Video = _videos[0], Phrase = "He is my superman.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 13, OrderNumber = 13, StartTime = 41.0f, EndTime = 44.1f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 14, OrderNumber = 14, StartTime = 44.1f, EndTime = 47.5f, Video = _videos[0], Phrase = "Daddy wants me to do well at school.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 15, OrderNumber = 15, StartTime = 47.5f, EndTime = 50.2f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 16, OrderNumber = 16, StartTime = 50.2f, EndTime = 52.8f, Video = _videos[0], Phrase = "Daddy is just great. But.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 17, OrderNumber = 17, StartTime = 52.8f, EndTime = 58.5f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 18, OrderNumber = 18, StartTime = 58.5f, EndTime = 59.4f, Video = _videos[0], Phrase = "He lies.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 19, OrderNumber = 19, StartTime = 59.4f, EndTime = 75.9f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 20, OrderNumber = 20, StartTime = 75.9f, EndTime = 79.6f, Video = _videos[0], Phrase = "He lies about having a job.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 21, OrderNumber = 21, StartTime = 79.6f, EndTime = 85.7f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 22, OrderNumber = 22, StartTime = 85.7f, EndTime = 89.1f, Video = _videos[0], Phrase = "He lies about having money.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 23, OrderNumber = 23, StartTime = 89.1f, EndTime = 97.1f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 24, OrderNumber = 24, StartTime = 97.1f, EndTime = 100.1f, Video = _videos[0], Phrase = "He lies that he is not tired.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 25, OrderNumber = 25, StartTime = 100.1f, EndTime = 106.1f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 26, OrderNumber = 26, StartTime = 106.1f, EndTime = 109.2f, Video = _videos[0], Phrase = "He lies that he is not hungry.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 27, OrderNumber = 27, StartTime = 109.2f, EndTime = 113.6f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 28, OrderNumber = 28, StartTime = 113.6f, EndTime = 117.3f, Video = _videos[0], Phrase = "He lies that we have everything.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 29, OrderNumber = 29, StartTime = 117.3f, EndTime = 126.8f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 30, OrderNumber = 30, StartTime = 126.8f, EndTime = 130.4f, Video = _videos[0], Phrase = "He lies about his happiness.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 31, OrderNumber = 31, StartTime = 130.4f, EndTime = 135.8f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 32, OrderNumber = 32, StartTime = 135.8f, EndTime = 140.0f, Video = _videos[0], Phrase = "He lies because of me.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 33, OrderNumber = 33, StartTime = 140.0f, EndTime = 207.0f, Video = _videos[0], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 34, OrderNumber = 1, StartTime = 0.0f, EndTime = 9.7f, Video = _videos[1], Phrase = "Did I miss the story? What story? About how you proposed. I actually would love to hear the story, Andrew. Would you tell us?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 35, OrderNumber = 2, StartTime = 9.7f, EndTime = 15.4f, Video = _videos[1], Phrase = "Margaret loves telling this story... so I'm just gonna let her go ahead and do that.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 36, OrderNumber = 3, StartTime = 15.4f, EndTime = 22.9f, Video = _videos[1], Phrase = "Ok, well, um, Andrew and I were about to celebrate our first anniversary together.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 37, OrderNumber = 4, StartTime = 22.9f, EndTime = 28.8f, Video = _videos[1], Phrase = "And I knew he'd been itching to ask me to marry him. And he was scared. Like a little tiny bird.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 38, OrderNumber = 5, StartTime = 28.8f, EndTime = 38.1f, Video = _videos[1], Phrase = "So I started leaving him little hints here and there... because I knew he wouldn't have the guts to ask, but... That's not exactly how it happened. No? No.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 39, OrderNumber = 6, StartTime = 38.1f, EndTime = 43.6f, Video = _videos[1], Phrase = "No. I mean, I picked up on all her little hints. This woman's about as subtle as a gun.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 40, OrderNumber = 7, StartTime = 43.6f, EndTime = 57.1f, Video = _videos[1], Phrase = "Yeah. What I was worried about was that she might find this little box... Oh, that decoupage box that he made where he'd taken the time to cut out tiny little pictures of himself. Yes.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 41, OrderNumber = 8, StartTime = 57.1f, EndTime = 67.4f, Video = _videos[1], Phrase = "Just pasted all over the box. Oh! So beautiful. So, I opened that beautiful, little decoupage and out fluttered these tiny, little hand-cut heart confettis.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 42, OrderNumber = 9, StartTime = 67.4f, EndTime = 75.2f, Video = _videos[1], Phrase = "And once they cleared, I looked down, and I saw... the most beautiful, big... fat nothing.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 43, OrderNumber = 10, StartTime = 75.2f, EndTime = 85.4f, Video = _videos[1], Phrase = "No ring. No ring? What? No, but inside that box... underneath all that crap... there was a little handwritten note.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 44, OrderNumber = 11, StartTime = 85.4f, EndTime = 93.5f, Video = _videos[1], Phrase = "with the address to a hotel, date and time. Real Humphrey Bogart-type stuff. Masculine.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 45, OrderNumber = 12, StartTime = 93.5f, EndTime = 102.1f, Video = _videos[1], Phrase = "Anyway, naturally, Margaret thought... I thought he was seeing someone else. It was a terrible time for me, but I went to that hotel anyway.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 46, OrderNumber = 13, StartTime = 102.1f, EndTime = 111.9f, Video = _videos[1], Phrase = "I went there and I pounded on the door, but the door was already unlocked. And as swung open that door, there he was... Standing. Kneeling.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 47, OrderNumber = 14, StartTime = 111.9f, EndTime = 120.2f, Video = _videos[1], Phrase = "Like a man. On a bed of rose petals, in a tuxedo. Your son. Your son. And he was choking back soft, soft sobs.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 48, OrderNumber = 15, StartTime = 120.2f, EndTime = 125.1f, Video = _videos[1], Phrase = "And when he held back the tears and finally caught his breath, he said to me...", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 49, OrderNumber = 16, StartTime = 125.1f, EndTime = 129.9f, Video = _videos[1], Phrase = "Margaret, will you marry me? And she said, Yep. The end. Who's hungry?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 50, OrderNumber = 1, StartTime = 0.0f, EndTime = 7.8f, Video = _videos[2], Phrase = "Sometimes I feel like, like I really don't belong here.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 51, OrderNumber = 2, StartTime = 7.8f, EndTime = 14.9f, Video = _videos[2], Phrase = "Like I'm supposed to be someplace else. Hercules, son", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 52, OrderNumber = 3, StartTime = 14.9f, EndTime = 22.3f, Video = _videos[2], Phrase = "I know it doesn't make any sense.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 53, OrderNumber = 4, StartTime = 22.3f, EndTime = 27.4f, Video = _videos[2], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 54, OrderNumber = 5, StartTime = 27.4f, EndTime = 33.1f, Video = _videos[2], Phrase = "I have often dreamed of a far off place", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 55, OrderNumber = 6, StartTime = 33.1f, EndTime = 38.5f, Video = _videos[2], Phrase = "Where a great, warm welcome will be waiting for me", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 56, OrderNumber = 7, StartTime = 38.5f, EndTime = 43.9f, Video = _videos[2], Phrase = "Where the crowds will cheer when they see my face", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 57, OrderNumber = 8, StartTime = 43.9f, EndTime = 49.5f, Video = _videos[2], Phrase = "And a voice keeps sayin' this is where I'm meant to be", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 58, OrderNumber = 9, StartTime = 49.5f, EndTime = 55.8f, Video = _videos[2], Phrase = "I will find my way I can go the distance", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 59, OrderNumber = 10, StartTime = 55.8f, EndTime = 61.2f, Video = _videos[2], Phrase = "I'll be there someday If I can be strong", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 60, OrderNumber = 11, StartTime = 61.2f, EndTime = 68.0f, Video = _videos[2], Phrase = "I know every mile Will be worth my while", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 61, OrderNumber = 12, StartTime = 68.0f, EndTime = 78.0f, Video = _videos[2], Phrase = "I would go most anywhere to feel like I belong.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 62, OrderNumber = 13, StartTime = 78.0f, EndTime = 88.6f, Video = _videos[2], Phrase = "Hercules, there's something your mother and I have been meaning to tell ya.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 63, OrderNumber = 14, StartTime = 88.6f, EndTime = 95.2f, Video = _videos[2], Phrase = "But if you found me, then where did I come from? Why was I left here?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 64, OrderNumber = 15, StartTime = 95.2f, EndTime = 105.0f, Video = _videos[2], Phrase = "This was around your neck when we found you. It's the symbol of the gods.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 65, OrderNumber = 16, StartTime = 105.0f, EndTime = 112.3f, Video = _videos[2], Phrase = "This is it! Don't you see? Maybe they have the answers! I'll go to the temple of Zeus and", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 66, OrderNumber = 17, StartTime = 112.3f, EndTime = 124.8f, Video = _videos[2], Phrase = "Ma, Pop, you're the greatest parents anyone could have, but. I gotta know", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 67, OrderNumber = 18, StartTime = 124.8f, EndTime = 142.3f, Video = _videos[2], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 68, OrderNumber = 19, StartTime = 142.3f, EndTime = 147.3f, Video = _videos[2], Phrase = "I am on my way I can go the distance", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 69, OrderNumber = 20, StartTime = 147.3f, EndTime = 152.8f, Video = _videos[2], Phrase = "I don't care how far Somehow I'll be strong", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 70, OrderNumber = 21, StartTime = 152.8f, EndTime = 158.8f, Video = _videos[2], Phrase = "I know every mile Will be worth my while", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 71, OrderNumber = 22, StartTime = 158.8f, EndTime = 168.6f, Video = _videos[2], Phrase = "I would go most everywhere to find where I belong.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 72, OrderNumber = 23, StartTime = 168.6f, EndTime = 182.7f, Video = _videos[2], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 73, OrderNumber = 1, StartTime = 0.0f, EndTime = 6.0f, Video = _videos[3], Phrase = "The last time a Tyrell came to Dorne, he was assassinated.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 74, OrderNumber = 2, StartTime = 6.0f, EndTime = 8.6f, Video = _videos[3], Phrase = "A hundred red scorpions, was it?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 75, OrderNumber = 3, StartTime = 8.6f, EndTime = 11.1f, Video = _videos[3], Phrase = "You have nothing to fear from us, Lady Olenna.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 76, OrderNumber = 4, StartTime = 11.1f, EndTime = 15.2f, Video = _videos[3], Phrase = "You murder your own prince, but you expect me to trust you?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 77, OrderNumber = 5, StartTime = 15.2f, EndTime = 18.0f, Video = _videos[3], Phrase = "We invited you to Dorne because we needed your help.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 78, OrderNumber = 6, StartTime = 18.0f, EndTime = 20.8f, Video = _videos[3], Phrase = "You came to Dorne because you needed our help.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 79, OrderNumber = 7, StartTime = 20.8f, EndTime = 26.5f, Video = _videos[3], Phrase = "What is your name again? Barbaro? Obara.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 80, OrderNumber = 8, StartTime = 26.5f, EndTime = 32.3f, Video = _videos[3], Phrase = "Obara. You look like an angry little boy. Don't presume to tell me what I need.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 81, OrderNumber = 9, StartTime = 32.3f, EndTime = 37.0f, Video = _videos[3], Phrase = "Forgive my sister. What she lacks in diplomacy, she makes... Do shut up, dear.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 82, OrderNumber = 10, StartTime = 37.0f, EndTime = 44.2f, Video = _videos[3], Phrase = "Anything from you? No? Good. Let the grown women speak.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 83, OrderNumber = 11, StartTime = 44.2f, EndTime = 50.5f, Video = _videos[3], Phrase = "The Lannisters have declared war on Hause Tyrell. They have declared war on Dorne.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 84, OrderNumber = 12, StartTime = 50.5f, EndTime = 54.6f, Video = _videos[3], Phrase = "We must be allies now if we wish to survive.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 85, OrderNumber = 13, StartTime = 54.6f, EndTime = 65.0f, Video = _videos[3], Phrase = "Cersei stole the future from me. She killed my son. She killed my grandson. She killed my granddaughter.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 86, OrderNumber = 14, StartTime = 65.0f, EndTime = 69.0f, Video = _videos[3], Phrase = "Survival is not what I'm after now.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 87, OrderNumber = 15, StartTime = 69.0f, EndTime = 73.5f, Video = _videos[3], Phrase = "You are absolutely right. I chose the wrong words.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 88, OrderNumber = 16, StartTime = 73.5f, EndTime = 80.8f, Video = _videos[3], Phrase = "It is not survival I offer. It is your heart's desire.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 89, OrderNumber = 17, StartTime = 80.8f, EndTime = 96.9f, Video = _videos[3], Phrase = "And what is my heart's desire? Vengeance. Justice. Fire and blood.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 90, OrderNumber = 18, StartTime = 96.9f, EndTime = 98.0f, Video = _videos[3], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 91, OrderNumber = 1, StartTime = 0.0f, EndTime = 4.2f, Video = _videos[4], Phrase = "Why don't I know you? I'm new. I just moved here from Africa.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 92, OrderNumber = 2, StartTime = 4.2f, EndTime = 8.3f, Video = _videos[4], Phrase = "What? I used to be home-schooled. Wait. What?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 93, OrderNumber = 3, StartTime = 8.3f, EndTime = 12.2f, Video = _videos[4], Phrase = "My mom taught me at home... No, no. I know what home-school is. I'm not retarded.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 94, OrderNumber = 4, StartTime = 12.2f, EndTime = 14.6f, Video = _videos[4], Phrase = "So you've actually never been to a real school before?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 95, OrderNumber = 5, StartTime = 14.6f, EndTime = 22.9f, Video = _videos[4], Phrase = "Shut up. Shut up. I didn't say anything. Home-schooled.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 96, OrderNumber = 6, StartTime = 22.9f, EndTime = 27.5f, Video = _videos[4], Phrase = "That's really interesting. Thanks. But you're, like, really pretty.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 97, OrderNumber = 7, StartTime = 27.5f, EndTime = 31.8f, Video = _videos[4], Phrase = "Thank you. So you agree. What? You think you're really pretty?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 98, OrderNumber = 8, StartTime = 31.8f, EndTime = 37.9f, Video = _videos[4], Phrase = "Oh, I don't know... Oh, my God, I love your bracelet. Where did you get it? Oh, my mom made it for me.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 99, OrderNumber = 9, StartTime = 37.9f, EndTime = 44.4f, Video = _videos[4], Phrase = "It's adorable. Oh, it's so fetch. What is fetch ? Oh, it's, like, slang. From England.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 100, OrderNumber = 10, StartTime = 44.4f, EndTime = 51.7f, Video = _videos[4], Phrase = "So if you're from Africa... why are you white? Oh, my God, Karen, you can't just ask people why they're white.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 101, OrderNumber = 11, StartTime = 51.7f, EndTime = 60.0f, Video = _videos[4], Phrase = "Could you give us some privacy for, like, one second? Yeah, sure.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 102, OrderNumber = 12, StartTime = 60.0f, EndTime = 66.9f, Video = _videos[4], Phrase = "OK, you should just know that we don't do this a lot, so this is, like, a really huge deal.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 103, OrderNumber = 13, StartTime = 66.9f, EndTime = 71.2f, Video = _videos[4], Phrase = "We wanna invite you to have lunch with us every day for the rest of the week.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 104, OrderNumber = 14, StartTime = 71.2f, EndTime = 80.6f, Video = _videos[4], Phrase = "Oh, it's OK... Coolness. So we'll see you tomorrow. On Wednesdays, we wear pink.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 105, OrderNumber = 15, StartTime = 80.6f, EndTime = 106f, Video = _videos[4], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 106, OrderNumber = 1, StartTime = 0.0f, EndTime = 7.4f, Video = _videos[5], Phrase = "You wish to confess your crimes?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 107, OrderNumber = 2, StartTime = 7.4f, EndTime = 10.2f, Video = _videos[5], Phrase = "Yes, My Lady. I do, My Lady.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 108, OrderNumber = 3, StartTime = 10.2f, EndTime = 19.5f, Video = _videos[5], Phrase = "The sky cells always break them! Speak, Imp. Meet your gods as an honest man.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 109, OrderNumber = 4, StartTime = 19.5f, EndTime = 31.8f, Video = _videos[5], Phrase = "Where do I begin, my lords and ladies? I am a vile man, I confess it", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 110, OrderNumber = 5, StartTime = 31.8f, EndTime = 41.7f, Video = _videos[5], Phrase = "My crimes and sins are beyond counting. I have lied and cheated, gambled and whored", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 111, OrderNumber = 6, StartTime = 41.7f, EndTime = 49.7f, Video = _videos[5], Phrase = "I'm not particularly good at violence, but I'm good at convincing others to do violence for me.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 112, OrderNumber = 7, StartTime = 49.7f, EndTime = 59.8f, Video = _videos[5], Phrase = "You want specifics, I suppose. When I was seven, I saw a servant girl bathing in the river", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 113, OrderNumber = 8, StartTime = 59.8f, EndTime = 65.9f, Video = _videos[5], Phrase = "I stole her robe and she was forced to return to the castle naked and in tears", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 114, OrderNumber = 9, StartTime = 65.9f, EndTime = 72.6f, Video = _videos[5], Phrase = "I close my eyes, but I can still see her tits bouncing...", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 115, OrderNumber = 10, StartTime = 72.6f, EndTime = 79.9f, Video = _videos[5], Phrase = "When I was ten, I stuffed my uncle's boots with goat shit", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 116, OrderNumber = 11, StartTime = 79.9f, EndTime = 83.1f, Video = _videos[5], Phrase = "When confronted with my crime, I blamed a squire", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 117, OrderNumber = 12, StartTime = 83.1f, EndTime = 87.2f, Video = _videos[5], Phrase = "Poor boy was flogged, and I escaped justice", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 118, OrderNumber = 13, StartTime = 87.2f, EndTime = 92.0f, Video = _videos[5], Phrase = "When I was twelve I milked my eel into a pot of turtle stew.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 119, OrderNumber = 14, StartTime = 92.0f, EndTime = 97.0f, Video = _videos[5], Phrase = "I flogged the one-eyed snake, I skinned my sausage.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 120, OrderNumber = 15, StartTime = 97.0f, EndTime = 105.5f, Video = _videos[5], Phrase = "I made the bald man cry into the turtle stew, which I do believe my sister ate.At least I hope she did", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 121, OrderNumber = 16, StartTime = 105.5f, EndTime = 109.3f, Video = _videos[5], Phrase = "I once brought a jackass and a honeycomb into a brothel...", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 122, OrderNumber = 17, StartTime = 109.3f, EndTime = 110.6f, Video = _videos[5], Phrase = "Silence!", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 123, OrderNumber = 18, StartTime = 110.6f, EndTime = 112.0f, Video = _videos[5], Phrase = "What happened next?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 124, OrderNumber = 19, StartTime = 112.0f, EndTime = 115.4f, Video = _videos[5], Phrase = "What do you think you're doing?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 125, OrderNumber = 20, StartTime = 115.4f, EndTime = 117.2f, Video = _videos[5], Phrase = "Confessing my crimes.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 126, OrderNumber = 21, StartTime = 117.2f, EndTime = 602.0f, Video = _videos[5], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 127, OrderNumber = 1, StartTime = 0.0f, EndTime = 36.1f, Video = _videos[6], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 128, OrderNumber = 2, StartTime = 36.1f, EndTime = 42.0f, Video = _videos[6], Phrase = "I know they say you can't go home again", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 129, OrderNumber = 3, StartTime = 42.0f, EndTime = 48.0f, Video = _videos[6], Phrase = "I just had to come back one last time", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 130, OrderNumber = 4, StartTime = 48.0f, EndTime = 54.0f, Video = _videos[6], Phrase = "Ma'am, I know you don't know me from Adam", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 131, OrderNumber = 5, StartTime = 54.0f, EndTime = 59.2f, Video = _videos[6], Phrase = "But these hand prints on the front steps are mine", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 132, OrderNumber = 6, StartTime = 59.2f, EndTime = 66.0f, Video = _videos[6], Phrase = "Up those stairs in that little back bedroom ...", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 133, OrderNumber = 7, StartTime = 66.0f, EndTime = 71.8f, Video = _videos[6], Phrase = "where I did my homework and I learned to play guitar", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 134, OrderNumber = 8, StartTime = 71.8f, EndTime = 78.3f, Video = _videos[6], Phrase = "And I bet you didn't know under that live oak", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 135, OrderNumber = 9, StartTime = 78.3f, EndTime = 83.3f, Video = _videos[6], Phrase = "My favorite dog is buried in the yard", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 136, OrderNumber = 10, StartTime = 83.3f, EndTime = 89.6f, Video = _videos[6], Phrase = "I thought if I could touch this place or feel it", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 137, OrderNumber = 11, StartTime = 89.6f, EndTime = 95.6f, Video = _videos[6], Phrase = "This brokenness inside me might start healing", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 138, OrderNumber = 12, StartTime = 95.6f, EndTime = 99.4f, Video = _videos[6], Phrase = "Out here it's like I'm someone else", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 139, OrderNumber = 13, StartTime = 99.4f, EndTime = 103.5f, Video = _videos[6], Phrase = "I thought that maybe I could find myself", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 140, OrderNumber = 14, StartTime = 103.5f, EndTime = 109.4f, Video = _videos[6], Phrase = "If I could just come in, I swear I'll leave", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 141, OrderNumber = 15, StartTime = 109.4f, EndTime = 119.5f, Video = _videos[6], Phrase = "Won't take nothing but a memory from the house that built me", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 142, OrderNumber = 16, StartTime = 119.5f, EndTime = 127.3f, Video = _videos[6], Phrase = "Mama cut out pictures of houses for years ...", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 143, OrderNumber = 17, StartTime = 127.3f, EndTime = 132.6f, Video = _videos[6], Phrase = "from Better Homes and Garden magazine.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 144, OrderNumber = 18, StartTime = 132.6f, EndTime = 140.6f, Video = _videos[6], Phrase = "Plans were drawn and concrete poured. And nail by nail and board by board ...", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 145, OrderNumber = 19, StartTime = 140.6f, EndTime = 144.9f, Video = _videos[6], Phrase = "Daddy gave life to mama's dream.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 146, OrderNumber = 20, StartTime = 144.9f, EndTime = 151.7f, Video = _videos[6], Phrase = "I thought if I could touch this place or feel it", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 147, OrderNumber = 21, StartTime = 151.7f, EndTime = 157.5f, Video = _videos[6], Phrase = "This brokenness inside me might start healing", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 148, OrderNumber = 22, StartTime = 157.5f, EndTime = 161.6f, Video = _videos[6], Phrase = "Out here it's like I'm someone else", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 149, OrderNumber = 23, StartTime = 161.6f, EndTime = 166.2f, Video = _videos[6], Phrase = "I thought that maybe I could find myself", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 150, OrderNumber = 24, StartTime = 166.2f, EndTime = 171.8f, Video = _videos[6], Phrase = "If I could just come in, I swear I'll leave", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 151, OrderNumber = 25, StartTime = 171.8f, EndTime = 180.9f, Video = _videos[6], Phrase = "Won't take nothing but a memory from the house that built me", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 152, OrderNumber = 26, StartTime = 180.9f, EndTime = 190.8f, Video = _videos[6], Phrase = "You leave home, you move on and you do the best you can.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 153, OrderNumber = 27, StartTime = 190.8f, EndTime = 198.9f, Video = _videos[6], Phrase = "I got lost in this whole world and forgot who I am.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 154, OrderNumber = 28, StartTime = 198.9f, EndTime = 205.0f, Video = _videos[6], Phrase = "I thought if I could touch this place or feel it", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 155, OrderNumber = 29, StartTime = 205.0f, EndTime = 211.1f, Video = _videos[6], Phrase = "This brokenness inside me might start healing", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 156, OrderNumber = 30, StartTime = 211.1f, EndTime = 215.0f, Video = _videos[6], Phrase = "Out here it's like I'm someone else", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 157, OrderNumber = 31, StartTime = 215.0f, EndTime = 219.5f, Video = _videos[6], Phrase = "I thought that maybe I could find myself", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 158, OrderNumber = 32, StartTime = 219.5f, EndTime = 225.0f, Video = _videos[6], Phrase = "If I could walk around, I swear I'll leave", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 159, OrderNumber = 33, StartTime = 225.0f, EndTime = 234.2f, Video = _videos[6], Phrase = "Won't take nothing but a memory from the house that built me", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 160, OrderNumber = 34, StartTime = 234.2f, EndTime = 251.9f, Video = _videos[6], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 161, OrderNumber = 1, StartTime = 0.0f, EndTime = 4.7f, Video = _videos[7], Phrase = "Doctor Strange,", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 162, OrderNumber = 2, StartTime = 4.7f, EndTime = 8.2f, Video = _videos[7], Phrase = "You think you know how the world works", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 163, OrderNumber = 3, StartTime = 8.2f, EndTime = 12.0f, Video = _videos[7], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 164, OrderNumber = 4, StartTime = 12.0f, EndTime = 17.6f, Video = _videos[7], Phrase = "What if I told you that reality you know is one of many?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 165, OrderNumber = 5, StartTime = 17.6f, EndTime = 20.9f, Video = _videos[7], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 166, OrderNumber = 6, StartTime = 20.9f, EndTime = 24.8f, Video = _videos[7], Phrase = "This doesn't make any sens. Not everything does.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 167, OrderNumber = 7, StartTime = 24.8f, EndTime = 28.3f, Video = _videos[7], Phrase = "Not everything has to.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 168, OrderNumber = 8, StartTime = 28.3f, EndTime = 33.2f, Video = _videos[7], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 169, OrderNumber = 9, StartTime = 33.2f, EndTime = 41.9f, Video = _videos[7], Phrase = "Through the mystic odds we harness energy and shape reality", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 170, OrderNumber = 10, StartTime = 41.9f, EndTime = 46.2f, Video = _videos[7], Phrase = "and travel great distances in an instant", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 171, OrderNumber = 11, StartTime = 46.2f, EndTime = 49.1f, Video = _videos[7], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 172, OrderNumber = 12, StartTime = 49.1f, EndTime = 51.7f, Video = _videos[7], Phrase = "How do I get from here to there?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 173, OrderNumber = 13, StartTime = 51.7f, EndTime = 56.5f, Video = _videos[7], Phrase = "How did you become a doctor? Study and practice. Use of it.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 174, OrderNumber = 14, StartTime = 56.5f, EndTime = 59.2f, Video = _videos[7], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 175, OrderNumber = 15, StartTime = 59.2f, EndTime = 60.5f, Video = _videos[7], Phrase = "What's that?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 176, OrderNumber = 16, StartTime = 60.5f, EndTime = 65.2f, Video = _videos[7], Phrase = "There's a strength to him. But is he ready?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 177, OrderNumber = 17, StartTime = 65.2f, EndTime = 70.1f, Video = _videos[7], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 178, OrderNumber = 18, StartTime = 70.1f, EndTime = 76.1f, Video = _videos[7], Phrase = "Be careful which path you travel doctor Strange. Stronger men than you have lost their way", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 179, OrderNumber = 19, StartTime = 76.1f, EndTime = 83.2f, Video = _videos[7], Phrase = "I'm death and pain.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 180, OrderNumber = 20, StartTime = 83.2f, EndTime = 87.6f, Video = _videos[7], Phrase = "You'll die protecting this world.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 181, OrderNumber = 21, StartTime = 87.6f, EndTime = 92.0f, Video = _videos[7], Phrase = "I can't do this. There is no other way.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 182, OrderNumber = 22, StartTime = 92.0f, EndTime = 98.0f, Video = _videos[7], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 183, OrderNumber = 23, StartTime = 98.0f, EndTime = 103.7f, Video = _videos[7], Phrase = "I have spent so many years hearing through time", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 184, OrderNumber = 24, StartTime = 103.7f, EndTime = 106.3f, Video = _videos[7], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 185, OrderNumber = 25, StartTime = 106.3f, EndTime = 110.2f, Video = _videos[7], Phrase = "Looking for you", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 186, OrderNumber = 26, StartTime = 110.2f, EndTime = 120.0f, Video = _videos[7], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 187, OrderNumber = 27, StartTime = 120.0f, EndTime = 124.3f, Video = _videos[7], Phrase = "What's this? Fine mantra?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 188, OrderNumber = 28, StartTime = 124.3f, EndTime = 130.1f, Video = _videos[7], Phrase = "It's the wi-fi password. We are not savages.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 189, OrderNumber = 29, StartTime = 130.1f, EndTime = 141.6f, Video = _videos[7], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 190, OrderNumber = 1, StartTime = 0.0f, EndTime = 1.5f, Video = _videos[8], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 191, OrderNumber = 2, StartTime = 1.5f, EndTime = 4.5f, Video = _videos[8], Phrase = "If we're gonna get out of here, we're gonna need to get into that watchtower.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 192, OrderNumber = 3, StartTime = 4.5f, EndTime = 7.0f, Video = _videos[8], Phrase = "And to do that I'm gonna need a few things.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 193, OrderNumber = 4, StartTime = 7.0f, EndTime = 13.3f, Video = _videos[8], Phrase = "The guards wear security bands to control their ins and outs. I need one. Leave it to me.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 194, OrderNumber = 5, StartTime = 13.3f, EndTime = 17.9f, Video = _videos[8], Phrase = "That dude there. I need his prosthetic leg. His leg? Yeah.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 195, OrderNumber = 6, StartTime = 17.9f, EndTime = 20.6f, Video = _videos[8], Phrase = "God knows I don't need the rest of him. Look at him, he is useless.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 196, OrderNumber = 7, StartTime = 20.6f, EndTime = 26.1f, Video = _videos[8], Phrase = "All right. And finally, on the wall back there is a black panel. Blinky yellow light.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 197, OrderNumber = 8, StartTime = 26.1f, EndTime = 32.4f, Video = _videos[8], Phrase = "Do you see it? Yeah. There's a quarnyx battery behind it. Purplish box, green wires.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 198, OrderNumber = 9, StartTime = 32.4f, EndTime = 34.8f, Video = _videos[8], Phrase = "To get into that watchtower, I definitely need it.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 199, OrderNumber = 10, StartTime = 34.8f, EndTime = 36.4f, Video = _videos[8], Phrase = "How are we supposed to do that?", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 200, OrderNumber = 11, StartTime = 36.4f, EndTime = 40.3f, Video = _videos[8], Phrase = "Well, supposably, these bald-bodies find you attractive. So maybe you can work out some sort of trade.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 201, OrderNumber = 12, StartTime = 40.3f, EndTime = 43.3f, Video = _videos[8], Phrase = "You must be joking. No, I really heard they find you attractive.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 202, OrderNumber = 13, StartTime = 43.3f, EndTime = 47.9f, Video = _videos[8], Phrase = "Look, it's 20 feet up in the air and it's in the middle of the most heavily-guarded part of the prison.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 203, OrderNumber = 14, StartTime = 47.9f, EndTime = 50.5f, Video = _videos[8], Phrase = "It's impossible to get up there without being seen.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 204, OrderNumber = 15, StartTime = 50.5f, EndTime = 56.3f, Video = _videos[8], Phrase = "I got one plan and that plan requires a fricking quarnyx battery, so figure it out!", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 205, OrderNumber = 16, StartTime = 56.3f, EndTime = 60.2f, Video = _videos[8], Phrase = "Can I get back to it? Thanks. Now, this is important.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 206, OrderNumber = 17, StartTime = 60.2f, EndTime = 64.5f, Video = _videos[8], Phrase = "Once the battery is removed, everything is gonna slam into emergency mode.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 207, OrderNumber = 18, StartTime = 64.5f, EndTime = 70.0f, Video = _videos[8], Phrase = "Once we have it, we gotta move quickly, so you definitely need to get that last.", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 208, OrderNumber = 19, StartTime = 70.0f, EndTime = 75.7f, Video = _videos[8], Phrase = "", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 209, OrderNumber = 20, StartTime = 75.7f, EndTime = 78.2f, Video = _videos[8], Phrase = "Or we could just get it first and improvise!", TranslateLanguage = "ro", PhraseTranslated = "" });
            _videosPhrases.Add(new VideoPhrase() { Id = 210, OrderNumber = 21, StartTime = 78.2f, EndTime = 83.7f, Video = _videos[8], Phrase = "I'll get the armband. Leg.", TranslateLanguage = "ro", PhraseTranslated = "" });

            #endregion
        }


        // GET: Video
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Videos()
        {

            return View();
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