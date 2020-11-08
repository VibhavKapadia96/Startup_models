using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Startup_models
{
    public class LinkRepository
    {
        public int Id { get; set; }

        [Required]
        public string link { get; set; }
        public string link_iframe { get; set; }
        public string link_description { get; set; }
        public string status { get; set; } = "live";
        public int vote { get; set; } = 0;
        public string seo_keywords { get; set; }
        public DateTime insert_date { get; set; } = DateTime.Now;
        public int categoriesId { get; set; }
        public Categories categories { get; set; }
        public int linkTypeId { get; set; }
        public LinkType linkType { get; set; }
        public int sourcesId { get; set; }
        public Sources sources { get; set; }
    }
}
