using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using PointOfSaleProject.Models.Context;
using PointOfSaleProject.Models.EntityModels;
using PointOfSaleProject.Models.ViewModel;

namespace PointOfSaleProject.DAL
{
    public class ItemDAL
    {
        POSDbContext dbContext=new POSDbContext();

        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            var list = dbContext.ItemCategories.Select(x => x).Distinct().ToList();
            var selectList=new List<SelectListItem>()
            {
                new SelectListItem{Text="---Select---",Value = "",Selected = true }
            };
            selectList.AddRange(list.Select(li=>new SelectListItem{Text=li.Name, Value = li.Id.ToString()}));
            return selectList;
        }

        public List<Item> GetItemList()
        {
            var list = dbContext.Items.ToList();
            return list;
        }

        public string GetItemCode()
        {

            
            long code;
            if (dbContext.Items.ToList().Count>0)
            {
                code = Convert.ToInt64(dbContext.Items.Select(x => x.Id).Max());
            }
            else
            {
                code = 0;
            }

            return string.Format("{0:00000}", (code + 1));
        }

        public bool IsItemSaved(ItemVM itemVm)
        {
            Item item=new Item()
            {
                Name = itemVm.Name,
                Code = itemVm.Code,
                Description = itemVm.Description,
                Image = itemVm.Image,
                Date=itemVm.Date,
                ItemCategoryId=itemVm.ItemCategoryId,
                CostPrice = itemVm.CostPrice,
                SalePrice = itemVm.SalePrice
            };
            dbContext.Items.Add(item);
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