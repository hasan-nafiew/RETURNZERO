using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PointOfSaleProject.Models.EntityModels
{
    public class ItemCategory
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }   
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }

        public long? ItemParentsID { get; set; }
        public virtual ItemCategory ItemParents { get; set; }
    }
}