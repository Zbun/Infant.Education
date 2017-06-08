using Infant.Education.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infant.Education.Controllers
{
    [AuthorizeType(NeedLogin = true)]
    public abstract class BaseController : Controller
    {

    }
}