using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using NLog;
using WebMatrix.WebData;

namespace eShop.Helpers
{
    public static class ImageObject
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private const string c_folderName = "~/Content/";
        private const string c_defaultImgName = "orange.jpg";
        private const string c_defaultContentType = "application/.jpg";
        

        public static void SaveImage(HttpPostedFileBase file, int id)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    var extension = Path.GetExtension(file.FileName);
                    var fileName = string.Concat(id.ToString(), extension);
                    var filePathName = Path.Combine(HostingEnvironment.MapPath(c_folderName), fileName);

                    file.SaveAs(filePathName);
                    logger.Info("Saving file: '{0}' by user '{1}'", filePathName, WebSecurity.CurrentUserName);
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    throw;
                }
            else
            {
                logger.Info("You have not specified a file");
            }
        }

        public static void DeleteImage(int id)
        {
            try
            {
                var file = GetFileInfoById(id);
                var fileName = file.Name;
                file.Delete();
                logger.Info("Image file : '{0}' was removed by user '{1}'", fileName, WebSecurity.CurrentUserName);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        public static FilePathResult GetImage(int id)
        {
            try
            {
                var file = GetFileInfoById(id);
                var fileName = file.Name;
                var filePath = string.Concat(c_folderName, fileName);
                string contentType = string.Concat("application/", file.Extension);

                return new FilePathResult(filePath, contentType);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            var filepath = string.Concat(c_folderName, c_defaultImgName);

            return new FilePathResult(filepath, c_defaultContentType);
        }
        

        public static string GetLinkById(int id)
        {
            var fileDescription = GetFileInfoById(id);
            if (fileDescription == null)
                return "/Content/orange.jpg";

            return  String.Format("/Content/{0}", fileDescription.Name);
        }
        
        
        private static FileInfo GetFileInfoById(int id)
        {
            try
            {
                var dir = new DirectoryInfo(HostingEnvironment.MapPath(c_folderName));
                var files = dir.GetFiles(String.Format("*{0}*", id));
                var file = files.First(x => Path.GetFileNameWithoutExtension(x.Name) == id.ToString());

                return file;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public static bool IsImageForUserExists(int id)
        {
            bool result;
            try
            {
                GetFileInfoById(id);
                result = true;
            }
            catch (Exception ex)
            {
                logger.Warn(ex.Message);
                result = false;
            }
            return result;
        }
    }
}