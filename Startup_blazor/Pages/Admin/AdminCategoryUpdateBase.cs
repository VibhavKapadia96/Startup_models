using Microsoft.AspNetCore.Components;
using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_blazor.Pages.Admin
{


    public class AdminCategoryUpdateBase : ComponentBase
    {
        [Parameter]
        public string name { get; set; }

        [Parameter]
        public string id { get; set; }
        
        public Categories categories { get; set; } = new Categories();
        public Categories categoriesChild { get; set; } = new Categories();

        protected async override Task OnInitializedAsync()
        {
           
        }

        protected async Task updateCategory()
        {
            //call post api categories
        }
        protected async Task addChild()
        {
            //call post api categories
        }
    }
}
