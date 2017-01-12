using System.Threading;
using LearnEnglish.Data.Framework;
using Microsoft.AspNet.Identity;

namespace LearnEnglish.Business.Logic
{
    public abstract class BaseLogic
    {
        protected ApplicationDbContext Context;

        protected BaseLogic(ApplicationDbContext context)
        {
            Context = context;
        }

        protected string GetUser()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}