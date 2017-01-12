using System.Collections.Generic;
using LearnEnglish.Data.Entities;

namespace LearnEnglish.Data.Migrations.Seed
{
    public class VideoDataProvider
    {
        public IList<Video> Create()
        {
            return new List<Video>
            {
                new Video
                {
                    Id = 1,
                    Language = "en",
                    Level = (int) Enums.Level.PreIntermediate,
                    Thumbnail = "https://i.ytimg.com/vi/4Y8WR5VrN9E/mqdefault.jpg",
                    Title = "dady is the sweetest daddy in the world",
                    Url = "https://www.youtube.com/watch?v=4Y8WR5VrN9E"
                },
                new Video
                {
                    Id = 2,
                    Language = "en",
                    Level = (int) Enums.Level.Intermediate,
                    Thumbnail = "https://i.ytimg.com/vi/y5-vt3f8JM4/mqdefault.jpg",
                    Title = "The Proposal - Film Clip",
                    Url = "https://www.youtube.com/watch?v=y5-vt3f8JM4"
                },
                new Video
                {
                    Id = 3,
                    Language = "en",
                    Level = (int) Enums.Level.PreIntermediate,
                    Thumbnail = "https://i.ytimg.com/vi/zgnHF2CwrPs/mqdefault.jpg",
                    Title = "Hercules I can Go The Distance",
                    Url = "https://www.youtube.com/watch?v=zgnHF2CwrPs"
                },
                new Video
                {
                    Id = 4,
                    Language = "en",
                    Level = (int) Enums.Level.PreIntermediate,
                    Thumbnail = "https://i.ytimg.com/vi/1EZQ3rqO-_I/mqdefault.jpg",
                    Title = "Game of Thrones 6x10 Martels and Lord Varys",
                    Url = "https://www.youtube.com/watch?v=1EZQ3rqO-_I"
                },
                new Video
                {
                    Id = 5,
                    Language = "en",
                    Level = (int) Enums.Level.UpperIntermediate,
                    Thumbnail = "https://i.ytimg.com/vi/re5veV2F7eY/mqdefault.jpg",
                    Title = "Mean Girls (1/10) Movie CLIP - Meeting the Plastics (2004)",
                    Url = "https://www.youtube.com/watch?v=re5veV2F7eY"
                },
                new Video
                {
                    Id = 6,
                    Language = "en",
                    Level = (int) Enums.Level.UpperIntermediate,
                    Thumbnail = "https://i.ytimg.com/vi/wc93gQRRKbA/mqdefault.jpg",
                    Title = "Tyrion's Trial in the Vale",
                    Url = "https://www.youtube.com/watch?v=wc93gQRRKbA"
                },
                new Video
                {
                    Id = 7,
                    Language = "en",
                    Level = (int) Enums.Level.Elementary,
                    Thumbnail = "https://i.ytimg.com/vi/DQYNM6SjD_o/mqdefault.jpg",
                    Title = "Miranda Lambert - The House That Built Me",
                    Url = "https://www.youtube.com/watch?v=DQYNM6SjD_o"
                },
                new Video
                {
                    Id = 8,
                    Language = "en",
                    Level = (int) Enums.Level.Intermediate,
                    Thumbnail = "https://i.ytimg.com/vi/HSzx-zryEgM/mqdefault.jpg",
                    Title = "Doctor Strange Official Trailer 2",
                    Url = "https://www.youtube.com/watch?v=HSzx-zryEgM"
                },
                new Video
                {
                    Id = 9,
                    Language = "en",
                    Level = (int) Enums.Level.Advanced,
                    Thumbnail = "https://i.ytimg.com/vi/-bN_xU5kbSs/mqdefault.jpg",
                    Title = "Guardians of the Galaxy Movie CLIP - Prison Break (2014) - Bradley Cooper Movie",
                    Url = "https://www.youtube.com/watch?v=-bN_xU5kbSs"
                }
            };
        }
    }
}