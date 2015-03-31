using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TSRD.Enums;
using System.Web.Mvc;

namespace TSRD.Models
{
    public class WorkFormProperty : TSRDModelBase
    {
        public int WorkFormID { get; set; }
        public virtual WorkForm WorkForm { get; set; }
        public int PropertyID { get; set; }
        public virtual Property Property { get; set; }     
        public string PropertyListedName
        {
            get
            {
                return Property.ListedName;        
            }
        }
    }
}