using System;
using System.ComponentModel.DataAnnotations;

namespace Startup_models
{
    public class CategoriesData
    {
        public int Id { get; set; }
        [Required]
        public string Section_Title { get; set; }
        public string Section_HTML { get; set; }
        public int Section_Level { get; set; }
        public int categoriesId { get; set; }
        public Categories categories { get; set; }
    }
}
