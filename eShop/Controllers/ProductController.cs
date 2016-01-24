﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Facade;
using ClassLibrary.IoC;
using ClassLibrary.Repository;
using eShop.Helpers;
using NLog;

namespace eShop.Controllers
{
    public class ProductController : Controller
    {
        private Facade m_facade = ContainerWrapper.Container.GetInstance<Facade>();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public JsonResult GetProduct(int id)
        {
            var productBo = m_facade.GetProductById(id);
            if (productBo == null)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            var product = new
            {
                id = productBo.Id,
                catalogId = productBo.CatalogId,
                name = productBo.Name,
                description = productBo.Description,
                fileLink = ImageObject.GetLinkById(productBo.Id)
            };
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult GetProductsFromCatalog(int id)
        {
            var productsListBo = m_facade.GetProductsFromCatalog(id);

            if (productsListBo == null)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            var anonArray = new List<dynamic>();
            foreach (var productBo in productsListBo)
            {
                anonArray.Add(
                    new { id = productBo.Id, catalogId = productBo.CatalogId, name = productBo.Name, description = productBo.Description, fileLink = ImageObject.GetLinkById(productBo.Id) });
            }
            return Json(anonArray, JsonRequestBehavior.AllowGet);
        }
        

        public JsonResult GetAllProducts()
        {
            var productsListBo = m_facade.GetAllProducts();
            if (productsListBo == null)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            var anonArray = new List<dynamic>();
            foreach (var productBo in productsListBo)
            {
                anonArray.Add(
                    new { id = productBo.Id, catalogId = productBo.CatalogId, name = productBo.Name, description = productBo.Description,  fileLink = ImageObject.GetLinkById( productBo.Id) });
            }
            return Json(anonArray, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "admin")]
        public JsonResult AddProduct(int catalogId, string name, string description)
        {
            var newProduct = new Product(0, catalogId, name, description);
            m_facade.AddProduct(newProduct);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "admin")]
        public JsonResult UpdateProduct(int id, int catalogId, string name, string description)
        {
            var updatedProduct = new Product(id, catalogId, name, description);
            m_facade.UpdateProduct(updatedProduct);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "admin")]
        public JsonResult DeleteProduct(int id)
        {
            m_facade.DeleteProduct(id);
            ImageObject.DeleteImage(id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        
        [HttpPost]
        public JsonResult UploadFile(HttpPostedFileBase file, int id)
        {
            ImageObject.SaveImage(file, id);
            var fileLink = ImageObject.GetLinkById(id);
            return Json(fileLink, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFileInfoById(int id)
        {
            var fileLink = ImageObject.GetLinkById(id);
            return Json(fileLink, JsonRequestBehavior.AllowGet);
        }
        

        public JsonResult DeleteFile(int id)
        {
            ImageObject.DeleteImage(id);
            var fileLink = ImageObject.GetLinkById(0);
            return Json(fileLink, JsonRequestBehavior.AllowGet);
        }

    }

}
