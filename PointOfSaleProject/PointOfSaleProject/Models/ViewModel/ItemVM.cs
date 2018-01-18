using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PointOfSaleProject.Models.EntityModels;

namespace PointOfSaleProject.Models.ViewModel
{
    public class ItemVM
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        [DisplayName("Cost Price")]
        public double CostPrice { get; set; }
        [DisplayName("Sale Price")]
        public double SalePrice { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public long ItemCategoryId { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }

        public List<Item> Items { get; set; }
        public IEnumerable<SelectListItem> SelectList { get; set; }
    }
}