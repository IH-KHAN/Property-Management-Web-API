using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inzamam_1291673.Models
{
    public class Property
    {
        public int PropertyId { get; set; }
        [Required, StringLength(70)]
        public string Title { get; set; } 
        [Required, Column(TypeName = "date")]
        public DateTime ListedDate { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal AskingPrice { get; set; }
        public bool IsRental { get; set; } 
        [StringLength(100)]
        public string Picture { get; set; }
        public ICollection<Feature> Features { get; set; } = new List<Feature>();
    }

    public class Feature
    {
        public int FeatureId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } 
        [Required, StringLength(50)]
        public string Description { get; set; } 
        [Required, ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
    public class PropertyDbContext: DbContext
    {
        public PropertyDbContext() : base("name=PropertyDbContext")
        {
        }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
   

}