using Microsoft.AspNetCore.Components;
using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_Frontend.Pages
{
    public class CategoryBase : ComponentBase
    {

        [Parameter]
        public string name { get; set; }

        [Parameter]
        public string id { get; set; }

        List<LinkType> all_Types = new List<LinkType>();
        List<Sources> all_Sources = new List<Sources>();
        List<LinkRepository> all_Links = new List<LinkRepository>();
        public IEnumerable<LinkType> linkTypes { get; set; }
        public IEnumerable<LinkRepository> linkRepositories { get; set; }

        protected override async Task OnInitializedAsync()
        {
            LinkType lt = new LinkType();
            lt.Id = 1;
            lt.Linktype_Name = "Video";
            all_Types.Add(lt);

            lt = new LinkType();
            lt.Id = 2;
            lt.Linktype_Name = "Test";
            all_Types.Add(lt);

            lt = new LinkType();
            lt.Id = 3;
            lt.Linktype_Name = "Reading";
            all_Types.Add(lt);

            lt = new LinkType();
            lt.Id = 4;
            lt.Linktype_Name = "Other";
            all_Types.Add(lt);

            linkTypes = all_Types.ToList();

            LinkRepository lr = new LinkRepository();
            lr.Id = 1;
            lr.link = "https://youtube.com";
            lr.linkTypeId = 1;
            lr.link_description = "Best GRE Prep Videos";
            lr.categoriesId = 1;
            lr.link_iframe = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/vFyJp8TM69Q\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>";
            all_Links.Add(lr);

            lr = new LinkRepository();
            lr.Id = 2;
            lr.link = "https://youtube.com";
            lr.linkTypeId = 2;
            lr.link_description = "Best GRE Prep Testing";
            lr.categoriesId = 1;
            all_Links.Add(lr);

            lr = new LinkRepository();
            lr.Id = 3;
            lr.link = "https://youtube.com";
            lr.linkTypeId = 3;
            lr.link_description = "Best GRE Prep Reading";
            lr.categoriesId = 1;
            all_Links.Add(lr);

            lr = new LinkRepository();
            lr.Id = 4;
            lr.link = "https://youtube.com";
            lr.linkTypeId = 4;
            lr.link_description = "Best GRE Prep Other";
            lr.categoriesId = 1;
            all_Links.Add(lr);

            lr = new LinkRepository();
            lr.Id = 5;
            lr.link = "https://youtube.com";
            lr.linkTypeId = 1;
            lr.link_description = "Best GRE Prep Videos";
            lr.categoriesId = 1;
            all_Links.Add(lr);

            linkRepositories = all_Links.ToList();
            

        }
    }
}
