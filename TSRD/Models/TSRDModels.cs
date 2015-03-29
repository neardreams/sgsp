using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using TSRD.Enums;
namespace TSRD.Models
{

    public class TSRDModels
    {
    }
    public class TSRDModelBaseMetadata
    {
        [ScaffoldColumn(false)]
        public object CreatedTime;
        
        [ScaffoldColumn(false)]        
        public object ModifiedTime;

    }
    //[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    //public class IsFilterColumnAttribute : Attribute
    //{
    //    public IsFilterColumnAttribute(bool isFilter);
    //    public bool IsFilter { get;}
    //}
    [MetadataType(typeof(TSRDModelBaseMetadata))]
    public class TSRDModelBase
    {                
        [Key]        
        public int ID { get; set; }
        
        [Display(Name = "描述")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "備註")]
        public string Comment { get; set; }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間")]
        [DisplayFormat(DataFormatString= "{0:yyyy/MM/dd HH:mm}",ApplyFormatInEditMode=true)]
        public DateTime CreatedTime { get; set; }

        
        [DataType(DataType.DateTime)]
        [Display(Name = "修改時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedTime { get; set; }

        //public int CreatorId { get; set; }        
        //public virtual ApplicationUser Creator { get; set; }
        
    }
    public class Unit :TSRDModelBase
    {        
        [Display(Name="名稱")]
        [Required(ErrorMessage = "請輸入名稱")]
        public string Name { get; set; }

        [Display(Name = "公司名稱")]        
        public string Company { get; set; }

        [Display(Name = "聯絡人")]
        public string Contact { get; set; }

        [Display(Name = "聯絡方式")]
        public string ContactInfo { get; set; }

        [Display(Name = "櫃號/員編")]
        [Required(ErrorMessage = "請輸入櫃號/員編")]
        public string IDString { get; set; }

        
        [Display(Name = "樓層")]
        [Required(ErrorMessage = "請輸入樓層")]
        public string Floor { get; set; }

        [Display(Name = "區域")]
        [Required(ErrorMessage = "請輸入區域")]
        public string Area { get; set; }

        [Display(Name = "已啟用")]
        public bool Enabled { get; set; }


        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }

        public virtual ICollection<WorkForm> WorkForms { get; set; }

        public virtual ICollection<Property> Properties { get; set; }

        public string ListedName
        {
            get
            {
                return Floor + " " + IDString + " " + Name;
            }
        }
        
        
    }
    
    public class WorkForm : TSRDModelBase
    {

