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
using Newtonsoft.Json;

namespace cosmosdb_latency.Pages
{
    public class IndexModel : PageModel
    {
        // private readonly IDocumentClient documentClient;

        // public IndexModel(IDocumentClient documentClient)
        // {
        //     this.documentClient = documentClient;
        // }

        // public string Json { get; set; }
        // public TimeSpan TimeTaken { get; set; }
        // public string WriteEndpoint { get; set; }

        // public async Task OnGet()
        // {
        //     var sw = Stopwatch.StartNew();
        //     var result = await documentClient.CreateDocumentAsync("/dbs/test/colls/test", new { date = DateTimeOffset.UtcNow });
        //     TimeTaken = sw.Elapsed;
        //     Json = JsonConvert.SerializeObject(result.Resource);
        //     WriteEndpoint = documentClient.WriteEndpoint.ToString();
        // }
    }
}
