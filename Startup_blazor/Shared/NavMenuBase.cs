using Microsoft.AspNetCore.Components;
using Startup_blazor.Services;
using Startup_models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_blazor.Shared
{
    public class NavMenuBase : ComponentBase
    {

        [Inject]
        public ICategoryService CategoryService { get; set; }
        public IEnumerable<Categories> Categories { get; set; }

        public string parent_child_data { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Categories = (await CategoryService.Getcategories()).ToList();

        }


    }



}
