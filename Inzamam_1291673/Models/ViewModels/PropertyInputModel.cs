using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inzamam_1291673.Models.ViewModels
{
    public class PropertyInputModel
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
        public List<FeatureInputModel> Features { get; set; }= new List<FeatureInputModel>();
    }
}