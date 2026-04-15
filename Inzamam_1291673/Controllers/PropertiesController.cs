using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Hosting;
using Inzamam_1291673.Models;
using Inzamam_1291673.Models.ViewModels;

namespace Inzamam_1291673.Controllers
{
    public class PropertiesController : ApiController
    {
        private PropertyDbContext db = new PropertyDbContext();

        [HttpGet]
        public IQueryable<Property> GetProperties()
        {
            return db.Properties.Include(x => x.Features).AsQueryable();
        }

        [HttpGet]
        public IHttpActionResult GetProperty(int id)
        {
            var p = db.Properties.Include(x => x.Features).FirstOrDefault(x => x.PropertyId == id);
            if (p != null)
                return Ok(p);
            else
                return NotFound();
        }

        [Route("Image/Upload")]
        [HttpPost]
        public IHttpActionResult Upload()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
           
                string f = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;

          
                string savePath = Path.Combine(HostingEnvironment.MapPath("~/Images"), f);

                file.SaveAs(savePath);

             
                return Ok(f);
            }
            return BadRequest();
        }

       
        [HttpPost]
        public IHttpActionResult PostProperty(PropertyInputModel model)
        {
            if (ModelState.IsValid)
            {
                var property = new Property
                {
                    Title = model.Title,
                    ListedDate = model.ListedDate,
                    AskingPrice = model.AskingPrice,
                    IsRental = model.IsRental,
                    Picture = model.Picture
                };

                // Add Child Features
                model.Features.ForEach(f =>
                {
                    property.Features.Add(new Feature
                    {
                        Name = f.Name,
                        Description = f.Description
                    });
                });

                db.Properties.Add(property);
                db.SaveChanges();

                return Ok(property);
            }
            return BadRequest("Data Invalid!!!");
        }

        // 3. UPDATE DATA
        [HttpPut]
        public IHttpActionResult PutProperty(int id, PropertyInputModel model)
        {
            if (id != model.PropertyId) return BadRequest("Id mismatch!!");

            if (ModelState.IsValid)
            {
                var property = db.Properties.Include(x => x.Features).FirstOrDefault(x => x.PropertyId == id);

                if (property == null) return NotFound();

                // Update Master Data
                property.Title = model.Title;
                property.ListedDate = model.ListedDate;
                property.AskingPrice = model.AskingPrice;
                property.IsRental = model.IsRental;
                property.Picture = model.Picture;

                // Update Child Data (Delete old specs, add new ones)
                db.Features.RemoveRange(property.Features);

                model.Features.ForEach(f =>
                {
                    property.Features.Add(new Feature
                    {
                        Name = f.Name,
                        Description = f.Description,
                        PropertyId = id // Link explicitly
                    });
                });

                db.SaveChanges();
                return Ok(property);
            }
            return BadRequest("Data Invalid!");
        }

        [HttpDelete]
        public IHttpActionResult DeleteProperty(int id)
        {
            var property = db.Properties.FirstOrDefault(x => x.PropertyId == id);
            if (property == null) return NotFound();

            // Note: If you don't have Cascade Delete enabled in SQL, 
            // you might need to manually delete Features here:
            // db.Features.RemoveRange(db.Features.Where(f => f.PropertyId == id));

            db.Properties.Remove(property);
            db.SaveChanges();
            return Ok("Data Deleted.");
        }
    }
}