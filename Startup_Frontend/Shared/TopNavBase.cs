using Microsoft.AspNetCore.Components;
using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_Frontend.Shared
{

    public class TopNavBase : ComponentBase
    {
        public List<Categories> Categories { get; set; }
        protected override async Task OnInitializedAsync()
        {

            for (int i = 0; i < 10; i++) {

                Categories c = new Categories();
                c.Category_Name = "GRE";
                c.Category_Parent = "";
                c.Parent_Id = i;
                c.status = "live";
                c.topParentMapper = "";

                Categories.Add(c);

            }

            Categories.ToList();
           

        }

    }
}
