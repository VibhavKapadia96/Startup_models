using System;
using System.ComponentModel.DataAnnotations;

namespace Startup_models
{
    public class Sources
    {
        public int Id { get; set; }

        [Required]
        public string Source_Name { get; set; }
        public string status { get; set; } = "live";
        public DateTime insert_date { get; set; } = DateTime.Now;
        public string seo_keywords { get; set; }
    }
}
