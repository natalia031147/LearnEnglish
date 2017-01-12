﻿using System.Collections.Generic;
using LearnEnglish.Business.Models;

namespace LearnEnglish.Business.Logic.Interfaces
{
    public interface IVideoLogic
    {
        ICollection<VideoModel> GetAll();
        VideoModel Get(int id);
    }
}