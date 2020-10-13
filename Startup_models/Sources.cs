using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Startup_models
{
    public class Sources
    {
        public int Id { get; set; }

        [Required]
        public string Sourece_Name { get; set; }
        public string status { get; set; } = "live";
    }
}
