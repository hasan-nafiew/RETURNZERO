using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PointOfSaleProject.DAL;
using PointOfSaleProject.Models.EntityModels;
using PointOfSaleProject.Models.ViewModel;

namespace PointOfSaleProject.Controllers
{
    public class ItemCategoryController : Controller
    {
        ItemCategoryDAL itemCategoryDa = new ItemCategoryDAL();
        ItemCategoryVM ModelVm = new ItemCategoryVM();
        Image imageData = new Image();

        // GET: ItemCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ModelVm.SelectList = itemCategoryDa.GetItemCategorySelectList();
            ModelVm.Code = itemCategoryDa.GetItemCategoryCode();
            return View(ModelVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemCategoryVM itemCategory, HttpPostedFileBase file)
        {

            itemCategory.Date = DateTime.Now;
            itemCategory.Image = imageData.ImageConvertToByte(file);
            if (ModelState.IsValid)
            {
                if (itemCategoryDa.IsItemCategorySaved(itemCategory))
                {
                    return RedirectToAction("Index");
                }
            }

            ModelVm.SelectList = itemCategoryDa.GetItemCategorySelectList();
            ModelVm.Code = itemCategoryDa.GetItemCategoryCode();
            return View(ModelVm);
        }
    }
}