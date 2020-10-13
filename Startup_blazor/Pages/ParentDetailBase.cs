using Microsoft.AspNetCore.Components;
using Startup_blazor.Services;
using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_blazor.Pages
{
    public class ParentDetailBase :ComponentBase
    {
        public IEnumerable<Categories> category { get; set; }

        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Parameter]
        public string name { get; set; }

        [Parameter]
        public string id { get; set; }

        protected override async Task OnInitializedAsync()
        {
           category = (await CategoryService.GetcategoryDetails(name)).ToList();
        }
    }
}
