using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcLocalization.Web.Models
{
    public class MvcLocalizationContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
    }
}