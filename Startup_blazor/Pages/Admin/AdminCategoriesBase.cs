using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using Startup_models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Startup_blazor.Pages
{
    public class AdminCategoriesBase : ComponentBase
    {
        [Parameter]
        public string name { get; set; }

        [Parameter]
        public string id { get; set; }

        [Inject] protected IWebHostEnvironment _environment { get; set; }
      

        public IFileListEntry Image;
        public Categories categories { get; set; } = new Categories();
        public List<Categories> category_list { get; set; } = new List<Categories>();
        public IEnumerable<Categories> category { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await Task.Run(categoriesdata);
        }

        private void categoriesdata() {


            Categories c = new Categories();
            c.Category_Name = "GRE";
            c.Category_Parent = "";
            c.Parent_Id = 0;
            c.status = "live";
            c.topParentMapper = "";
            c.Id = 1;
            category_list.Add(c);

            c = new Categories();
            c.Category_Name = "GMATE";
            c.Category_Parent = "";
            c.Parent_Id = 0;
            c.status = "live";
            c.topParentMapper = "";
            c.Id = 2;
            category_list.Add(c);
            category = category_list.ToList();
        }
        protected async Task AddCategory()
        {
            //call post api categories
      
            if (Image != null) { 
            var path = Path.Combine(_environment.WebRootPath, "img", Image.Name);
            await using var stream = new FileStream(path, FileMode.Create);
            await Image.Data.CopyToAsync(stream);
            }
           
        }

      
        protected async Task HandleSelection(IFileListEntry[] files)
        {
            var file = files.FirstOrDefault();
            if (file != null)
            {
                //// Just load into .NET memory to show it can be done
                //// Alternatively it could be saved to disk, or parsed in memory, or similar
                //var ms = new MemoryStream();
                //await file.Data.CopyToAsync(ms);
                ////status = $"Finished loading {file.Size} bytes from {file.Name}";
                //Image = file;
                //Console.WriteLine("OnValidSubmit");
            }
        }

    }
}
