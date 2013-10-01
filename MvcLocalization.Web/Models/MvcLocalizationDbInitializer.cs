using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcLocalization.Web.Models
{
    public class MvcLocalizationDbInitializer : DropCreateDatabaseAlways<MvcLocalizationContext>
    {
        protected override void Seed(MvcLocalizationContext context)
        {
            var item1 = new Item
                {
                    Id = 1,
                    Name = "Item1",
                    Price = 9.99m,
                    ProducedAt = new DateTime(2012, 5, 17),
                    Weight = 15.4
                };
            context.Items.Add(item1);

            var item2 = new Item
                {
                    Id = 2,
                    Name = "Item2",
                    Price = 89.99m,
                    ProducedAt = new DateTime(2013, 2, 11),
                    Weight = 0.2
                };
            context.Items.Add(item2);
            
            base.Seed(context);
        }
    }
}