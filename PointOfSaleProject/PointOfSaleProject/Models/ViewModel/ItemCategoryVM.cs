using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PointOfSaleProject.Models.EntityModels;

namespace PointOfSaleProject.Models.ViewModel
{
    public class ItemCategoryVM
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public string Description { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }

        [DisplayName("Item Parent Category")]
        public long? ItemParentsID { get; set; }
        public virtual ItemCategory ItemParents { get; set; }

        public List<ItemCategory> Childs { get; set; }
        public IEnumerable<SelectListItem> SelectList { get; set; }
    }
}