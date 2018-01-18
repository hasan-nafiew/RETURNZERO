using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PointOfSaleProject.DAL;
using PointOfSaleProject.Models.ViewModel;

namespace PointOfSaleProject.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        ExpenseCategoryDAL expenseCategoryDa = new ExpenseCategoryDAL();
        ExpenseCategoryVM ModelVm = new ExpenseCategoryVM();

        // GET: ExpenseCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ModelVm.SelectList = expenseCategoryDa.GetExpenseCategorySelectList();
            ModelVm.Code = expenseCategoryDa.GetExpenseCategoryCode();
            return View(ModelVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseCategoryVM itemVm)
        {
            itemVm.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (expenseCategoryDa.IsExpenseCategorySaved(itemVm))
                {
                    return RedirectToAction("Index");
                }
            }

            ModelVm.SelectList = expenseCategoryDa.GetExpenseCategorySelectList();
            ModelVm.Code = expenseCategoryDa.GetExpenseCategoryCode();
            return View(ModelVm);
        }
    }
}