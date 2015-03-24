namespace TSRD.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TSRD.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TSRD.Models.DefaultConnection>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TSRD.Models.DefaultConnection context)
        {
            //var units = new List<TSRD_Unit>
            //{
            //    new TSRD_Unit {Floor="B1",Area="A",IDString="B1A01",Name="�p�M�h",CreatedTime = DateTime.Now},
            //    new TSRD_Unit {Floor="1F",Area="A",IDString="F1A01+F2A01+F2A02",Name="Zara",CreatedTime = DateTime.Now},
            //    new TSRD_Unit {Floor="1F",Area="D",IDString="F1D01",Name="Massimo Dutti",CreatedTime = DateTime.Now},
            //    new TSRD_Unit {Floor="2F",Area="�ɩ|�W�~Team",IDString="2014000050",Name="�J�Y��",CreatedTime = DateTime.Now},
            //    new TSRD_Unit {Floor="3F",Area="E",IDString="F3E01",Name="La New",CreatedTime = DateTime.Now},
              
            //};
            //units.ForEach(s => context.TSRD_Unit.AddOrUpdate(p => p.IDString, s));
            //context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
