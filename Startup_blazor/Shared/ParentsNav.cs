using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Startup_blazor.Services;
using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup_blazor.Shared
{
    public class ParentsNav : ComponentBase
    {

        [Inject]
        public ICategoryService CategoryService { get; set; }
        public IEnumerable<Categories> Categories { get; set; }

        protected override async Task OnInitializedAsync()
        {
             Categories = (await CategoryService.Getcategories()).ToList();
        }



    }



}
