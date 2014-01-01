using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bquiz.Display.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult Save(IEnumerable<HttpPostedFileBase> attachments)
        {
            List<string> photos = (List<string>)Session["photos-upload"];

            // The Name of the Upload component is "attachments" 
            foreach (var file in attachments)
            {
                // Some browsers send file names with full path. This needs to be stripped.
                var fileName = Path.GetFileName(file.FileName);
                var serverName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var physicalPath = Path.Combine(Server.MapPath("~/Bquiz_Data/Images"), serverName);

                // The files are not actually saved in this demo
                file.SaveAs(physicalPath);

                photos.Add(serverName);
            }
            Session["photos-upload"] = photos;

            // Return an empty string to signify success
            return Content("");
        }

    }
}