        [Display(Name = "聯絡人")]
        public string Contact { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "進件時間")]
        public DateTime AcceptedTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "結案時間")]
        public DateTime? ClosedTime { get; set; }

        [Display(Name = "已結案")]
        public bool Closed { get; set; }

        [Display(Name = "案件類別")]
        public WorkFormType WorkFormType { get; set; }



        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }        

        [Display(Name = "單位")]
        public int UnitID { get; set; }
        
        public virtual Unit Unit { get; set; }

        //public virtual ICollection<WorkFormProperty> WorkFormProperties { get; set; }

        //public virtual ICollection<WorkFormConsumable> WorkFormConsumables { get; set; }

    }
       

    public class WorkFormProperty :TSRDModelBase
    {

        [Display(Name = "數量")]
        public int Amount { get; set; }

        //public int WorkFormID { get; set; }

        public int PropertyID { get; set; }

        //public virtual WorkForm WorkForm { get; set; }

        public virtual Property Property { get; set; }
        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }
    }
    public class WorkFormConsumable :TSRDModelBase
    {
        [Display(Name = "數量")]
        public int Amount { get; set; }

        //public int WorkFormID { get; set; }

        public int ConsumableID { get; set; }

        //public virtual WorkForm WorkForm { get; set; }        

        public virtual Consumable Consumable { get; set; }
        ////public int CreatorID { get; set; }
        //public int ModifierID { get; set; }
    }
    public class RMAFormMetadata
    {
        //public enum Statuses
        //{
        //    待送修, 已送修, 待報價, 待匯款, 待返件, 待取件, 已取件
        //}
        ////[IsFilterColumn(true)]
        //public Statuses Status;        
    }
    //[Bind(Include = "ID,Status, ListedName")]
    [MetadataType(typeof(RMAFormMetadata))]
    public class RMAForm :TSRDModelBase
    {
        public string ListedName
        {
            get { return Property.PropertyType.Name + " (" + Property.SN + ")"; }
        }

        [Display(Name = "RMA狀態")]
        public RMAFormStatus Status { get; set; }

        [Display(Name = "聯絡人")]
        public string Contact { get; set; }

        [Display(Name = "聯絡資訊")]
        public string ContactInfo { get; set; }

        [Display(Name = "送件時間")]
        public DateTime? RMATime { get; set; }

        [Display(Name = "返件時間")]
        public DateTime? ReturnTime { get; set; }

        [Display(Name = "已結案")]
        public bool Closed { get; set; }

        [Display(Name = "財產")]
        public int? PropertyID { get; set; }

        [Display(Name = "財產")]
        public virtual Property Property { get; set; }

        public int? ConsumableID { get; set; }

        public virtual Consumable Consumable { get; set; }

        //public int UnitID { get; set; }
        //public virtual Unit Unit { get; set; }        
        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }
    }
    
    public class PropertyType :TSRDModelBase
    {
        [Display(Name = "財產類別")]
        public string Type { get; set; }

        [Display(Name = "財產名稱")]
        public string Name { get; set; }

        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
    public class Property :TSRDModelBase
    {
        //public int Amount { get; set; }
        //public int PropertyTypeID { get; set; }
        //public int UnitID { get; set; }
        public string ListedName
        {
            get { return NO + " " + PropertyType.Name + " (" + SN + ")"; }
        }
        [Display(Name = "規格描述")]
        [DataType(DataType.MultilineText)]
        public string Specification { get; set; }

        [Display(Name = "序號")]
        public string SN { get; set; }

        [Display(Name = "財產編號")]
        public string NO { get; set; }

        [Display(Name = "MACAddress")]
        public string MACAddress { get; set; }

        public int? PropertyTypeID { get; set; }

        public virtual PropertyType PropertyType { get; set; }

        public int UnitID { get; set; }

        public virtual Unit Unit { get; set; }

        public virtual ICollection<WorkFormProperty> WorkFormProperties { get; set; }

        public virtual ICollection<RMAForm> RMAForms { get; set; }

        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }
    }
    public class Consumable :TSRDModelBase
    {
        public string ListedName
        {
            get { return NO + " " + Name + "(" + Amount + ")"; }
        }

        [Display(Name = "名稱")]
        public string Name { get; set; }

        [Display(Name = "耗材編號")]        
        public string NO { get; set; }

        [Display(Name = "數量")]
        public int Amount { get; set; }

        [Display(Name = "已啟用")]
        public bool Enabled { get; set; }


        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }                

        public virtual ICollection<WorkFormConsumable> WorkFormConsumables { get; set; }

        public virtual ICollection<RMAForm> RMAForms { get; set; }


        
    }
    public class ConsumableForm :TSRDModelBase
    {
        [Display(Name = "數量")]        
        public int Amount { get; set; }

        [Display(Name = "耗材名稱")]
        public int ConsumableID { get; set; }

        [Display(Name = "耗材")]
        public virtual Consumable Consumable { get; set; }

        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }                
        //public virtual ICollection<WorkFormConsumable> WorkFormConsumables { get; set; }
        //public virtual ICollection<RMAForm> RMAForms { get; set; }

    }
    public class DefaultConnection : DbContext
    {
        public DbSet<Unit> Unit { get; set; }
        public DbSet<RMAForm> RMAForm { get; set; }
        public DbSet<WorkForm> WorkForm { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyType> PropertyType { get; set; }        
        public DbSet<Consumable> Consumable { get; set; }        
        public DbSet<ConsumableForm> ConsumableForm { get; set; }
        public DbSet<WorkFormConsumable> WorkFormConsumable { get; set; }
        public DbSet<WorkFormProperty> WorkFormProperty { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Unit>()
            //    .HasMany(c => c.Properties).WithMany(i => i.Unit)
            //    .Map(t => t.MapLeftKey("CourseID")
            //        .MapRightKey("InstructorID")
            //        .ToTable("CourseInstructor"));

            //modelBuilder.Entity<Department>().MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);
        }
    }
}