using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PointOfSaleProject.DAL;
using PointOfSaleProject.Models.ViewModel;

namespace PointOfSaleProject.Controllers
{
    public class OrganizationController : Controller
    {
        OrganizationVM ModelVm = new OrganizationVM();
        OrganizationDAL organizationDa = new OrganizationDAL();
        Image imageData = new Image();

        // GET: Organization
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ModelVm.Code = organizationDa.GetOrganizationCode();
            return View(ModelVm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizationVM itemVm, HttpPostedFileBase imageFile)
        {
            itemVm.Date = DateTime.Now;
            itemVm.Image = imageData.ImageConvertToByte(imageFile);
            if (ModelState.IsValid)
            {
                if (organizationDa.IsOrganizationSaved(itemVm))
                {
                    return RedirectToAction("Create");
                }
            }

            ModelVm.Code = organizationDa.GetOrganizationCode();
            return View(ModelVm);
        }

    }
}