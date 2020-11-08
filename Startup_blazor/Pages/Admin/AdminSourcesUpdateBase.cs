using Microsoft.AspNetCore.Components;
using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_blazor.Pages.Admin
{
    public class AdminSourcesUpdateBase :ComponentBase
    {

        [Parameter]
        public string name { get; set; }

        [Parameter]
        public string id { get; set; }

        public Sources sources { get; set; } = new Sources();

        public List<Sources> source_list { get; set; } = new List<Sources>();
        public IEnumerable<Sources> sources_enum { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await Task.Run(sourcesData);

            if (name != null && id != null) {

                sources.Source_Name = "Youtube";
                
            }

        }

        private void sourcesData() {


            Sources s = new Sources();
            s.Source_Name = "Youtube";
            s.Id = 1;
            source_list.Add(s);

            s = new Sources();
            s.Source_Name = "Youtube1";
            s.Id = 2;
            source_list.Add(s);
            sources_enum = source_list.ToList();


        }




        protected async Task updateResources()
        {
            //call post api categories
        }
    }
}
