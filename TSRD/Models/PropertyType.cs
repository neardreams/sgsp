using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TSRD.Enums;
using System.Web.Mvc;

namespace TSRD.Models
{
    [DisplayColumn("ListedName")]
    public class PropertyType : TSRDModelBase
    {
        [Display(Name = "財產類別")]
        [Required(ErrorMessage = "請輸入財產類別")]
        public string Name { get; set; }

        [Display(Name = "報廢")]
        public bool Disabled { get; set; }

        //[Display(Name = "財產名稱")]
        //[Required(ErrorMessage = "請輸入財產名稱")]
        //public string Name { get; set; }

        public string ListedName
        {
            get { return Name; }
        }

        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}