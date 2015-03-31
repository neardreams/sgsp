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
        public TSRDModelBase()
        {
            this.CreatedTime = DateTime.Now;
        }
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
        public DateTime? CreatedTime { get; set; }

        
        [DataType(DataType.DateTime)]
        [Display(Name = "修改時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedTime { get; set; }

        //public int CreatorId { get; set; }        
        //public virtual ApplicationUser Creator { get; set; }
        
    }


    public class Test
    {
        [Key]
        public int ID { get; set; }
        public int Amount { get; set; }
        public int ID1 { get; set; }
        public int ID2 { get; set; }
        public int ID3 { get; set; }
    }
       

    //public class WorkFormProperty :TSRDModelBase
    //{

    //    [Display(Name = "數量")]
    //    public int Amount { get; set; }

    //    [Display(Name="派工單")]
    //    public int WorkFormID { get; set; }

    //    [Display(Name = "財產")]
    //    public int? PropertyID { get; set; }

    //    public virtual WorkForm WorkForm { get; set; }

    //    public virtual Property Property { get; set; }
    //    //public int CreatorID { get; set; }
    //    //public int ModifierID { get; set; }
    //}
    //public class WorkFormConsumable :TSRDModelBase
    //{
    //    [Display(Name = "數量")]
    //    public int Amount { get; set; }

    //    //public int WorkFormID { get; set; }

    //    public int ConsumableID { get; set; }

    //    //public virtual WorkForm WorkForm { get; set; }        

    //    public virtual Consumable Consumable { get; set; }
    //    ////public int CreatorID { get; set; }
    //    //public int ModifierID { get; set; }
    //}

    //[Bind(Include = "ID,Status, ListedName")]
    

  
  
    //public class WorkFormProperties :TSRDBaseModel
    //{
    //    public int Amount { get; set; }
    //}
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
        public DbSet<Test> Test { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {                    
            
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<WorkForm>()
            //    .HasMany(c => c.Properties).WithMany(i => i.WorkForms)
            //    .Map(t => t.MapLeftKey("PropertyID").MapRightKey("ID").ToTable("WorkFormProperties"))
            //    ;

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