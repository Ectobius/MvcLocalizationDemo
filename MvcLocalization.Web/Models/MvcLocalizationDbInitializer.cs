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
            
            base.Seed(context);
        }
    }
}