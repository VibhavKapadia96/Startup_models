using Microsoft.AspNetCore.Components;
using Startup_models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Startup_blazor.Shared
{

    public class TopNavBase : ComponentBase
    {
        public List<Categories> category_list { get; set; } = new List<Categories>();
        public IEnumerable<Categories> category { get; set; }
        protected override async Task OnInitializedAsync()
        {
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

                c = new Categories();
                c.Category_Name = "Quant";
                c.Category_Parent = "";
                c.Parent_Id = 1;
                c.status = "live";
                c.topParentMapper = "";
                c.Id = 3;
                category_list.Add(c);

                c = new Categories();
                c.Category_Name = "Verbal";
                c.Category_Parent = "";
                c.Parent_Id = 1;
                c.status = "live";
                c.topParentMapper = "";
                c.Id = 4;
                category_list.Add(c);


            c = new Categories();
            c.Category_Name = "Algebra";
            c.Category_Parent = "";
            c.Parent_Id = 3;
            c.status = "live";
            c.topParentMapper = "";
            c.Id = 5;
            category_list.Add(c);

            c = new Categories();
            c.Category_Name = "Geometry";
            c.Category_Parent = "";
            c.Parent_Id = 3;
            c.status = "live";
            c.topParentMapper = "";
            c.Id = 6;
            category_list.Add(c);

            c = new Categories();
            c.Category_Name = "Profit and Loss";
            c.Category_Parent = "";
            c.Parent_Id = 5;
            c.status = "live";
            c.topParentMapper = "";
            c.Id = 7;
            category_list.Add(c);


            category = category_list.ToList();
           

        }

    }
}
