using MediaTagFixer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MediaTagFixer.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //แหนม รณเดช - อยากกอด.mp3
            string mediaFile = Path.Combine(Server.MapPath("~/App_Data")
                , "Sample.mp3");

            TagLib.File tagFile = TagLib.File.Create(mediaFile);

            var id3TagMeataData = new ID3TagMetaData();
            id3TagMeataData.Title = tagFile.Tag.Title;

            var isoEncoding = Encoding.GetEncoding("ISO-8859-1");
            var tisEncoding = Encoding.GetEncoding("TIS-620");
            var isoBytes = isoEncoding.GetBytes(tagFile.Tag.Title);

            char[] tisChars = new char[tisEncoding.GetCharCount(isoBytes, 0, isoBytes.Length)];
            tisEncoding.GetChars(isoBytes, 0, isoBytes.Length, tisChars, 0);
            id3TagMeataData.TitleAfterEncoded = new String(tisChars);

            return View(id3TagMeataData);
        }

    }
}
