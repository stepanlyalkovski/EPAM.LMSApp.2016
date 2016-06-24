using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MvcPL.Infrastructure
{
    public static class FileStorageHepler
    {
        public static string SaveFileToDisk(HttpPostedFileBase img, string path)
        {
            var r = new Random();

            Directory.CreateDirectory(path);
            var ext = "." + img.FileName.Split('.').Last();
            var name = r.Next(1000000, Int32.MaxValue) +
                       r.Next(1000000, Int32.MaxValue).ToString() + ext;
            var fName = path + name;
            img.SaveAs(fName);
            return name;
        }

    }
}