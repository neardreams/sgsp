using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TSRD.Enums;
using System.Web.Mvc;

namespace TSRD.Models
{
    public class ConsumableForm : TSRDModelBase
    {
        [Display(Name="數量")]        
        public int Amount { get; set; }
        [Display(Name="耗材")]
        public int ConsumableID { get; set; }
        [Display(Name = "耗材")]
        public Consumable Consumable { get; set; }


        //ID,Amount,ConsumableID,Description,Comment,CreatedTime,ModifiedTime
    }
}