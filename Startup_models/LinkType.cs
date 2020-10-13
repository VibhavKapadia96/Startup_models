using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Startup_models
{
   public class LinkType
    {

        public int Id { get; set; }

        [Required]
        public string Linktype_Name { get; set; }
        public string status { get; set; } = "live";

    }
}
