using System;
using System.ComponentModel.DataAnnotations;

namespace Startup_models
{
    public class linkRepository
    {

        public int Id { get; set; }

        [Required]
        public string link { get; set; }
        public string link_iframe { get; set; }
        public string link_description { get; set; }
        public string status { get; set; } = "live";
        public int vote { get; set; } = 0;

        public DateTime insert_date { get; set; } = DateTime.Now;

        [Required]
        public int categoryId { get; set; }
        [Required]
        public int linkTypeId { get; set; }
        [Required]
        public int sourcesId { get; set; }

    }
}
