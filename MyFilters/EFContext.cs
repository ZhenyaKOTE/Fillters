namespace MyFilters
{
    using MyFilters.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EFContext : DbContext
    {

        public EFContext()
            : base("name=ConectionDefault")
        {
        }
        public virtual DbSet<FilterValue> FilterValues { get; set; }
        public virtual DbSet<FilterName> FilterNames { get; set; }
        public virtual DbSet<FilterNameGroup> FilterNameGroups { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Filter> Filters { get; set; }
    }


}