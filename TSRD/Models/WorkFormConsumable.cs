using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TSRD.Enums;
using System.Web.Mvc;

namespace TSRD.Models
{
    public class WorkFormConsumable : TSRDModelBase
    {
        public int WorkFormID { get; set; }
        public virtual WorkForm WorkForm { get; set; }
        public int ConsumableID { get; set; }
        public virtual Consumable Consumable { get; set; }
        [Display(Name="數量")]
        public int Amount { get; set; }
    }
}