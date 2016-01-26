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
    public class ProductImageDescription
    {
        public string FileLink { get; private set; }
        public bool IsDefaultImage { get; private set; }

        public ProductImageDescription(string fileLink, bool isDefault)
        {
            FileLink = fileLink;
            IsDefaultImage = isDefault;
        }
    }

    
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
        

        public static ProductImageDescription GetImageLinkById(int id)
        {
            var fileDescription = GetFileInfoById(id);
            if (fileDescription == null)
            {
                return new ProductImageDescription("/Content/orange.jpg", true);
            }
         
            return new ProductImageDescription(String.Format("/Content/{0}", fileDescription.Name), false);
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
    }
}