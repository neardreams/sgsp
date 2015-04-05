using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TSRD.Enums;
using System.Web.Mvc;

namespace TSRD.Models
{
    public class PropertyForm : TSRDModelBase
    {
        [Display(Name = "財產")]
        public int PropertyID { get; set; }
        [Display(Name = "財產")]
        public Property Property { get; set; }


        //ID,Amount,ConsumableID,Description,Comment,CreatedTime,ModifiedTime
    }
}