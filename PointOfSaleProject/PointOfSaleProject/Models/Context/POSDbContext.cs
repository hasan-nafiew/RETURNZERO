using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PointOfSaleProject.Models.EntityModels;

namespace PointOfSaleProject.Models.Context
{
    public class POSDbContext:DbContext
    {
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ExpenseItem> ExpenseItems { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Organization> Organizations { get; set; }

    }
}