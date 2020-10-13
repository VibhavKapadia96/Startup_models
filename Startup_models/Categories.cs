using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
    }
}
