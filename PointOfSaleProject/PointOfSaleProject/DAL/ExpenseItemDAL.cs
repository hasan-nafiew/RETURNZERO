using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PointOfSaleProject.Models.Context;
using PointOfSaleProject.Models.EntityModels;
using PointOfSaleProject.Models.ViewModel;

namespace PointOfSaleProject.DAL
{
    public class ExpenseItemDAL
    {
        POSDbContext dbContext = new POSDbContext();
        public IEnumerable<SelectListItem> GetExpenseItemSelectList()
        {
            var list = dbContext.ExpenseCategories.Select(x => x).Distinct().ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Name, Value = li.Id.ToString() }));

            return selectList;
        }
        public List<ExpenseItem> GetExpenseItemList()
        {
            var list = dbContext.ExpenseItems.ToList();
            return list;
        }

        public string GetExpenseItemCode()
        {
            long code;

            if (dbContext.ExpenseItems.ToList().Count > 0)
            {
                code = Convert.ToInt64(dbContext.ExpenseItems.Select(x => x.Code).Max());
            }
            else
            {
                code = 0;
            }

            return string.Format("{0:00000}", (code + 1));
        }

        public bool IsExpenseItemSaved(ExpenseItemVM itemVm)
        {
            ExpenseItem item = new ExpenseItem()
            {
                Name = itemVm.Name,
                Code = itemVm.Code,
                Description = itemVm.Description,
                Date = itemVm.Date,
                CategoryId = itemVm.CategoryId
            };

            dbContext.ExpenseItems.Add(item);
            var isAdded = dbContext.SaveChanges();

            if (isAdded > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
