using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PointOfSaleProject.Models.ViewModel;
using PointOfSaleProject.Models.EntityModels;
using PointOfSaleProject.Models.Context;
namespace PointOfSaleProject.DAL
{
    public class ItemCategoryDAL
    {
        POSDbContext dbContext=new POSDbContext();

        public IEnumerable<SelectListItem> GetItemCategorySelectList()
        {
            var list = dbContext.ItemCategories.Where(x => x.ItemParentsID == null).ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Name, Value = li.Id.ToString() }));

            return selectList;
        }
        public List<ItemCategory> GetItemCategoryList()
        {
            var list = dbContext.ItemCategories.ToList();
            return list;
        }
        public string GetItemCategoryCode()
        {
            long code;

            if (dbContext.ItemCategories.ToList().Count > 0)
            {
                code = Convert.ToInt64(dbContext.ItemCategories.Select(x => x.Code).Max());
            }
            else
            {
                code = 0;
            }

            return string.Format("{0:000}", (code + 1));
        }
        public bool IsItemCategorySaved(ItemCategoryVM itemVm)
        {
            ItemCategory item = new ItemCategory()
            {
                Name = itemVm.Name,
                Code = itemVm.Code,
                Description = itemVm.Description,
                Image = itemVm.Image,
                Date = itemVm.Date,
                ItemParentsID = itemVm.ItemParentsID
            };

            dbContext.ItemCategories.Add(item);
            var isAdded = dbContext.SaveChanges()>0;

            if (isAdded)
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
