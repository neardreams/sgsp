using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TSRD.Enums;
using System.Web.Mvc;

namespace TSRD.ViewModels
{
    public class ConsumableIOList :TSRD.Models.TSRDModelBase
    {
        [Display(Name="狀態")]
        public string Status { get; set; }

        [Display(Name = "數量")]
        public int Amount { get; set; }

        [Display(Name = "單位")]
        public string Unit { get; set; }
    }
}