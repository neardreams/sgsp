using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TSRD.Enums;
using System.Web.Mvc;

namespace TSRD.Models
{
    [DisplayColumn("NO")]
    public class Property : TSRDModelBase
    {
        
        //public int Amount { get; set; }
        //public int PropertyTypeID { get; set; }
        //public int UnitID { get; set; }
        public string ListedName
        {
            get { return NO + " " + PropertyType.Name + " " +Name +" (" + SN + ")"; }
        }
        [Display(Name = "品名/型號")]
        [Required(ErrorMessage="請輸入型號名稱")]
        public string Name { get; set; }

        [Display(Name = "規格描述")]
        [DataType(DataType.MultilineText)]
        public string Specification { get; set; }

        [Display(Name = "序號")]
        public string SN { get; set; }

        [Display(Name = "財產編號")]
        public string NO { get; set; }

        [Display(Name = "MACAddress")]
        public string MACAddress { get; set; }

        [Display(Name = "報廢")]
        public bool Disabled { get; set; }

        [Display(Name = "財產類別")]
        public int PropertyTypeID { get; set; }

        [Display(Name = "財產類別")]
        public virtual PropertyType PropertyType { get; set; }

        [Display(Name = "單位")]
        public int? UnitID { get; set; }

        public virtual Unit Unit { get; set; }

        public virtual ICollection<WorkFormProperty> WorkFormProperties { get; set; }
        
        public virtual ICollection<RMAForm> RMAForms { get; set; }
        
        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }
    }
}