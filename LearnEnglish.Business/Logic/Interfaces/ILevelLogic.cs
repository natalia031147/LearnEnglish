using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.Business.Logic.Interfaces
{
    public interface ILevelLogic
    {
        int GetUserLevel();
        string ChangeUserLevel(int level);
    }
}
