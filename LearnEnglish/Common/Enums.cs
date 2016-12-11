using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnEnglish.Common
{
    public class Enums
    {
        public enum Level { Elementary = 1, PreIntermediate = 2, Intermediate = 3, UpperIntermediate = 4, Advanced = 5 };
    }
    public class Language
    {
        public const string English = "en";
        public const string Romanian = "ro";
        public const string Russian = "ru";
    }
}