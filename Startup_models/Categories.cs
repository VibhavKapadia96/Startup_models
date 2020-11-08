using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Startup_models
{
    public class Categories
    {
        public int Id { get; set; }
        [Required]
        public string Category_Name { get; set; }
        public string Category_Parent { get; set; }
        public int Parent_Id { get; set; } = 0;
        public string status { get; set; } = "live";
        public string topParentMapper { get; set; }
        public string seo_keywords { get; set; }
        public DateTime insert_date { get; set; } = DateTime.Now;
       
        public string category_image_path { get; set; }
    }
}
