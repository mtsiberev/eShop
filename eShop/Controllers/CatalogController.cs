using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Facade;
using ClassLibrary.IoC;
using ClassLibrary.Repository;
using NLog;

namespace eShop.Controllers
{
    public class CatalogController : Controller
    {
        private Facade m_facade = ContainerWrapper.Container.GetInstance<Facade>();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public JsonResult GetCatalog(int id)
        {
            var catalogBo = m_facade.GetCatalogById(id);
            if (catalogBo == null)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            var catalog = new
            {
                id = catalogBo.Id,
                name = catalogBo.Name
            };
            return Json(catalog, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCatalogs()
        {
            var catalogsListBo = m_facade.GetAllCatalogs();

            var catalogsList = (from catalog in catalogsListBo
                            select new { id = catalog.Id, name = catalog.Name }).ToList();

            return Json(catalogsList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCatalogsForOnePage(int pageNum, int pageSize, int parentId)
        {
            var catalogsListBo = m_facade.GetCatalogsForOnePage(pageNum, pageSize, parentId);

            var catalogsList = (from catalog in catalogsListBo
                            select new { id = catalog.Id, name = catalog.Name }).ToList();

            return Json(catalogsList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCountOfCatalogs(int parentId)
        {
            var catalogsCount = m_facade.GetAllCatalogs().Count();
            return Json(catalogsCount, JsonRequestBehavior.AllowGet);
        }


        [Authorize(Roles = "admin")]
        public JsonResult AddCatalog(string name)
        {
            var newCatalog = new Catalog(0, name);
            m_facade.AddCatalog(newCatalog);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "admin")]
        public JsonResult UpdateCatalog(int id, string name)
        {
            var updatedCatalog = new Catalog(id, name);
            m_facade.UpdateCatalog(updatedCatalog);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "admin")]
        public JsonResult DeleteCatalog(int id)
        {
            m_facade.DeleteCatalog(id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}
