using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace cosmosdb_latency.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration configuration;

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string WebsiteRegion { get; set; }

        public void OnGet()
        {
            WebsiteRegion = configuration["REGION_NAME"]?.ToLowerInvariant()?.Replace(" ", "");
        }
    }
}
