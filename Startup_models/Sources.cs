using System.ComponentModel.DataAnnotations;

namespace Startup_models
{
    public class Sources
    {
        public int Id { get; set; }

        [Required]
        public string Source_Name { get; set; }
        public string status { get; set; } = "live";
    }
}
