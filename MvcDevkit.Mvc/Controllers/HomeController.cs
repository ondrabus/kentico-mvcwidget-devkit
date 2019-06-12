using CMS.DocumentEngine;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;
using System.Linq;
using System.Web.Mvc;

namespace MvcDevkit.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var page = DocumentHelper.GetDocuments()
                  .Path("/Homepage")
                  .OnCurrentSite()
                  .TopN(1)
                  .FirstOrDefault();

            if (page == null)
            {
                return HttpNotFound();
            }

            HttpContext.Kentico().PageBuilder().Initialize(page.DocumentID);

            return View();
        }
    }
}