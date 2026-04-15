using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Inzamam_1291673.Models; 

namespace Inzamam_1291673.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Inzamam_1291673.Models.PropertyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Inzamam_1291673.Models.PropertyDbContext context)
        {
            var properties = new List<Inzamam_1291673.Models.Property>
    {
        new Inzamam_1291673.Models.Property
        {
            Title = "Modern Downtown Apartment",
            ListedDate = DateTime.Parse("2025-10-05"),
            AskingPrice = 450000.00m,  
            IsRental = true,           
            Picture = "apt_downtown_01.jpg",
            Features = new List<Inzamam_1291673.Models.Feature>
            {
                new Inzamam_1291673.Models.Feature { Name = "Bedrooms", Description = "2" }, 
                new Inzamam_1291673.Models.Feature { Name = "Bathrooms", Description = "2" },
                new Inzamam_1291673.Models.Feature { Name = "Square Footage", Description = "1200 sqft" }
            }
        },
        new Inzamam_1291673.Models.Property
        {
            Title = "Cozy Suburban Cottage",
            ListedDate = DateTime.Parse("2025-09-12"),
            AskingPrice = 320000.00m,
            IsRental = false,
            Picture = "cottage_suburb_02.jpg",
            Features = new List<Inzamam_1291673.Models.Feature>
            {
                new Inzamam_1291673.Models.Feature { Name = "Bedrooms", Description = "3" },
                new Inzamam_1291673.Models.Feature { Name = "Garage", Description = "1-Car Detached" }
            }
        }
    };

            context.Properties.AddOrUpdate(p => p.Title, properties.ToArray());
            context.SaveChanges();
        }
    }
}